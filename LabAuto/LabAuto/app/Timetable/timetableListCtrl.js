(function () {
    "use strict";
    //var LabAutoApp = angular.module('LabAutoApp', ['ngRoute', 'ngAnimate']);
    //var LabAutoApp = angular.module('LabAutoApp', []);
    var LabAutoApp = angular.module('LabAutoApp');
    module.controller("TimetableListCtrl", function ($scope, $http) {


        function timetablelistCtrl(timetableResource) {
            var vm = this;


            timetableResource.query(function (data) {
                vm.timetable = data;
            });

        }
    });

});