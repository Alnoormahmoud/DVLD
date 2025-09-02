using BussenessAccesses;
using DVLD.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmLoggIncs : Form
    {
        public frmLoggIncs()
        {
            InitializeComponent();
        }

        private clsBussenessUsersManagement _CurrentUser;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _CurrentUser = clsBussenessUsersManagement.FindByUserNamAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (_CurrentUser == null)
            {
                MessageBox.Show("Wrong UserName/Password, Enter Correct UserName And Password. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
            else
            {
                if (!_CurrentUser.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                clsGlobal.CurrentUser = _CurrentUser;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
                txtUserName.Focus();
            }

            //clsBussenessUsersManagement user = clsBussenessUsersManagement.FindByUserNamAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            //if (user != null)
            //{

            //    if (cbRememberme.Checked)
            //    {
            //        //store username and password
            //        clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            //    }
            //    else
            //    {
            //        //store empty username and password
            //        clsGlobal.RememberUsernameAndPassword("", "");

            //    }

            //    //incase the user is not active
            //    if (!user.IsActive)
            //    {

            //        txtUserName.Focus();
            //        MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    clsGlobal.CurrentUser = user;
            //    this.Hide();
            //    frmMain frm = new frmMain(this);
            //    frm.ShowDialog();


            //}
            //else
            //{
            //    txtUserName.Focus();
            //    MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "User Name Is Required, Enter UserName");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password Is Required Enter a Password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void frmLoggIncs_Load(object sender, EventArgs e)
        {
            //string UserName = "", Password = "";

            //if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            //{
            //    txtUserName.Text = UserName;
            //    txtPassword.Text = Password;
            //    cbRememberme.Checked = true;
            //}
            //else
            //    cbRememberme.Checked = false;
        }
    }
}
