using BussenessAccesses;
using DVLD.Global_Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

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

 

            clsBussenessUsersManagement user = clsBussenessUsersManagement.FindByUserNamAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {

                if (cbRememberme.Checked)
                {
                    //store username and password
                    //clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                    // Specify the Registry key and path
                    string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\DVLD_Credintials";
                    string valueName = "UserName";
                    string valueData = txtUserName.Text.Trim();
                    string valueName1 = "Password";
                    string valueData1 = txtPassword.Text.Trim();

                    try
                    {
                        // Write the value to the Registry
                        Registry.SetValue(keyPath, valueName, valueData ,RegistryValueKind.String);
                        Registry.SetValue(keyPath, valueName1, valueData1, RegistryValueKind.String);


                        //Console.WriteLine($"Value {valueName} successfully written to the Registry.");
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine($"An error occurred: {ex.Message}");
                    }

                }
                else
                {
                    //store empty username and password
                    //clsGlobal.RememberUsernameAndPassword("", "");

                    // Specify the Registry key and path
                    string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\DVLD_Credintials";

                    Registry.SetValue(keyPath, "UserName", "", RegistryValueKind.String);
                    Registry.SetValue(keyPath, "Password", "", RegistryValueKind.String);


                }

                //incase the user is not active
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();

            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\DVLD_Credintials";
            string valueName = "UserName";
            string valueName1 = "Password";


            try
            {
                // Read the value from the Registry
                string value = Registry.GetValue(keyPath, valueName, "") as string;
                string value1 = Registry.GetValue(keyPath, valueName1, "") as string;


                if (value != "" && value1 != "")
                {
                    txtUserName.Text = value;
                    txtPassword.Text = value1;
                    cbRememberme.Checked = true;
                }
                else
                {
                    cbRememberme.Checked = false;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
      
    }
}
