using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Repository
{
    public class AttendanceRepository
    {
        UniversityResursesEntities xEntity = new UniversityResursesEntities();

        public void Insert(int AttendanceID, int TimetableID, string AttendanceStatus, TimeSpan EntringTime, TimeSpan ExitingTime)
        {

            //New Object
            Attendance objNewAttendance = new Attendance();
            //Assign function input parametrs to new object
            objNewAttendance.AttendanceID = AttendanceID;
            objNewAttendance.TimetableID = TimetableID;
            objNewAttendance.AttendanceStatus = AttendanceStatus;
            objNewAttendance.EntringTime = EntringTime;
            objNewAttendance.ExitingTime = ExitingTime;
            objNewAttendance.TimetableID = TimetableID;

       


            //Add new object to Entity
            xEntity.Attendances.Add(objNewAttendance);

            //Entity save chnages to database
            xEntity.SaveChanges();

        }
        //For Update data
        public void Update(int AttendanceID, int TimetableID, string AttendacneStatus, TimeSpan EntringTime, TimeSpan ExitingTime)
        {
            //Get Object from Database
            Attendance objNewAttendacne = (from x in xEntity.Attendances where x.AttendanceID == AttendanceID select x).FirstOrDefault();

            //Add new object to Entity
            xEntity.Attendances.Attach(objNewAttendacne);
            //Assign function input parametrs to new object

            objNewAttendacne.AttendanceID = AttendanceID;
            objNewAttendacne.AttendanceStatus = AttendacneStatus;
            objNewAttendacne.TimetableID = TimetableID;
            objNewAttendacne.EntringTime = EntringTime;
            objNewAttendacne.ExitingTime = ExitingTime;


            //Entity save changes to dataBase
            xEntity.SaveChanges();

        }
        public void Delete(int AttendanceID)
        {
            //Get Atteendance from database
            Attendance objNewAttendance = (from x in xEntity.Attendances where x.AttendanceID == AttendanceID select x).FirstOrDefault();
            //Add New object to Entity
            xEntity.Attendances.Attach(objNewAttendance);
            xEntity.Attendances.Remove(objNewAttendance);
            //Entity save changes to database
            xEntity.SaveChanges();
        }

        internal void Update(int attendaneID, string attendanceStatus, int timetableID)
        {
            throw new NotImplementedException();
        }

        public Models.Attendance getAttendance(int attendanceid)
        {
            Models.Attendance objAttendacne = (from x in xEntity.Attendances where x.AttendanceID == attendanceid select new Models.Attendance { AttendanceID = x.AttendanceID, TimetableID = x.TimetableID, AttendanceStatus = x.AttendanceStatus, EnteringTime = x.EntringTime, ExitingTime = x.EntringTime }).FirstOrDefault();
            return objAttendacne;
        }
        public List<Models.Attendance> getAttendances()
        {
            List<Models.Attendance> objAttendances = (from x in xEntity.Attendances select new Models.Attendance { AttendanceID = x.AttendanceID, TimetableID = x.TimetableID, AttendanceStatus = x.AttendanceStatus, EnteringTime = x.EntringTime, ExitingTime = x.ExitingTime }).ToList();
            return objAttendances;
        }
        public List<Attendance> getAttendances(string attendancestatus)
        {
            List<Attendance> objAttendaces = (from x in xEntity.Attendances where x.AttendanceStatus == attendancestatus select x).ToList();
            return objAttendaces;
        }
    }
}