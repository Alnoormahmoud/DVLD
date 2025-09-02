using BussenessAccesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class ucUserInfo : UserControl
    {
        public ucUserInfo()
        {
            InitializeComponent();
        }

        private clsBussenessUsersManagement _User;

     
        public void LoadUserInfo(int UserID)
        {
            _User = clsBussenessUsersManagement.Find(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }
        private void _FillUserInfo()
        {
            ucInfo1.LoadPersonInfo(_User.PersonID);

            if (_User.IsActive )
            {
                lblIsACtive.Text = "Yes";
            }
            else if (_User.IsActive)
            {
                lblIsACtive.Text = "No";
            }
            else
            {
                lblIsACtive.Text = "UnKnowen";

            }

            lblUserName.Text = _User.UserName;
            lblUserId.Text = _User.UserID.ToString();
        }
        private void _ResetPersonInfo()
        {

            ucInfo1.ResetPersonInfo();
            lblUserId.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsACtive.Text = "[???]";
        }

    }
}
