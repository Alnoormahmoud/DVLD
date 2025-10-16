using BussenessAccesses;
using DVLD.Global_Classes;
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

namespace DVLD.Licenses.Detain_License
{
    public partial class frmDetainLicense : Form
    {
        int DetainedLicenseID = -1;
        private int _SelectedLicenseID = -1;

        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetaine_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Detaine this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (txtFineFees.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the fine fees to detain the license.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DetainedLicenseID = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text),  clsGlobal.CurrentUser.UserID);
           
            if (DetainedLicenseID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            lblDetainID.Text = DetainedLicenseID.ToString();
 
            MessageBox.Show("Licensed Detained Successfully with ID = " + DetainedLicenseID.ToString(), "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnDetaine.Enabled = false;
            txtFineFees.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llLicenseInfo.Enabled = true;

        }

        private void llLisenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonInfo.PersonID);
            frm.ShowDialog();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void llLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            llLisenseHistory.Enabled = (_SelectedLicenseID != -1);


            if (_SelectedLicenseID == -1)
            {
                btnDetaine.Enabled = false;
                llLisenseHistory.Enabled = false;

                return;
            }
            lblLicenseID.Text = _SelectedLicenseID.ToString();


            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetaine.Enabled = false;
                return;
            }


            if (ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is already detained.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetaine.Enabled = false;
                return;
            }
         
            btnDetaine.Enabled = true;
            txtFineFees.Focus();
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }
    }
}
