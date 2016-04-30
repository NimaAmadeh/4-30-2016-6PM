using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Repository
{
    public class CourseRepository
    {

        UniversityResursesEntities xEntity = new UniversityResursesEntities();

        public void Insert(int CourseID, string coursename, string coursecode)
        {
            //New Object
            Course objNewCourse = new Course();

            //Assign function input parameters to new object
            objNewCourse.CourseID = CourseID;
            objNewCourse.CourseName = coursename;
            objNewCourse.CourseCode = coursecode;
            

            //Add new object to Entity
            xEntity.Courses.Add(objNewCourse);
            //Entity sava chnages to database
            xEntity.SaveChanges();
        }
        public void Update(int CourseID, string Cousrsename, string Cousrecode)
        {
            Course objNewCourse = (from x in xEntity.Courses where x.CourseID == CourseID select x).FirstOrDefault();
            //Add New object To Entity
            xEntity.Courses.Attach(objNewCourse);

            //Assign new fucction input parameters to new object
            objNewCourse.CourseID = CourseID;
            objNewCourse.CourseName = Cousrsename;
            objNewCourse.CourseCode = Cousrecode;

            //Entity save chnages to database
            xEntity.SaveChanges();
        }
        public void Delete(int CousreID)
        {
            Course objNewCourse = (from x in xEntity.Courses where x.CourseID == CousreID select x).First();
            //Add new object to Entity
            xEntity.Courses.Attach(objNewCourse);
            xEntity.Courses.Remove(objNewCourse);
            //Entity save chnage to Database
            xEntity.SaveChanges();
        }

        public Models.Course getCourse(int courseid)
        {
            Models.Course objCourse = (from x in xEntity.Courses where x.CourseID == courseid select new Models.Course { CourseID = x.CourseID, CourseName = x.CourseName }).FirstOrDefault();
            return objCourse;
        }

        public List<Models.Course> getCourses()
        {
            List<Models.Course> objCourses = (from x in xEntity.Courses select new Models.Course {CourseID=x.CourseID, CourseName=x.CourseName}).ToList();
            return objCourses;
        }
        public List<Course> getCourses(string coursecode)
        {
            List<Course> objCourses = (from x in xEntity.Courses where x.CourseCode == coursecode select x).ToList();
            return objCourses;
        }

    }
}