using BussenessAccesses;
using DVLD.Application.Application_Type;
using DVLD.Application.Application_Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests.Tests_Types
{
    public partial class frmListTestsTypes : Form
    {            
        private static DataTable _AllTestsTypes;

        public frmListTestsTypes()
        {
            InitializeComponent();

        }

        private void frmListTestsTypes_Load(object sender, EventArgs e)
        {
            _AllTestsTypes = clsBussenessTestTypesManagement.GetAllTestsTypes();

            dgvUsers.DataSource = _AllTestsTypes;
            lblRecords.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "Test ID";
                dgvUsers.Columns[0].Width = 120;

                dgvUsers.Columns[1].HeaderText = "Test Title";
                dgvUsers.Columns[1].Width = 170;

                dgvUsers.Columns[2].HeaderText = "Test Description";
                dgvUsers.Columns[2].Width = 270;

                dgvUsers.Columns[3].HeaderText = "Test Fees";
                dgvUsers.Columns[3].Width = 150;
            }
        } 
 
        private void editTypeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form form = new frmUpdateTestTypes((clsBussenessTestTypesManagement.enTestType)dgvUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            frmListTestsTypes_Load(null, null);
        }

        private void dgvUsers_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new frmUpdateTestTypes((clsBussenessTestTypesManagement.enTestType)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestsTypes_Load(null, null);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
