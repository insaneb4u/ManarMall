function NestedDataTypeController($scope, $q, dataTypeNdtResource, angularHelper, entityResource) {

    // Support for reading data from old EmbeddedContent plugin.  Note that data must be structured the same way and use the same alias names.
    if(typeof($scope.model.value) == "string") {
        if ($scope.model.value.indexOf("<data>") === 0) {
            function xmlToJson(xml) {

                // Create the return object
                var obj = {};

                if (xml.nodeType == 1) { // element
                    // do attributes
                    if (xml.attributes.length > 0) {
                        obj["@attributes"] = {};
                        for (var j = 0; j < xml.attributes.length; j++) {
                            var attribute = xml.attributes.item(j);
                            obj["@attributes"][attribute.nodeName] = attribute.nodeValue;
                        }
                    }
                } else if (xml.nodeType == 3 || xml.nodeType == 4) { // text or cdata
                    obj = xml.nodeValue;
                }

                // do children
                if (xml.hasChildNodes()) {
                    for (var i = 0; i < xml.childNodes.length; i++) {
                        var item = xml.childNodes.item(i);
                        var nodeName = item.nodeName;
                        if (typeof (obj[nodeName]) == "undefined") {
                            obj[nodeName] = xmlToJson(item);
                        } else {
                            if (typeof (obj[nodeName].push) == "undefined") {
                                var old = obj[nodeName];
                                obj[nodeName] = [];
                                obj[nodeName].push(old);
                            }
                            obj[nodeName].push(xmlToJson(item));
                        }
                    }
                }
                return obj;
            };
            var xmlData = jQuery.parseXML($scope.model.value);
            var jsonData = xmlToJson(xmlData);
            
            if (jsonData.data.item == null) {
                delete $scope.model.value;
            } else {
                $scope.model.value = $.map(jsonData.data.item,
                    function (item) {
                        delete item["@attributes"];

                        $.each(item,
                            function (prop, value) {
                                item[prop] = value["#text"] || value["#cdata-section"];
                            });

                        return item;
                    });
            }
        } else {
            delete $scope.model.value;
        }
    }

    if (!$scope.model.value) {
        $scope.model.value = [];
    }

    //add any fields that there isn't values for
    if ($scope.model.config.min > 0) {
        for (var i = 0; i < $scope.model.config.min; i++) {
            if ((i + 1) > $scope.model.value.length) {
                $scope.model.value.push({});
            }
        }
    }

    $scope.add = function () {
        if ($scope.model.config.max <= 0 || $scope.model.value.length < $scope.model.config.max) {
            writeValue();
            $scope.model.value.push({});
            syncValue();

            var currForm = angularHelper.getCurrentForm($scope);
            currForm.$setDirty();
        }
    };

    $scope.remove = function (index) {
        writeValue();
        var remainder = [];
        for (var x = 0; x < $scope.model.value.length; x++) {
            if (x !== index) {
                remainder.push($scope.model.value[x]);
            }
        }
        $scope.model.value = remainder;
        syncValue();

        var currForm = angularHelper.getCurrentForm($scope);
        currForm.$setDirty();
    };


    var await = [];
    var dataTypes = [];
    var nodeCache = [];
    var propertyEditors;
    $scope.properties = [];

    $scope.hasValue = function (index) {
        return _.map(_.filter($scope.value[index], function (property) {
            return property.showsummary == true;
        }), function (item) {
            return item.value;
        }).join('') != "";
    }

    function syncValue() {
        $scope.value = _.map($scope.model.value, function (value) {
            return _.map($scope.model.config.items, function (property) {
                var datatype = dataTypes[property.datatype];
                var propertyeditor = _.filter(propertyEditors, function (dt) {
                    if (dt.alias == datatype.selectedEditor)
                        return this;
                }).pop();

                var fakeItem = _.clone(property);

                fakeItem.view = propertyeditor.view;
                fakeItem.hideLabel = propertyeditor.hideLabel;
                fakeItem.editor = propertyeditor.alias;


                fakeItem.config = _.reduce(datatype.preValues, function (o, v, i) {
                    o[v.key] = v.value;
                    return o;
                }, {});

                fakeItem.validation = { mandatory: property.required, pattern: property.validation };
                fakeItem.value = value[property.alias];

                if (fakeItem.value) {
                    if (fakeItem.view == 'contentpicker') {
                        if (nodeCache[fakeItem.value])
                            fakeItem.text = nodeCache[fakeItem.value];
                        else
                            entityResource.getById(fakeItem.value, 'Document').then(function (item) {
                                nodeCache[fakeItem.value] = item.name;
                                fakeItem.text = item.name;
                            });
                    }
                    else if (fakeItem.view == 'mediapicker') {
                        if (nodeCache[fakeItem.value])
                            fakeItem.text = nodeCache[fakeItem.value];
                        else
                            entityResource.getById(fakeItem.value, 'Media').then(function (item) {
                                nodeCache[fakeItem.value] = item.name;
                                fakeItem.text = item.name;
                            });
                    }
                    else if (fakeItem.view == 'boolean') {
                        fakeItem.text = fakeItem.value ? "True" : "False";
                    }
                }

                return fakeItem;
            });
        });
    }

    function writeValue() {
        $scope.model.value = _.map($scope.value, function (value) {
            return _.reduce(value, function (o, v, i) {
                o[v.alias] = v.value;
                return o;
            }, {});
        });
    }

    dataTypeNdtResource.getAllPropertyEditors().then(function (data) {
        //await.push(dataTypeNdtResource.getAll().then(function (data) {
        //      _.each(dataTypes, function(data) {
        //          dataTypes[data.id] = data;
        //      });
        //}));

        _.each(_.unique(_.map($scope.model.config.items, function (i) { return i.datatype })), function (id) {
            await.push(dataTypeNdtResource.getById(id)
                .then(function (data) {
                    dataTypes[id] = data;
                }));
        });

        propertyEditors = data;

        // Wait for all property types to be read.  This should be quicker then using the commented out getAll above.
        $q.all(await).then(function () {
            syncValue();

        });
    });


    $scope.$on("formSubmitting", function (ev, args) {
        writeValue();
    });

    $scope.sortableOptions = {
        axis: 'y',
        containment: 'parent',
        cursor: 'move',
        items: '> div.control-group',
        tolerance: 'pointer',
        update: function (e, ui) {
            var currForm = angularHelper.getCurrentForm($scope);
            currForm.$setDirty();
        }
    };


    /*function getElementIndexByPrevalueText(value) {
        for (var i = 0; i < $scope.model.value.length; i++) {
            if ($scope.model.value[i].alias === value) {
                return i;
            }
        }

        return -1;
    }*/
}

angular.module("umbraco").controller("Umbraco.PropertyEditors.NestedDataTypeController", NestedDataTypeController);
