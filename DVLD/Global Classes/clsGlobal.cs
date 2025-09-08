using BussenessAccesses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DVLD.Global_Classes
{
    public class clsGlobal
    {
        static public clsBussenessUsersManagement CurrentUser;

        public static void RememberUsernameAndPassword(string Username, string Password)
        {
            Properties.Settings.Default._UserName = Username;
            Properties.Settings.Default._Password = Password;
            Properties.Settings.Default.Save();
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            if (Properties.Settings.Default._UserName != "" || Properties.Settings.Default._Password != "")
            {
                Username = Properties.Settings.Default._UserName;
                Password = Properties.Settings.Default._Password;
                return true;

            }
            else
            {
                Properties.Settings.Default._UserName = null;
                Properties.Settings.Default._Password = null;
                return false;

            }
        }
    }
}
