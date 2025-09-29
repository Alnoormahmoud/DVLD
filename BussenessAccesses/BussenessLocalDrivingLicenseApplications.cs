
using DataAccesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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

        public static DataTable GetAllLDLApplications()
        {
            return clsDataLocalDrivingLicenseApplications.GetAllLDLApplications();
        }
        public bool IsThereAnActiveScheduledTest(clsBussenessTestTypes.enTestType TestTypeID)
        {
            return clsDataLocalDrivingLicenseApplications.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassTestType(clsBussenessTestTypes.enTestType TestTypeID)

        {
            return clsDataLocalDrivingLicenseApplications.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(clsBussenessTestTypes.enTestType TestTypeID)

        {
            return clsDataLocalDrivingLicenseApplications.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
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
        public static clsBussenessLocBalDrivingLicenseApplications FindByApplicationID(int ApplicationID)
        {
            // 
            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            if (clsDataLocalDrivingLicenseApplications.GetLDLApplicationInfoByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID))
            {
                clsBussenessApplications Application = clsBussenessApplications.FindBaseApplication(ApplicationID);

                if (Application != null)
                {
                    return new clsBussenessLocBalDrivingLicenseApplications(
                LocalDrivingLicenseApplicationID, Application.ApplicationID,
                Application.ApplicantPersonID,
                                 Application.ApplicationDate, Application.ApplicationTypeID,
                                (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                 Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
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

        public byte TotalTrialsPerTest(clsBussenessTestTypes.enTestType TestTypeID)
        {
            return clsDataLocalDrivingLicenseApplications.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DeleteLDLApplication()
        {

            //call DataAccess Layer 
            if (clsDataLocalDrivingLicenseApplications.DeleteLDLApplication(this.LocalDrivingLicenseApplicationID))
            {
                if (base.DeleteApplication() == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;

            }
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

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }
        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
         //  return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
            return -1;
        }

        public bool Save()
        {
            base.Mode = (clsBussenessApplications.enMode)Mode;
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
