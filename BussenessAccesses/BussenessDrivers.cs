using DataAccesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussenessAccesses
{
    public class clsBussenessDrivers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

 
        public int DriverID { set; get; }
        public int PersonID { set; get; }

        public clsBussenessPeopleManegement PersonInfo;
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { set; get; }

        public clsBussenessDrivers()
        {
            this.DriverID = -1;
            this.PersonID = -1;
             this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsBussenessDrivers(int DriverId, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverId;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsBussenessPeopleManegement.Find(PersonID);

            Mode = enMode.Update;
        }

        public static clsBussenessDrivers FindDriverByDriverId(int DriverID)
        {
            clsBussenessDrivers driver = null;
            int personID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;
            bool found = clsDataDrivers.FindDriverByDriverId(DriverID, ref personID, ref createdByUserID, ref createdDate);
            if (found)
            {
                driver = new clsBussenessDrivers(DriverID, personID, createdByUserID, createdDate);
            }
            return driver;
        }      
        
        public static clsBussenessDrivers FindDriverByPersonId(int PersonId)
        {
            clsBussenessDrivers driver = null;
            int DriverID = -1;
            int createdByUserID = -1;
            DateTime createdDate = DateTime.Now;
            bool found = clsDataDrivers.FindDriverByPersonId(PersonId, ref DriverID, ref createdByUserID, ref createdDate);
            if (found)
            {
                driver = new clsBussenessDrivers(DriverID, PersonId, createdByUserID, createdDate);
            }
            return driver;
        }
        public static DataTable GetAllLocalLicensesForADriver(int DriverID)
        {
            return clsBussenessLicenses.GetAllLocalLicenses(DriverID);
        }
        public static DataTable GetAllInternationalLicensesForADriver(int DriverID)
        {
            return clsBussenessLicenses.GetAllLocalLicenses(DriverID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDataDrivers.GetAllDrivers();
        }

        private bool _AddNewDriver()
        {
            //call DataAccess Layer 

            this.DriverID = clsDataDrivers.AddNewDriver(PersonID, CreatedByUserID);


            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            //call DataAccess Layer 

            return clsDataDrivers.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateDriver();

            }

            return false;
        }

    }
}
