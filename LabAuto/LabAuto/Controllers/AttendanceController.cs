using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabAuto.Controllers
{
    [RoutePrefix("api")]
    public class AttendanceController : ApiController
    {
        [Route("Attendance", Name = "getAttendances")]
        [HttpGet]
        public IHttpActionResult getAttendances()
        {
            Repository.AttendanceRepository attendanceRepo = new Repository.AttendanceRepository();

            List<Models.Attendance> objList = attendanceRepo.getAttendances();

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }


        [Route("Attendance/{AttendanceID}", Name = "getAttendanceByID")]
        [HttpGet]
        public IHttpActionResult getAttendance(int AttendanceID)
        {
            Repository.AttendanceRepository attendanceRepo = new Repository.AttendanceRepository();

            Models.Attendance objList = attendanceRepo.getAttendance(AttendanceID);

            if (objList == null)
            {
                return NotFound();
            }
            return Ok(objList);

        }

        [Route("Attendance/{AttendanceID}", Name = "DeleteAttendanceByID")]
        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int AttendanceID)
        {

            Repository.AttendanceRepository attendanceRepo = new Repository.AttendanceRepository();
            attendanceRepo.Delete(AttendanceID);
            return Ok();
        }

        //Put Method
        [Route("Attendance/{AttendanceID}", Name = "PutAttendanceByID")]
        [HttpPut]
        public void Put(int AttendanceID, LabAuto.Models.Attendance objAttendance)
        {
            Repository.AttendanceRepository attendanceRepo = new Repository.AttendanceRepository();
            attendanceRepo.Update(AttendanceID, objAttendance.TimetableID, objAttendance.AttendanceStatus, objAttendance.EnteringTime, objAttendance.ExitingTime);
        }

        //Post Method
        [Route("Attendance")]
        [HttpPost]
        public void Post(LabAuto.Models.Attendance objAttendance)
        {
            Repository.AttendanceRepository attendanceRepo = new Repository.AttendanceRepository();
            attendanceRepo.Insert(objAttendance.AttendanceID, objAttendance.TimetableID, objAttendance.AttendanceStatus, objAttendance.EnteringTime, objAttendance.ExitingTime);

        }

    }
}