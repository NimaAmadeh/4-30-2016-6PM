using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAuto.Repository
{
    public class LabRepository
    {
        UniversityResursesEntities xEntity = new UniversityResursesEntities();

        public void Insert(int LabID,string lablocation)
        {
            //New Object
            Lab objNewLab = new Lab();

            //Assign function input paramesters to new object
            objNewLab.LabID = LabID;
            objNewLab.LabLocation = lablocation;

            //Add New object to Entity
            xEntity.Labs.Add(objNewLab);

            //Entity save changes to database
            xEntity.SaveChanges();
        }

        //For Update Should take id also
        public void Update(int LabID, string lablocation)
        {
            //get Object from database
            Lab objNewLab = (from x in xEntity.Labs where x.LabID == LabID select x).FirstOrDefault();

            xEntity.Labs.Attach(objNewLab);

            //Add new object to Entity
            xEntity.Labs.Attach(objNewLab);

            //Assign function input parameters to new object
            objNewLab.LabID = LabID;
            objNewLab.LabLocation = lablocation;


            xEntity.SaveChanges();
        }

        public void Delete(int LabID)
        {
            Lab objNewLab = (from x in xEntity.Labs where x.LabID == LabID select x).First();
            //Add new object to Entity
            xEntity.Labs.Attach(objNewLab);
            xEntity.Labs.Remove(objNewLab);
            //Entity save changes to Database
            xEntity.SaveChanges();
        }


        public Models.Lab getLab(int labid)
        {
            Models.Lab objLab = (from x in xEntity.Labs where x.LabID == labid select new Models.Lab { LabID = x.LabID, LabLocation = x.LabLocation }).FirstOrDefault();
            return objLab;
        }
        public List<Models.Lab> getlabs()
        {
            List<Models.Lab> objLabs = (from x in xEntity.Labs select new Models.Lab { LabID = x.LabID, LabLocation = x.LabLocation }).ToList();
            return objLabs;
        }
        public List<Lab> getLabs(string lablocation)
        {
            List<Lab> objLabs = (from x in xEntity.Labs where x.LabLocation == lablocation select x).ToList();
            return objLabs;
        }
    }
}