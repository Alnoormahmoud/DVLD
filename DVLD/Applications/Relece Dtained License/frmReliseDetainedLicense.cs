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

namespace DVLD.Applications.Relece_Dtained_License
{
    public partial class frmReliseDetainedLicense : Form
    {
        int DetainedLicensesID = -1;
         enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;
        public frmReliseDetainedLicense()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        } 
        
        public frmReliseDetainedLicense(int DetainedLicensesId)
        {
            InitializeComponent();
            DetainedLicensesID = DetainedLicensesId;
            Mode = enMode.Update;

        }

        private void frmReliseDetainedLicense_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
                ucDriverLicenseInfoWithFilter1.LoadLicenseInfo(DetainedLicensesID);
                ucDriverLicenseInfoWithFilter1_OnLicenseSelected(DetainedLicensesID);
            }
        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            DetainedLicensesID = obj;
            llLisenseHistory.Enabled = (DetainedLicensesID != -1);


            if (DetainedLicensesID == -1)
            {
                btnDetaine.Enabled = false;
                llLisenseHistory.Enabled = false;

                return;
            }
            lblLicenseID.Text = DetainedLicensesID.ToString();


            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetaine.Enabled = false;
                return;
            }


            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is Not detained.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetaine.Enabled = false;
                return;
            }

            lblLicenseID.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            lblFineFees.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblApplicationFees.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblTotalFees.Text = (int)ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees +
                clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.ReleaseDetainedDrivingLicsense).Fees + "";
            lblDetainDate.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToString("yyyy-MM-dd");
            lblCreatedByUser.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainID.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();

            btnDetaine.Enabled = true;
        }

        private void btnDetaine_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Released this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;

            bool IsReleased = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(ref ApplicationID,clsGlobal.CurrentUser.UserID);

            if (!IsReleased)
            {
                MessageBox.Show("Faild to Released License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblAplicationID.Text = ApplicationID.ToString();

            MessageBox.Show("Licensed Realesed Successfully with Application ID = " + ApplicationID.ToString(), "License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetaine.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llLicenseInfo.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llLisenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonId = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonId);
            frm.ShowDialog();
        }

        private void llLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(DetainedLicensesID);
            frm.ShowDialog();
        }

        private void frmReliseDetainedLicense_Activated(object sender, EventArgs e)
        {
            if(Mode == enMode.AddNew)

                ucDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void ucDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
