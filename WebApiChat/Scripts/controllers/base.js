window.app = angular.module('BeerAndChat', []);
app.controller('Base', function ($scope) {
    
    $scope.currentUser = {id : -1};
});

app.directive('bcMirror', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            if (typeof (attrs.ngModel) === 'undefined') {
                console.log('tried to mirror element with no ng-model attribute');
                return;
            }

            function updateVal() {
                element.parent().find('.mirror-text').remove();
                element.after('<span class="mirror-text">'+(scope[attrs.ngModel] || '')+'</span>');
            }

            scope.$watch(attrs.ngModel, function () {
                updateVal();
            });
        },
    };
});
