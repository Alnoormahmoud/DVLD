using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using DataAccesses;
using System.Threading.Tasks;

namespace BussenessAccesses
{
    public class clsBussenessApplicationTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int Id { set; get; }
        public string Title { set; get; }
        public decimal Fees { set; get; }

        public clsBussenessApplicationTypes(int Id, string Title, decimal Fees)
        {
            this.Id = Id;
            this.Title = Title;
            this.Fees = Fees;
            Mode = enMode.Update;
        }    
        
        public clsBussenessApplicationTypes()
        {
            this.Id = -1;
            this.Title = "";
            this.Fees = 0;
            Mode = enMode.AddNew;
        }

        public  static  DataTable GetApplicationTtpes()
        {
            return  clsDataApplicationTypesManagement.GetApplicationTtpes();
        }        
        
        public static clsBussenessApplicationTypes GetApplicationTypeByApplicationTypeID(int TypedID)
        {
            string Title = "";
            decimal Fees = 0;
            if( clsDataApplicationTypesManagement.GetApplicationInfoByApplicationTypeID(TypedID,ref Title,ref Fees))
            {
                return new clsBussenessApplicationTypes(TypedID, Title, Fees); 
            }
            return null;
        }

        public static clsBussenessApplicationTypes Find(int ID)
        {
            string Title = ""; decimal  Fees = 0;

            if (clsDataApplicationTypesManagement.GetApplicationTypeInfoByID((int)ID, ref Title, ref Fees))

                return new clsBussenessApplicationTypes(ID, Title, Fees);
            else
                return null;

        }
        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.Id = clsDataApplicationTypesManagement.AddNewApplicationType(this.Title, this.Fees);


            return (this.Id != -1);
        }

        private bool _UpdateApplicationType()
        {
            return clsDataApplicationTypesManagement.UpdateApplicationType(this.Id, this.Title, this.Fees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }

    }
}
