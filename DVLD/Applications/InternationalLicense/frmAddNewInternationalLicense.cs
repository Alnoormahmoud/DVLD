using BussenessAccesses;
using DVLD.Global_Classes;
using DVLD.Licenses;
using DVLD.Licenses.International_License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.InternationalLicense
{
    public partial class frmAddNewInternationalLicense : Form
    {
        int LicenseID = -1;

        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
        }  
        
 
        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();//add one year.
            lblFees.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblCreatedByUser.Text = "UnKnowen";// clsGlobal.CurrentUser.UserName;
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void llLisenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsBuessenessInternationalLicenses InternationalLicense = new clsBuessenessInternationalLicenses();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicantPersonID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsBussenessApplications.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.NewInternationalLicense).Fees;
            InternationalLicense.CreatedByUserID = 19;// clsGlobal.CurrentUser.UserID;


            InternationalLicense.DriverID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            InternationalLicense.CreatedByUserID = 19;// clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            LicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnClose.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llLicenseInfo.Enabled = true;
        }

        private void frmAddNewInternationalLicense_Activated(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

        }
 

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();

            llLisenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)

            {
                return;
            }


            //check the license class, person could not issue international license without having
            //normal license of class 3.

            if (ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnClose.Enabled = false;
                llLicenseInfo.Enabled = false;

                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsBuessenessInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llLicenseInfo.Enabled = true;
                LicenseID = ActiveInternaionalLicenseID;
                btnClose.Enabled = false;
                return;
            }

            btnClose.Enabled = true;
        }
    }
}
