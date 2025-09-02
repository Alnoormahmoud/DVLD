using BussenessAccesses;
using DVLD.Global_Classes;
using DVLD.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmListUsers : Form
    {
        private static DataTable _dtAllUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsBussenessUsersManagement.GetAllUsers();

            dgvUsers.DataSource = _dtAllUsers;
            cbFindBty.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
            lblRecords.Text = dgvUsers.Rows.Count.ToString();
            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 110;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 110;

       

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 300;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 170;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new AddUpdateUser();
            frm.ShowDialog();
            frmUsers_Load(null,null);
        }

        private void cbFindBty_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFindBty.Text != "None" && cbFindBty.Text != "Activity");
            cbIsActive.Visible = (cbFindBty.Text == "Activity");

            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFindBty.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Person Name":
                    FilterColumn = "FullName";
                    break;

 

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID" || FilterColumn == "UserID" || FilterColumn == "IsActive")
                //in this case we deal with integer not string.

                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFindBty.Text == "Person ID" || cbFindBty.Text == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new AddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmUsers_Load(null, null);
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
      
            if (cbIsActive.SelectedIndex == 1)
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, 1);

            }   
            else if (cbIsActive.SelectedIndex == 2)
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, 0);

            }
            else
            {
                 _dtAllUsers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new AddUpdateUser();
            frm.ShowDialog();
            frmUsers_Load(null, null);
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new AddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if((dgvUsers.CurrentRow.Cells[0].Value).ToString() == (clsGlobal.CurrentUser.UserID).ToString())
                {
                    MessageBox.Show("Can't Delete This User because it is The Current User.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Perform Delele and refresh

                if (clsBussenessUsersManagement.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmUsers_Load(null, null);
                }

                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserDetailscs((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();   
        }

        private void dgvUsers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new AddUpdateUser();
            frm.ShowDialog();
            frmUsers_Load(null, null);
        }
    }
}