using BussenessAccesses;
using DVLD.Global_Classes;
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
using static BussenessAccesses.clsBussenessLicenses;

namespace DVLD.Applications.ReplaceLicense
{
    public partial class frmReplaceLicenseDamagedOrLostLicense : Form
    {
        int NewLicenseID = -1;
        public frmReplaceLicenseDamagedOrLostLicense()
        {
            InitializeComponent();
        }

        private void frmReplaceLicenseDamagedOrLostLicense_Load(object sender, EventArgs e)
        {
            rbDamagedLicense.Checked = true;
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(NewLicenseID);
            frm.ShowDialog();
        }

        private void frmReplaceLicenseDamagedOrLostLicense_Activated(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            NewLicenseID = obj;

            llShowLicenseHistory.Enabled = (NewLicenseID != -1);


            lblOldLicenseID.Text = NewLicenseID.ToString();


            if (NewLicenseID == -1)
            {
                return;
            }


            //check the license is not Expired.
            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }
 

            btnIssueReplacement.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replace this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsBussenessApplications.enApplicationType AppType = (rbLostLicense.Checked) ? clsBussenessApplications.enApplicationType.ReplaceLostDrivingLicense : clsBussenessApplications.enApplicationType.ReplaceDamagedDrivingLicense;

            clsBussenessLicenses NewLicense = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReplaceLicense(clsGlobal.CurrentUser.UserID, _GetIssueReason());

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Replace the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            NewLicenseID = NewLicense.LicenseID;
            lblRreplacedLicenseID.Text = NewLicenseID.ToString();

            MessageBox.Show("Licensed Replaced Successfully with ID = " + NewLicenseID.ToString(), "License Replacement", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueReplacement.Enabled = false;
            gbReplacementFor.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Damaged License";
            this.Text = lblTitle.Text;

            if (rbLostLicense.Checked)
            {

                lblApplicationFees.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.ReplaceLostDrivingLicense).Fees.ToString();
            }
            else
            {
                lblApplicationFees.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString();
            }
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement for Lost License";
            this.Text = lblTitle.Text;
            if (rbLostLicense.Checked)
            {

                lblApplicationFees.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.ReplaceLostDrivingLicense).Fees.ToString();
            }
            else
            {
                lblApplicationFees.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString();
            }
        }
        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rbDamagedLicense.Checked)

                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

    }
}
