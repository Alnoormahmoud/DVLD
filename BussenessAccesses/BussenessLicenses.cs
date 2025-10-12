using DataAccesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static BussenessAccesses.clsBussenessLicenses;
using static System.Net.Mime.MediaTypeNames;

namespace BussenessAccesses
{
    public class clsBussenessLicenses
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public clsBussenessDrivers DriverInfo;
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClassID { set; get; }
        public clsBussenessLicenseClasses LicenseClassIfo;
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public Decimal PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public int CreatedByUserID { set; get; }

        //public string IssueReasonText
        //{
        //    get
        //    {
        //        return GetIssueReasonText(this.IssueReason);
        //    }
        //}
        //public clsDetainedLicense DetainedInfo { set; get; }
        //public bool IsDetained
        //{
        //    get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        //}
        public clsBussenessLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;   
        }
        public clsBussenessLicenses(int LicenseId, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
               DateTime ExpirationDate, string Notes, Decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseId;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = (enIssueReason)IssueReason;
            this.CreatedByUserID = CreatedByUserID;
           this.DriverInfo = clsBussenessDrivers.FindDriverByDriverId(DriverID);
            this.LicenseClassIfo = clsBussenessLicenseClasses.Find(LicenseClass);
            Mode = enMode.Update;
        }

        
        public static clsBussenessLicenses FindLicenseByLicenseId(int LicenseId)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            Decimal PaidFees = 0;
            bool IsActive = false;
            int IssueReason = (int) enIssueReason.FirstTime;

            if (clsDataLicenses.FindLicenseByLicenseId(LicenseId, ref ApplicationID,ref DriverID, ref LicenseClass,
               ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsBussenessLicenses(LicenseId, ApplicationID, DriverID, LicenseClass,
                 IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            return null;
        }

        static public int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsDataLicenses.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public static DataTable GetAllLicenses()
        {
            return clsDataLicenses.GetAllLicenses();
        }
        public clsBussenessLicenses RenewLicense(int CreatedByUserID, string Notes)
        {

            //First Create Applicaiton 
            clsBussenessApplications Application = new clsBussenessApplications();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsBussenessApplications.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsBussenessApplications.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.RenewDrivingLicense).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsBussenessLicenses NewLicense = new clsBussenessLicenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassIfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassIfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsBussenessLicenses.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }


            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;

        }
        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsDataLicenses.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate,this.ExpirationDate,this.Notes,this.PaidFees,this.IsActive, (int)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }
        public bool DeactivateCurrentLicense()
        {
            return (clsDataLicenses.DeactivateLicense(this.LicenseID));
        }

        public static DataTable GetAllLocalLicenses(int DriverID)
        {
            return clsDataLicenses.GetAllLocalLicensesForADriver(DriverID);
        }
        private bool _UpdateLiense()
        {
            //call DataAccess Layer 
            return false;// clsDataUseresManagement.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }

        public  bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLiense();

            }

            return false;
        }
    }
}
