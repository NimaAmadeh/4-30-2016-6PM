using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Repository
{
    public class TeacherRepository
    {
        UniversityResursesEntities xEntity = new UniversityResursesEntities();

        //public class TeacherModelBinder : IModelBinder
        //{
        //    public
        //}
        public void Insert(int TeacherID, string Firstname, string Lastname, string Email, int Phone, string TPnumber)
        {
            //New Object
            Teacher objNewTeacher = new Teacher();

            //Assign function input parameters to new object
            objNewTeacher.TeacherID = TeacherID;
            objNewTeacher.TeacherEmail = Email;
            objNewTeacher.TeacherFirstname = Firstname;
            objNewTeacher.TeacherLastname = Lastname;
            objNewTeacher.TeacherPhonenum = Phone;
            objNewTeacher.TeacherTPnumber = TPnumber;

            //Add new object to Entity
            xEntity.Teachers.Add(objNewTeacher);

            //Entity save changes to database
            xEntity.SaveChanges();
        }

        //For Update Should take Id also
        public void Update(int TeacherID, string Firstname, string Lastname, string Email, int Phone, string TPnumber)
        {
            //Get Object from database
            Teacher objNewTeacher = (from x in xEntity.Teachers where x.TeacherID == TeacherID select x).FirstOrDefault();

            //Add new object to Entity
            xEntity.Teachers.Attach(objNewTeacher);

            //Assign function input parameters to new object
            objNewTeacher.TeacherEmail = Email;
            objNewTeacher.TeacherFirstname = Firstname;
            objNewTeacher.TeacherLastname = Lastname;
            objNewTeacher.TeacherPhonenum = Phone;
            objNewTeacher.TeacherTPnumber = TPnumber;

            //Entity save changes to database
            xEntity.SaveChanges();
        }

        //For Delete Kind Of New teacher We created New Teacher Put it in new OBJ
        public void Delete(int TeacherID)
        {
            //Get teacher from database
            Teacher objNewTeacher = (from x in xEntity.Teachers where x.TeacherID == TeacherID select x).FirstOrDefault();


            xEntity.Teachers.Attach(objNewTeacher);
            xEntity.Teachers.Remove(objNewTeacher);

            xEntity.SaveChanges();
        }




        public Models.Teacher getTeacher(int teacherid)
        {
            Models.Teacher objTeacher = (from x in xEntity.Teachers where x.TeacherID == teacherid select new Models.Teacher { TeacherID = x.TeacherID, TeacherFirstname = x.TeacherFirstname, TeacherLastname = x.TeacherLastname, TeacherEmail = x.TeacherEmail, TeacherPhonenum = x.TeacherPhonenum, TeacherTPnumber = x.TeacherTPnumber}).FirstOrDefault();
            return objTeacher;
        }

        public Teacher getTeacher(string teacheremail)
        {
            Teacher objTeacher = (from x in xEntity.Teachers where x.TeacherEmail == teacheremail select x).First();
            return objTeacher;
        }
        public Models.Teacher getTeachersTP(string teacherTPnumber)
        {
            Models.Teacher objTeacher = (from x in xEntity.Teachers where x.TeacherTPnumber == teacherTPnumber select new Models.Teacher { TeacherID = x.TeacherID, TeacherFirstname = x.TeacherFirstname, TeacherLastname = x.TeacherLastname, TeacherEmail = x.TeacherEmail, TeacherPhonenum = x.TeacherPhonenum, TeacherTPnumber = x.TeacherTPnumber }).FirstOrDefault();
            return objTeacher;
        }

        public Models.Teacher getTeacherslogintp(string teacherTPnumber)
        {
            Models.Teacher objTeacher = (from x in xEntity.Teachers where x.TeacherTPnumber == teacherTPnumber select new Models.Teacher { TeacherID = x.TeacherID, TeacherFirstname = x.TeacherFirstname, TeacherLastname = x.TeacherLastname, TeacherEmail = x.TeacherEmail, TeacherPhonenum = x.TeacherPhonenum, TeacherTPnumber = x.TeacherTPnumber }).FirstOrDefault();
            return objTeacher;
        }

        //public List<Models.Teacher> getTeacher()
        //{
        //    List<Models.Teacher> objTeachers = (from x in xEntity.Teachers select new Models.Teacher { TeacherID = x.TeacherID }).ToList();
        //}

        public List<Models.Teacher> getTeachers()
        {
            List<Models.Teacher> objTeachers = (from x in xEntity.Teachers select new Models.Teacher { TeacherID = x.TeacherID, TeacherFirstname = x.TeacherFirstname, TeacherLastname = x.TeacherLastname, TeacherEmail = x.TeacherEmail, TeacherPhonenum = x.TeacherPhonenum }).ToList();
            return objTeachers;
        }

        public List<Teacher> getTeachers(int PhoneNumber)
        {
            List<Teacher> objTeachers = (from x in xEntity.Teachers where x.TeacherPhonenum == PhoneNumber select x).ToList();
            return objTeachers;



        }
        public void Search(string TPnumber)
        {

            Teacher objNewTeacher = (from x in xEntity.Teachers where x.TeacherTPnumber == TPnumber select x).First();
        }


    }
}