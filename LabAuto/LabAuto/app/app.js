//Timetable List 

//(function () {
"use strict";

var app = angular.module("LabAutoApp",
                        ["common.services",
                        ]);
app.controller("timetableListCtrl", function ($scope, $http) {

    var vm = this;

    $scope.timetables = [];
    $scope.timetableBooking;

    $scope.teacherID;
    $scope.couserID;
    $scope.labID;
    $scope.date;
    $scope.startTime;
    $scope.finishTime;
    $scope.timetableStatus;

    //List Function
    $http.get("http://localhost:60587/api/timetables/today").then(function (data) {
        $scope.timetables.push.apply($scope.timetables, data.data);
        console.log(data.data);
        console.log($scope.timetables);
    }, function (error) {
        $window.alert('Sorry, an error occurred: ' + error.data.message);
    });

    
    $scope.submit = function () {
        // use $.param jQuery function to serialize data from JSON 
        var data = {
            teacherID: $scope.teacherID,
            courseID: $scope.courseID,
            labID: $scope.labID,
            date: $scope.date,
            startTime: $scope.startTime,
            finishTime: $scope.finishTime,
            timetableStatus: $scope.timetableStatus,
            TimetableID: 0
        };

        console.log('Helooooooooooooooooooooooooooo');
        console.log(data);

        var config = {
            headers: { 'Content-Type': 'application/json' }
        }

        $http.post('http://localhost:60587/api/Timetable', data, config)
        .success(function (data, status, headers, config) {
            $scope.PostDataResponse = data;
        })
        .error(function (data, status, header, config) {
            $scope.ResponseDetails = "Data: " + data +
                "<hr />status: " + status +
                "<hr />headers: " + header +
                "<hr />config: " + config;
        });
    };

////Login Part

    app.controller('loginController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

        $scope.loginData = {
            userName: "",
            //password: ""
        };

        $scope.message = "";

        $scope.login = function () {
            var data = {
                TeacherTPNumber:$scope.TeacherTPnumber,
            }

            authService.login($scope.loginData).then(function (response) {

                $location.path('/login');

            },
             function (err) {
                 $scope.message = err.error_description;
             });
        };

    }]);

    app.factory('ordersService', ['$http', function ($http) {

        var serviceBase = 'http://localhost:60587';
        var loginServiceFactory = {};

        var _gettp = function () {

            return $http.get(serviceBase + 'api/Teacher/login/{tp}').then(function (results) {
                return results;
            });
        };

        loginServiceFactory.getOrders = _gettp;

        return loginServiceFactory;

    }]);


    function timetablelistCtrl(timetableResource) {



        timetableResource.query(function (data) {
            vm.timetable = data;
        });

    }
})


// ;)

//Technical Problem List And Post 

app.controller("TechnicalProblemAddCtrl", function ($scope, $http) {

    var vm = this;

    $scope.technicalproblems = [];

    $scope.technicalproblem;

    $scope.problemDescription;
    $scope.timetableID;
    $scope.problemStatus;

    $http.get("http://localhost:60587/api/problem").then(function (data) {
        $scope.technicalproblems.push.apply($scope.technicalproblems, data.data);
        console.log(data.data);
        console.log($scope.technicalproblems);
    }, function (error) {
        $window.alert('Sorry, an error occurred: ' + error.data.message);
    });

    // use $.param jQuery function to serialize data from JSON 
    //var data = {
    //    problemDescription: 'Yasser',
    //    timetableID: 1007,
    //    problemStatus: 0,
    //    TechnicalProblemID: 0
    //};
    //console.log('Helooooooooooooooooooooooooooo');
    //console.log(data);
    //var config = {
    //    headers: { 'Content-Type': 'application/json' }
    //}

    //$http.post('http://localhost:60587/api/problem', data, config)
    //.success(function (data, status, headers, config) {
    //    $scope.PostDataResponse = data;
    //})
    //.error(function (data, status, header, config) {
    //    $scope.ResponseDetails = "Data: " + data +
    //        "<hr />status: " + status +
    //        "<hr />headers: " + header +
    //        "<hr />config: " + config;
    //});

    $scope.submit = function () {
        // use $.param jQuery function to serialize data from JSON 
        var data = {
            problemDescription: $scope.problemDescription,
            timetableID: $scope.timetableID,
            problemStatus: $scope.problemStatus,
            TechnicalProblemID: 0
        };

        console.log('Helooooooooooooooooooooooooooo');
        console.log(data);

        var config = {
            headers: { 'Content-Type': 'application/json' }
        }

        $http.post('http://localhost:60587/api/problem', data, config)
        .success(function (data, status, headers, config) {
            $scope.PostDataResponse = data;
        })
        .error(function (data, status, header, config) {
            $scope.ResponseDetails = "Data: " + data +
                "<hr />status: " + status +
                "<hr />headers: " + header +
                "<hr />config: " + config;
        });
    };

    function TechnicalProblemAddCtrl(technicalproblemResources) {

        technicalproblemResources.query(function (data) {
            vm.technicalproblem = data;
        });

    }
})





