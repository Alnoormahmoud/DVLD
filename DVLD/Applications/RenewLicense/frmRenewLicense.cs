using BussenessAccesses;
using DVLD.Licenses;
using DVLD.Licenses.Local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.RenewLicense
{
    public partial class frmRenewLicense : Form
    {
        int NewLicenseID = -1;
 
        public frmRenewLicense()
        {
            InitializeComponent();
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedByUser.Text = "UnKnowen";// clsGlobal.CurrentUser.UserName;

            lblApplicationFees.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.RenewDrivingLicense).Fees.ToString();

            lblIssueDate.Text = lblApplicationDate.Text;
  
        }

        private void btnrenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsBussenessLicenses NewLicense = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(19, txtNotes.Text.Trim());

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID = " + NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnrenew.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llLicenseInfo.Enabled = true;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(NewLicenseID);
            frm.ShowDialog();
        }

        private void llLisenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void frmRenewLicense_Activated(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SElectedID = obj;
            llLisenseHistory.Enabled = (SElectedID != -1);    

            if (SElectedID == -1)
            {
                btnrenew.Enabled = false;
                llLisenseHistory.Enabled = false;

                return;
            }

            lblOldLicenseID.Text = SElectedID.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(clsBussenessLicenseClasses.Find(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID).DefaultValidityLength).ToString("dd/MM/yyyy");
            lblLicenseFees.Text = (clsBussenessLicenseClasses.Find(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID).ClassFees).ToString();
            lblTotalFees.Text = (clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.RenewDrivingLicense).Fees + clsBussenessLicenseClasses.Find(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID).ClassFees).ToString();
            txtNotes.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;

            //check the license is not Expired.
            if (!ucDriverLicenseInfoWithFilter1 .SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license." , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnrenew.Enabled = false;
                return;
            }

            if (ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate > DateTime.Now) 
            {
                MessageBox.Show("The selected license is not expired yet, you can not renew it.", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnrenew.Enabled = true;
 
        }
    }
}
