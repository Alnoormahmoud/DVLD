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
    public partial class frmChangePassword : Form
    {
        private int _UserId = 0;
        private clsBussenessUsersManagement _User;

        public frmChangePassword(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsBussenessUsersManagement.Find(_UserId);

            if (_User != null)
            {
                ucUserInfo1.LoadUserInfo(_User.UserID);
            }
            else
            {
                MessageBox.Show("Cant't Load User Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
         }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_User.Password == txtPassword.Text) 
            {
                MessageBox.Show("Can't Update Password, New Password Cant't Be The Same as The Current One, Enter Another Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtPassword.Text;
            if (_User.Save())
            {
                MessageBox.Show("Password Updated Successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPassword.Text = "";
                txtCurrentPassword.Text = "";
                txtPassword.Clear();
                return;
            }
            else
            {
                MessageBox.Show("Something Went Wrong,Can't Update Password, Tray Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                errorProvider1.SetError(txtPassword, "Required Filed, Enter New Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtCurrent_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Enter Current User Password.");
                return;
            }
            else
            {
                e.Cancel = false;
            }

            if (_User.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Wrong User Password, Enter Correct Current User Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtCurrentPassword, "");
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
 
    }
}
