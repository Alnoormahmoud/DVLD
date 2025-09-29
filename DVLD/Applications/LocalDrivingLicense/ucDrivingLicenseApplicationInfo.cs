using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussenessAccesses;
 using static System.Net.Mime.MediaTypeNames;
using DVLD.Tests;
using DVLD.Applications.Controls;

 namespace DVLD.Applications.LocalDrivingLicense
{
    public partial class ucDrivingLicenseApplicationInfo : UserControl
    {
        int LDLAPPID = -1;
        private int _LicenseID;
        public int LOCALDrivingLicenseApplicationID
        {
            get { return LDLAPPID; }

        }

        clsBussenessLocBalDrivingLicenseApplications LDLApplication;
        public ucDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _FillLDLApplicationInfo()
        {
            //_LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            ////incase there is license enable the show link.
            //llShowLicenceInfo.Enabled = (_LicenseID != -1);

            LDLAPPID = LDLApplication.LocalDrivingLicenseApplicationID;

            lblLDLAppliId.Text = LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = LDLApplication.LicenseClassInfo.ClassName;
            lblPassedtests.Text = clsBussenessTests.GetPassedTestCount(LDLApplication.LocalDrivingLicenseApplicationID).ToString()+ "/3";
            ucApplicationBasicInfo1.LoadApplicationInfo(LDLApplication.ApplicationID);
        }
        public void LoadAppliactionInfoByLDLAppID(int LDLAppId)
        {
            LDLApplication = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(LDLAppId);
            if (LDLApplication == null)
            {
                MessageBox.Show("Error, Cant't load application info", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                _FillLDLApplicationInfo();
            }
        }
        public void LoadAppliactionInfoByApplicationID(int AppId)
        {
            LDLApplication = clsBussenessLocBalDrivingLicenseApplications.FindByApplicationID(AppId);
            if (LDLApplication == null)
            {
                MessageBox.Show("Error, Cant't load application info", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                _FillLDLApplicationInfo();
            }
         }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmShowLicenseInfo frm = new frmShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            //frm.ShowDialog();
        }

        private void ucDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ucApplicationBasicInfo1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
