(function () {
    "use strict";


    angular
        .module("LabAutoApp")
        .factory("technicalproblemResources",
               ["$resource",
                "appSettings",
               technicalproblemResources])

    function technicalproblemResources($resource, appSettings) {
        //return $resource(appSettings.serverPath + "/api/timetable/:id", null
        return $resource(appSettings.serverPath + "/api/problem");



    }
})
