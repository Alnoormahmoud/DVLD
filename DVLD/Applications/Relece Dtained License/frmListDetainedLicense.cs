using BussenessAccesses;
using DVLD.Licenses;
using DVLD.Licenses.Detain_License;
using DVLD.Licenses.International_License;
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
    public partial class frmListDetainedLicense : Form
    {
        DataTable AllDetainedLicenses;
        clsBussenessLicenses LicenseInfo;
        int PersonID = -1;

        public frmListDetainedLicense()
        {
            InitializeComponent();
        }

        private void frmListDetainedLicense_Load(object sender, EventArgs e)
        {
            AllDetainedLicenses =  clsBuessenessDetainedLicenses.GetAllDetainedLicenses();
            dgvDeyainedLicenses.DataSource = AllDetainedLicenses;
            lblRecords.Text = AllDetainedLicenses.Rows.Count.ToString();

            cbFindBty.SelectedIndex = 0;
            if (dgvDeyainedLicenses.Rows.Count > 0)
            {
                dgvDeyainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDeyainedLicenses.Columns[0].Width = 55;

                dgvDeyainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDeyainedLicenses.Columns[1].Width = 55;

                dgvDeyainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDeyainedLicenses.Columns[2].Width = 130;

                dgvDeyainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDeyainedLicenses.Columns[3].Width = 110;

                dgvDeyainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDeyainedLicenses.Columns[4].Width = 110;

                dgvDeyainedLicenses.Columns[5].HeaderText = "R.Date";
                dgvDeyainedLicenses.Columns[5].Width = 130;

                dgvDeyainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDeyainedLicenses.Columns[6].Width = 60;

                dgvDeyainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDeyainedLicenses.Columns[7].Width = 200;

                dgvDeyainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDeyainedLicenses.Columns[8].Width = 140;

            }
        }

        private void cbFindBty_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (cbFindBty.Text == "Is Released")
            {
                txtFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
            }
            else
            {

                txtFilter.Visible = (cbFindBty.Text != "None");
                cbIsActive.Visible = false;

                if (cbFindBty.Text == "None")
                {
                    txtFilter.Visible = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    txtFilter.Visible = true;

                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                AllDetainedLicenses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                AllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecords.Text = dgvDeyainedLicenses.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFindBty.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    };

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                AllDetainedLicenses.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDeyainedLicenses.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                AllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                AllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecords.Text = dgvDeyainedLicenses.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFindBty.Text == "Detain ID" || cbFindBty.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LicenseInfo=clsBussenessLicenses.FindLicenseByLicenseId((int)dgvDeyainedLicenses.CurrentRow.Cells[1].Value);
            PersonID = LicenseInfo.DriverInfo.PersonInfo.PersonID;

            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseInfo = clsBussenessLicenses.FindLicenseByLicenseId((int)dgvDeyainedLicenses.CurrentRow.Cells[1].Value);
            PersonID = LicenseInfo.DriverInfo.PersonInfo.PersonID;

            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseInfo = clsBussenessLicenses.FindLicenseByLicenseId((int)dgvDeyainedLicenses.CurrentRow.Cells[1].Value);
            PersonID = LicenseInfo.DriverInfo.PersonInfo.PersonID;

            frmShowPersonLicenseHistory frmShowInternationalLicenseInfo = new frmShowPersonLicenseHistory(PersonID);
            frmShowInternationalLicenseInfo.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frmShowLicenseInfo = new frmShowLicenseInfo((int)dgvDeyainedLicenses.CurrentRow.Cells[1].Value);
            frmShowLicenseInfo.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            frmListDetainedLicense_Load(null,null); 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {      
            frmReliseDetainedLicense frm = new frmReliseDetainedLicense();
            frm.ShowDialog();
            frmListDetainedLicense_Load(null, null);
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReliseDetainedLicense frm = new frmReliseDetainedLicense(((int)dgvDeyainedLicenses.CurrentRow.Cells[1].Value));
            frm.ShowDialog();
            frmListDetainedLicense_Load(null, null);

        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDeyainedLicenses.CurrentRow.Cells[3].Value;

        }

    }
}
