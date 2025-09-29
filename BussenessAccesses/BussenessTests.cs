using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccesses;


namespace BussenessAccesses
{
    public class clsBussenessTests
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;
        public int TestID { set; get; }
        public int CreatedByUserId { set; get; }
     //   public clsBussenessUsersManagement UserInfo { set; get; }
        public int TestAppointmentID { set; get; }
       public clsBussenssTestAppointments AppointmentInfo { set; get; } 
        public bool  TestResult { set; get; }
        public string Notes { set; get; }

        public clsBussenessTests()
        {
            this.TestID = -1;
            this.CreatedByUserId = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            enMode Mode = enMode.AddNew;
        }
        public clsBussenessTests(int TestID, int CreatedByUserId, int TestAppointmentID, bool TestResult, string Notes)
        {
            this.TestID = -1;
            this.CreatedByUserId = -1;
            this.TestAppointmentID = -1;
            this.AppointmentInfo=clsBussenssTestAppointments.Find(TestAppointmentID);
            this.TestResult = false;
            this.Notes = "";
            enMode Mode = enMode.Update;
        }

 
       
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsDataTests.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }
        private bool _AddNewTest()
        {
            //call DataAccess Layer 

            this.TestID = clsDataTests.AddNewTest(this.CreatedByUserId, this.Notes, this.TestAppointmentID, this.TestResult);
            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return clsDataTests.UpdateTest(this.TestID, this.CreatedByUserId, this.Notes, this.TestAppointmentID, this.TestResult);
        }

        public static clsBussenessTests Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsDataTests.GetTestByTestID(TestID,ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))

                return new clsBussenessTests(TestID, CreatedByUserID,TestAppointmentID, TestResult, Notes);
            else
                return null;

        }

        public static clsBussenessTests FindLastTestPerPersonAndLicenseClass(int PersonID, int LicenseClassID, clsBussenessTestTypes.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsDataTests.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsBussenessTests(TestID, CreatedByUserID, TestAppointmentID, TestResult, Notes);
            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTest();

            }

            return false;
        }

  

    }
}
