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

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        int LocalDrivingLicenseApplicationID;
        clsBussenessLocBalDrivingLicenseApplications LDLApp;

        clsBussenessLicenses License;
        clsBussenessDrivers Driver;
        public frmIssueDriverLicenseFirstTime(int LDL)
        {
            InitializeComponent();
            LocalDrivingLicenseApplicationID = LDL;
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();
            LDLApp = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(LocalDrivingLicenseApplicationID);

            if (LDLApp == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + LocalDrivingLicenseApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            //if (!LDLApp.PassedAllTests())
            //{

            //    MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //    return;
            //}

            int LicenseID = LDLApp.GetActiveLicenseID();
            if (LicenseID != -1)
            {

                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            ucDrivingLicenseApplicationInfo1.LoadAppliactionInfoByLDLAppID(LocalDrivingLicenseApplicationID);
         }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int LicenseID = LDLApp.IssueLicenseForTheFirtTime(txtNotes.Text.Trim(), 19);// clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

 
    }
}
