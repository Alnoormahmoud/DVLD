using DataAccesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussenessAccesses
{
    public class clsBussenessTestTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public clsBussenessTestTypes.enTestType TestID { set; get; }
        public string TestTile { set; get; }
        public string TestDescription { set; get; }
        public decimal TestFees { set; get; }
        public clsBussenessTestTypes(clsBussenessTestTypes.enTestType TestID, string TestTile, string TestDescription, decimal TestFees)
        {
            this.TestID = TestID;
            this.TestTile = TestTile;
            this.TestDescription = TestDescription;
            this.TestFees = TestFees;
            Mode = enMode.Update;
        }
        public clsBussenessTestTypes()
        {
            this.TestID = enTestType.VisionTest;
            this.TestTile = "";
            this.TestDescription = "";
            this.TestFees = 0;
            Mode = enMode.AddNew;
        }
        public static DataTable GetAllTestsTypes()
        {
            return DataTestsTypes.GetAllTestsTypes();
        }
        public static clsBussenessTestTypes GetTestTypeByID(clsBussenessTestTypes.enTestType TestTypeID)
        {
            string Title = "";
            string Description = "";
            decimal Fees = 0;

            if ( DataTestsTypes.GetTestInfoByID((int) TestTypeID, ref Title, ref Description, ref Fees))
            {
                return new clsBussenessTestTypes(TestTypeID, Title, Description, Fees);
            }
            return null;
        }
        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.TestID = (enTestType) DataTestsTypes.AddNewTestType(this.TestTile,this.TestDescription, this.TestFees);


            return (this.TestTile != "");
        }
        private bool _UpdateTestType()
        {
            return DataTestsTypes.UpdateTestsType((int) this.TestID, this.TestTile,this.TestDescription, this.TestFees);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }
    }
}
