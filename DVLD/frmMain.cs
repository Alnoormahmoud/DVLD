using BussenessAccesses;
using DVLD.Application.Application_Type;
using DVLD.Applications.InternationalLicense;
using DVLD.Applications.LocalDrivingLicense;
using DVLD.Applications.Relece_Dtained_License;
using DVLD.Applications.RenewLicense;
using DVLD.Applications.ReplaceLicense;
using DVLD.Drivers;
using DVLD.Global_Classes;
using DVLD.Licenses.Detain_License;
using DVLD.Tests.Tests_Types;
using DVLD.Users;
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
    public partial class frmMain : Form
    {
        private clsBussenessUsersManagement _CurrentUser;

        frmLoggIncs _frmLogin;

        public frmMain(frmLoggIncs frm)
        {
            InitializeComponent();
            _CurrentUser = clsGlobal.CurrentUser;
            _frmLogin = frm;

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm2 = new frmListPeople();

            frm2.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();

            frm.ShowDialog();
        }
 
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword(_CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void currentUserInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserDetailscs(_CurrentUser.UserID);
            frm.ShowDialog();
        }
 
        private void frmMain_Load(object sender, EventArgs e)
        {
         //   this.BackColor = Color.White;
           // lblLoggedInUser.Text = "LoggedIn User: " + clsGlobal.CurrentUser.UserName;
            this.Refresh();
        }
 
        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form  frm = new frmListTestsTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicsense();
            frm.ShowDialog();
        }

        private void localDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void drToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void internatioalDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses frm = new frmListInternationalLicenses();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense frm = new frmRenewLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDemagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmReplaceLicenseDamagedOrLostLicense frm = new frmReplaceLicenseDamagedOrLostLicense();
            frm.ShowDialog();
        }

        private void realeseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReliseDetainedLicense frm = new frmReliseDetainedLicense();
            frm.ShowDialog();
        }

        private void jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicense frm = new frmListDetainedLicense();
            frm.ShowDialog();
        }

        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReliseDetainedLicense frm = new frmReliseDetainedLicense();
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}