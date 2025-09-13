
using DataAccesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BussenessAccesses
{
    public class clsBussenessLocBalDrivingLicenseApplications : clsBussenessApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
 
        public clsBussenessLicenseClasses LicenseClassInfo;

        public clsBussenessLocBalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = -1; 
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;
        }

        public clsBussenessLocBalDrivingLicenseApplications(int LDLApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus,
            DateTime LastStatusDate, Decimal PaidFees, int CreatedByUserID, int LicenseClassId)
        {
            this.LocalDrivingLicenseApplicationID = LDLApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassId;
  
            LicenseClassInfo = clsBussenessLicenseClasses.Find(LicenseClassId);

            Mode = enMode.Update;
        }

        public DataTable GetAllLDLApplications()
        {
            return clsDataLocalDrivingLicenseApplications.GetAllLDLApplications();
        }

        public static clsBussenessLocBalDrivingLicenseApplications FindLDLApplicationBYID(int LDLApplicationID)
        {
            int ApplicationID = -1, LicenseClassId = -1;

            if(clsDataLocalDrivingLicenseApplications.GetLDLApplicationInfoByID(LDLApplicationID, ref ApplicationID, ref LicenseClassId))
            {
                clsBussenessApplications Application = clsBussenessApplications.FindBaseApplication(ApplicationID);
                if (Application != null)
                {
                    return new clsBussenessLocBalDrivingLicenseApplications(LDLApplicationID, Application.ApplicationID, Application.ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationTypeID, (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, LicenseClassId);
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }  

        public bool IsLDLApplicationExsistBYID(int LDLApplicationID)
        {
            return clsDataLocalDrivingLicenseApplications.IsLDLApplicationExistById(LDLApplicationID);
        }

        private bool  _AddNewLDLApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsDataLocalDrivingLicenseApplications.AddNewLDLApplication(ApplicationID, LicenseClassID);
            return (LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLDLApplication()
        {
            //call DataAccess Layer 

            return clsDataLocalDrivingLicenseApplications.UpdateLDLApplicatoin(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }

        public bool Save()
        {
            if (base.Save() == false)
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLDLApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLDLApplication();

            }

            return false;
        }
    }
}
