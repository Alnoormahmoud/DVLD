using DataAccesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussenessAccesses
{
    public class clsBussenessApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

         public int ApplicantPersonID { set; get; }
        public int ApplicationID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }

        public clsBussenessApplicationTypes ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { set; get; }
        public DateTime LastStatusDate { set; get; }
        public int CreatedByUserID { set; get; }
        public clsBussenessUsersManagement CreatedByUserInfo { set; get; }
        public Decimal PaidFees { set; get; }

        public string StatusText
        {
            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }

        public string ApplicantFullName
        {
            get
            {
                return clsBussenessPeopleManegement.Find(ApplicantPersonID).FullName;
            }
        }

        public clsBussenessApplications()
        {
            this.ApplicationID = -1;   
            this.ApplicationDate = DateTime.Now;
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
             this.PaidFees = 0;
            this.CreatedByUserID = -1;

            
            Mode = enMode.AddNew;
        }

        public clsBussenessApplications(int ApplicationID,int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID  = CreatedByUserID ;
   
            this.ApplicationTypeInfo = clsBussenessApplicationTypes.GetApplicationTypeByApplicationTypeID(ApplicationTypeID);
            this.CreatedByUserInfo = clsBussenessUsersManagement.Find(CreatedByUserID);
            Mode = enMode.Update;
        }

        static public DataTable GetAllLDLApplicatinos()
        {
            return clsDataApplications.GetAllApplications();
        }

        public bool IsDLApllicationExistById(int ApplicationID)
        {
            return clsDataApplications.IsApplicationExistById (ApplicationID);
        }

        public static clsBussenessApplications FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now; int ApplicationTypeID = -1;
            byte ApplicationStatus = 1; DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0; int CreatedByUserID = -1;


            if (clsDataApplications.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
                ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                //we return new object of that person with the right data
                return new clsBussenessApplications(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
                return null;
        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.ApplicationID  = clsDataApplications.AddNewApplicatio(this.ApplicantPersonID, this.ApplicationDate,this.ApplicationTypeID,
              (byte)this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID );

            return (this.ApplicationID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsDataApplications.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID,
               (byte) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsBussenessApplications.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsDataApplications.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

    }
}
