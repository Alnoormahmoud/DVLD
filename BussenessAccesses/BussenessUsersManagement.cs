using DataAccesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussenessAccesses
{
    public class clsBussenessUsersManagement
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public clsBussenessPeopleManegement PersonInfo;

        public int UserID { set; get; }
        public int PersonID { set; get; } 
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool IsActive { set; get; }
 
        public  clsBussenessUsersManagement()

        {
            this.UserID = -1;
             this.UserName = "";
            this.Password = "";
            this.IsActive = true;

            Mode = enMode.AddNew;
        }

        public clsBussenessUsersManagement(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo = clsBussenessPeopleManegement.Find(PersonID);

            Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsDataUseresManagement.GetAllUsers();
        }

        public static clsBussenessUsersManagement FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsDataUseresManagement.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsBussenessUsersManagement(UserID, UserID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsBussenessUsersManagement Find(int UserId)
        {

            string UserName = "", Password = "";
            int PersonId = -1;
            bool IsActive = true;

            bool IsFound = clsDataUseresManagement.GetUsernfoByID(UserId, ref PersonId, ref UserName, ref Password, ref IsActive);                                

            if (IsFound)
                //we return new object of that person with the right data
                return new clsBussenessUsersManagement( UserId, PersonId, UserName, Password, IsActive );
               
            else
                return null;
        }
        public static clsBussenessUsersManagement FindByUserNamAndPassword(string UserName,string Password)
        {
            int PersonId = -1, UserId = -1;
            bool IsActive = true;

            bool IsFound = clsDataUseresManagement.GetUsernfoByUserNameAndPassword(UserName, Password, ref PersonId, ref UserId, ref IsActive);                                

            if (IsFound)
                //we return new object of that person with the right data
                return new clsBussenessUsersManagement( UserId, PersonId, UserName, Password, IsActive );
               
            else
                return null;
        }

        public static bool IsUserExistForPersonID(int PersonId)
        {
            return clsDataUseresManagement.IsUserExistForPersonID(PersonId);
        }

        public static bool isUserExist(string UserName)
        {
            return clsDataUseresManagement.IsUserExist(UserName);
        }
        
        public static bool isUserExist(int UserID)
        {
            return clsBussenessUsersManagement.isUserExist(UserID);
        }
        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsDataUseresManagement.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);            

            return (this.PersonID != -1);
        }

        private bool _UpdateUser()
        {
            //call DataAccess Layer 
            return clsDataUseresManagement.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }

        public static bool DeleteUser(int ID)
        {
            return clsDataUseresManagement.DeleteUser(ID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }
    }

}
