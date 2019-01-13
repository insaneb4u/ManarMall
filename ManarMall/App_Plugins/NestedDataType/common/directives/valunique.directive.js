angular.module("umbraco").directive('valUnique', function () {
    return {
        require: 'ngModel',
        link: function (scope, elem, attr, ngModel) {
            var scope = scope;
            //For DOM -> model validation
            ngModel.$parsers.unshift(function (value) {
                var valid = _.filter(_.map(scope.model.value, function (item) {
                    return item.alias;
                }), function (item) {
                    return item == value;
                }).length <= 0;

                ngModel.$setValidity('unique', valid);
                return valid ? value : undefined;
            });

            //For model -> DOM validation
            ngModel.$formatters.unshift(function (value) {
                var valid = _.filter(_.map(scope.model.value, function (item) {
                    return item.alias;
                }), function (item) {
                    return item == value;
                }).length <= 1;

                ngModel.$setValidity('unique', valid);
                return value;
            });
        }
    };
});