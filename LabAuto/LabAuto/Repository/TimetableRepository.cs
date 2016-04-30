using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Repository
{
    public class TimetableRepository
    {
        UniversityResursesEntities xEntity = new UniversityResursesEntities();

        public bool RegisterTimeTable(DateTime Date, TimeSpan Starttime, TimeSpan Finishtime, bool Timetablestatus, int LabID, int TeacherID, int CourseID, int TimetableID)
        {
            Timetable objNewTimetable = (from x in xEntity.Timetables where x.Date.Day == Date.Day && x.Date.Month == Date.Month && x.LabID == LabID && x.Starttime.CompareTo(Finishtime) < 0 && x.Finishtime.CompareTo(Starttime) > 0 select x).FirstOrDefault();

            if (objNewTimetable == null)
            {
                //Adding New Time table 
                objNewTimetable = new Timetable();
                //Assig function input parameters to new object
                objNewTimetable.Date = Date;
                objNewTimetable.Starttime = Starttime;
                objNewTimetable.Finishtime = Finishtime;
                objNewTimetable.TimetableStatus = Timetablestatus;
                objNewTimetable.LabID = LabID;
                objNewTimetable.TeacherID = TeacherID;
                objNewTimetable.CourseID = CourseID;

                //Add  new Object to Entity
                xEntity.Timetables.Add(objNewTimetable);

                //Entity save changes to database
                xEntity.SaveChanges();
                return true;
            }
            else {
                return false;
            }
        }

        public void Insert(DateTime Date, TimeSpan Starttime, TimeSpan Finishtime, bool Timetablestatus, int LabID, int TeacherID, int CourseID, int TimetableID)
        {
            Timetable objNewTimetable = new Timetable();

            //Assig function input parameters to new object
            objNewTimetable.Date = Date;
            objNewTimetable.Starttime = Starttime;
            objNewTimetable.Finishtime = Finishtime;
            objNewTimetable.TimetableStatus = Timetablestatus;
            objNewTimetable.LabID = LabID;
            objNewTimetable.TeacherID = TeacherID;
            objNewTimetable.CourseID = CourseID;
            objNewTimetable.TimetableID = TimetableID;


            //Add  new Object to Entity
            xEntity.Timetables.Add(objNewTimetable);

            //Entity save changes to database
            xEntity.SaveChanges();
        }


        //    Models.Timetable objtimetable = (from x in xEntity.Timetables where x.Date == Date && x.Starttime == Starttime && x.Finishtime == Finishtime && x.TimetableStatus == Timetablestatus && x.LabID == LabID select new Models.Timetable { Date = x.Date, Starttime = x.Starttime, Finishtime = x.Finishtime, TimetableStatus = x.TimetableStatus, LabID = x.LabID, TeacherID = x.TeacherID, CourseID = x.CourseID, TimetableID = x.TimetableID }).FirstOrDefault();
        //    //return objtimetable;
        //    //New Object
        //    Timetable objNewTimetable = new Timetable();

        //    //Assig function input parameters to new object
        //    objNewTimetable.Date = Date;
        //    objNewTimetable.Starttime = Starttime;
        //    objNewTimetable.Finishtime = Finishtime;
        //    objNewTimetable.TimetableStatus = Timetablestatus;
        //    objNewTimetable.LabID = LabID;
        //    objNewTimetable.TeacherID = TeacherID;
        //    objNewTimetable.CourseID = CourseID;
        //    objNewTimetable.TimetableID = TimetableID;


        //    //Add  new Object to Entity
        //    xEntity.Timetables.Add(objNewTimetable);

        //    //Entity save changes to database
        //    xEntity.SaveChanges();
        //}

        public void Update(DateTime Date, TimeSpan Starttime, TimeSpan Finishtime, bool Timetablestatus, int LabID, int TeacherID, int CourseID, int TimetableID)
        {
            //get Object from databes
            Timetable objNewTimetable = (from x in xEntity.Timetables where x.TimetableID == TimetableID select x).FirstOrDefault();


            //Add new object to Entity
            xEntity.Timetables.Attach(objNewTimetable);

            //Assign function input parametrs to new object

            objNewTimetable.Date = Date;
            objNewTimetable.Starttime = Starttime;
            objNewTimetable.Finishtime = Finishtime;
            objNewTimetable.TimetableStatus = Timetablestatus;
            objNewTimetable.TeacherID = TeacherID;
            objNewTimetable.LabID = LabID;
            objNewTimetable.CourseID = CourseID;
            objNewTimetable.TimetableID = TimetableID;

            //Entity save chnages to Databes
            xEntity.SaveChanges();

        }

        public void Delete(int TimetableId)
        {
            Timetable objNewTimetable = (from x in xEntity.Timetables where x.TimetableID == TimetableId select x).First();

            //Add new object to Entity
            xEntity.Timetables.Attach(objNewTimetable);
            xEntity.Timetables.Remove(objNewTimetable);

            //Entity save chnages to database
            xEntity.SaveChanges();
        }



        public Models.Timetable getTimetable(int labid)
        {
            Models.Timetable objTimetable = (from x in xEntity.Timetables where x.LabID == labid select new Models.Timetable { TimetableID = x.TimetableID, CourseID = x.CourseID, Date = x.Date, LabID = x.LabID, TeacherID = x.TeacherID, TimetableStatus = x.TimetableStatus, Starttime = x.Starttime, Finishtime = x.Finishtime }).FirstOrDefault();
            return objTimetable;
        }


        public List<Models.Timetable> getTodayTimetables()
        {
            DateTime objDate = DateTime.Now;
            List<Models.Timetable> objTimetables = (from x in xEntity.Timetables.Include("Course").Include("Teacher").Include("Lab") where x.Date.Day >= objDate.Day && x.Date.Month >= objDate.Month select new Models.Timetable { TimetableID = x.TimetableID, CourseID = x.CourseID, Date = x.Date, LabID = x.LabID, TeacherID = x.TeacherID, TimetableStatus = x.TimetableStatus, Starttime = x.Starttime, Finishtime = x.Finishtime , CourseName = x.Course.CourseName, LabLocation = x.Lab.LabLocation, TeacherFirstname = x.Teacher.TeacherFirstname, TeacherLastname = x.Teacher.TeacherLastname}).ToList();
            return objTimetables;
        }


        public Models.Timetable getTimetables(int labid)
        {

            Models.Timetable objTimetable = (from x in xEntity.Timetables where x.LabID == labid select new Models.Timetable { TimetableID = x.TimetableID, CourseID = x.CourseID, Date = x.Date, LabID = x.LabID, TeacherID = x.TeacherID, TimetableStatus = x.TimetableStatus, Starttime = x.Starttime, Finishtime = x.Finishtime }).FirstOrDefault();
            return objTimetable;
        }


        public List<Models.Timetable> getTimetables()
        {
            List<Models.Timetable> objTimetables = (from x in xEntity.Timetables select new Models.Timetable { TimetableID = x.TimetableID, CourseID = x.CourseID, Date = x.Date, LabID = x.LabID, TeacherID = x.TeacherID, TimetableStatus = x.TimetableStatus, Starttime = x.Starttime, Finishtime = x.Finishtime }).ToList();
            return objTimetables;
        }



        //public List<Models.Timetable> getTodayTimetable(DateTime Date)
        //{
        //    DateTime objDate = DateTime.Now;
        //    List<Models.Timetable> objTimetables = (from x in xEntity.Timetables where x.Date.Day >= objDate.Day && x.Date.Month >= objDate.Month select new Models.Timetable { TimetableID = x.TimetableID, CourseID = x.CourseID, Date = x.Date, LabID = x.LabID, TeacherID = x.TeacherID, TimetableStatus = x.TimetableStatus, Starttime = x.Starttime, Finishtime = x.Finishtime }).ToList();
        //    return objTimetables;
        //}


        public List<Timetable> getTimetables(bool timetablestatus)
        {
            List<Timetable> objTimetables = (from x in xEntity.Timetables where x.TimetableStatus == timetablestatus select x).ToList();
            return objTimetables;
        }
    }
}