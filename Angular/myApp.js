/**
 * Created by Pavel.Kaliukhovich on 21.06.2016.
 */
(function(){
    'use strict';

    var app = angular.module('myApp', []);

    app.controller('myAppController', ['$scope', '$injector', function($scope, $injector){
        $scope.name = 'Pasha';
        $scope.age = 23;

        $scope.peoples = [
            { name: 'Katya', age: 23 },
            { name: 'Lena', age: 26 },
            { name: 'Olya', age: 22 },
            { name: 'Pasha', age: 23 }
        ];
    }]);


})();