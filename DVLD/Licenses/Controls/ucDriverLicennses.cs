using BussenessAccesses;
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

namespace DVLD.Licenses.Controls
{
    public partial class ucDriverLicennses : UserControl
    {

        int DriverID = -1;

        DataTable AllLocalLicenses, AllInternationalLicenses;
        clsBussenessDrivers Driver;
        public ucDriverLicennses()
        {
            InitializeComponent();
        }


        private void _LoadLocalLicenseInfo()
        {

            AllLocalLicenses = clsBussenessDrivers.GetAllLocalLicensesForADriver(DriverID);


            dgvLocalLicensesHistory.DataSource = AllLocalLicenses;
            lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[0].Width = 100;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 100;

                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[2].Width = 230;

                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[3].Width = 190;

                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[4].Width = 190;

                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicensesHistory.Columns[5].Width = 100;

            }
        }

        private void _LoadInternationalLicenseInfo()
        {

            AllInternationalLicenses = clsBussenessDrivers.GetAllInternationalLicensesForADriver(DriverID);

             
            dgvInternationalLicensesHistory.DataSource = AllInternationalLicenses;
            lblInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 140;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 140;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[2].Width = 220;

                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[3].Width = 160;

                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[4].Width = 160;

                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicensesHistory.Columns[5].Width = 90;

            }
        }

        private void ucDriverLicennseInfo_Load(object sender, EventArgs e)
        {


        }


        public void Clear()
        {
            AllLocalLicenses.Clear();

        }
        public void LoadLicensesInfo(int DriverId)
        {
            DriverID = DriverId;
            Driver = clsBussenessDrivers.FindDriverByDriverId(DriverId);

            _LoadInternationalLicenseInfo();
            _LoadLocalLicenseInfo();
        }

        public void LoadInfoByPersonID(int PersonID)
        {

            Driver = clsBussenessDrivers.FindDriverByPersonId(PersonID);
            if (Driver != null)
            {
                DriverID = clsBussenessDrivers.FindDriverByPersonId(PersonID).DriverID;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int InternationalLicenseID = (int)dgvInternationalLicensesHistory.CurrentRow.Cells[0].Value;
            //frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            //frm.ShowDialog();
        }

        private void tpLocalLicenses_Click(object sender, EventArgs e)
        {

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;
            Form frm = new frmShowLicenseInfo(LicenseID);
             frm.ShowDialog();
        }
    }
}
