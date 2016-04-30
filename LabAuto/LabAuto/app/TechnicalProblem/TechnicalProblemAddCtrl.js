//(function () {
    "use strict";
    //var LabAutoApp = angular.module('LabAutoApp', ['ngRoute', 'ngAnimate']);
    var LabAutoApp = angular.module('LabAutoApp');
    LabAutoApp.controller("TechnicalProblemAddCtrl", function ($scope, $http) {


        function TechnicalProblemAddCtrl(technicalproblemResources) {
            var vm = this;


            technicalproblemResources.query(function (data) {
                vm.technicalproblem = data;
            });

        }
    });

