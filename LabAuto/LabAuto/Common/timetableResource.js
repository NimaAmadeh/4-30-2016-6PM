(function () {
    "use strict";


    angular
        .module("LabAutoApp")
        .factory("timetableResource",
               ["$resource",
                "appSettings",
               timetableResource])
    
    function timetableResource($resource, appSettings) {
        //return $resource(appSettings.serverPath + "/api/timetable/:id", null
        return $resource(appSettings.serverPath + "/api/Timetables/today");

 
      
    }
})