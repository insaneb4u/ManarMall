/**
    * @ngdoc service
    * @name umbraco.resources.dataTypeResource
    * @description Loads in data for data types
    **/
function dataTypeNdtResource($q, $http, umbDataFormatter, umbRequestHelper) {

    return {

        getAllPropertyEditors: function () {

            return umbRequestHelper.resourcePromise(
               $http.get(
                   umbRequestHelper.getApiUrl(
                       "dataTypeNdtApiBaseUrl",
                       "GetAllPropertyEditors")),
               'Failed to retrieve data');
        },
        getById: function (id) {

            return umbRequestHelper.resourcePromise(
               $http.get(
                   umbRequestHelper.getApiUrl(
                       "dataTypeNdtApiBaseUrl",
                       "GetById",
                       [{ id: id }])),
               "Failed to retrieve data for data type id " + id);
        }
    };
}

angular.module('umbraco.resources').factory('dataTypeNdtResource', dataTypeNdtResource);
