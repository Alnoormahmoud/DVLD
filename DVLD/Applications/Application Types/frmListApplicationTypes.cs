using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using BussenessAccesses;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Application.Application_Types;

namespace DVLD.Application.Application_Type
{
    public partial class frmListApplicationTypes : Form
    {
        private static DataTable _ALlApplicationTypesManagemnt;

        public frmListApplicationTypes()
        {
            InitializeComponent();
        }
        
        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _ALlApplicationTypesManagemnt = clsBusseApplicationTypesManagemnt.GetApplicationTtpes();

            dgvUsers.DataSource = _ALlApplicationTypesManagemnt;
            lblRecords.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "Application Type ID";
                dgvUsers.Columns[0].Width = 250;

                dgvUsers.Columns[1].HeaderText = "Type Title";
                dgvUsers.Columns[1].Width = 120;

                dgvUsers.Columns[2].HeaderText = "Type Fees";
                dgvUsers.Columns[2].Width = 300; 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void editTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmEditApplicationType((int)dgvUsers.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            frmListApplicationTypes_Load(null, null);
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new frmEditApplicationType((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListApplicationTypes_Load(null, null);
        }


    }
}
