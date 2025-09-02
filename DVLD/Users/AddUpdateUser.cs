using BussenessAccesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DVLD.Users
{
    public partial class AddUpdateUser : Form
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode Mode = enMode.Update;

        clsBussenessUsersManagement _User;

        private int _UserId = -1;
        public AddUpdateUser()
        {
            InitializeComponent();
            txtUserName.Focus();
            Mode = enMode.Add;

        }
        public AddUpdateUser(int id)
        {
            InitializeComponent();
            _UserId = id; 
            Mode = enMode.Update;
        } 
        private void _LoadData()
        {
            _User = clsBussenessUsersManagement.Find(_UserId);
            ucInfoWithFillter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found
            lblUserId.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            cbIsActive.Checked = _User.IsActive;
            ucInfoWithFillter1.LoadPersonInfo(_User.PersonID);
        }
        private void _ResetDefultValues()
        {
            //this will initialize the reset the defaule values

            if (Mode == enMode.Add)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsBussenessUsersManagement();
                tcLoginInfo.Enabled = false;

                ucInfoWithFillter1.FilterFocus();

            }
        
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                tcLoginInfo.Enabled = true;
                btnSave.Enabled = true;


            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Checked = true;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefultValues();
            if (Mode == enMode.Update)
                _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tcLoginInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tcLoginInfo"];
                return;
            }

            //incase of add new mode.
            if (ucInfoWithFillter1.PersonID < 0)
            {
                MessageBox.Show("Find Or Add Person First To Add New User!", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucInfoWithFillter1.FilterFocus();

                return;
            }

            if (clsBussenessUsersManagement.IsUserExistForPersonID(ucInfoWithFillter1.PersonID))
            {

                MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucInfoWithFillter1.FilterFocus();
            }

            else
            {
                btnSave.Enabled = true;
                tcLoginInfo.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages["tcLoginInfo"];
            }
            
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


 
            _User.PersonID = ucInfoWithFillter1.PersonID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = cbIsActive.Checked;



            if (_User.Save())
            {
                lblUserId.Text = _User.UserID.ToString();
                Mode = enMode.Update;

                lblTitle.Text = "Update User Info";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucInfoWithFillter1.FilterEnabled = false;

                return;
            }
            else
            {
                MessageBox.Show("Can't Save User Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "UserName Is Required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }

            if (Mode == enMode.Add)
            {
                if (clsBussenessUsersManagement.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                };
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (clsBussenessUsersManagement.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };
                }
            }
        }

        private bool _ConfirmPassword()
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                return false;
            }
            return true;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Required Filed, Enter User Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!_ConfirmPassword())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation Is Not The Same With The Orignal Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        //private void AddUpdateUser_Activated(object sender, EventArgs e)
        //{
        //    ucInfoWithFillter1.FilterFocus();
        //}
    }
}
