using BussenessAccesses;
using DVLD.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();
        }

        DataTable _AllDrivers;

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            cbFindBty.SelectedIndex = 0;
            _AllDrivers = clsBussenessDrivers.GetAllDrivers();
            dgvDrivers.DataSource = _AllDrivers;
            lblRecords.Text = dgvDrivers.Rows.Count.ToString();
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 110;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 110;

                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 130;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 270;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 140;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFindBty.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllDrivers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDrivers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                _AllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _AllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecords.Text = _AllDrivers.Rows.Count.ToString();
        }

        private void cbFindBty_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFindBty.Text != "None");


            if (cbFindBty.Text == "None")
            {
                txtFilter.Enabled = false;
            }
            else
                txtFilter.Enabled = true;

            txtFilter.Text = "";
            txtFilter.Focus();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFindBty.Text == "Driver ID" || cbFindBty.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvLDLApplications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
            //refresh
            frmListDrivers_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
            //refresh
            frmListDrivers_Load(null, null);
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet.");
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
