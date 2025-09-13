using System;
using BussenessAccesses;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicense
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        private DataTable _AllLDLApplications;
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicsense();
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _AllLDLApplications  = clsBussenessApplications.GetAllLDLApplicatinos();
            dgvLDLApplications.DataSource = _AllLDLApplications;
            lblRecords.Text = dgvLDLApplications.Rows.Count.ToString();
 
        }

 
    }
}
