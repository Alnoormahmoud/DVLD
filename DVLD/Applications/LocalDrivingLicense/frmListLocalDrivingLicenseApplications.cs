using System;
using DVLD.Tests;
using BussenessAccesses;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;
using DVLD.Licenses.Local_Licenses;
using DVLD.Licenses;

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
            _AllLDLApplications  = clsBussenessLocBalDrivingLicenseApplications.GetAllLDLApplications();
            dgvLDLApplications.DataSource = _AllLDLApplications;
            lblRecords.Text = dgvLDLApplications.Rows.Count.ToString();
            if (dgvLDLApplications.Rows.Count > 0)
            {

                dgvLDLApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLDLApplications.Columns[0].Width = 100;

                dgvLDLApplications.Columns[1].HeaderText = "Driving Class";
                dgvLDLApplications.Columns[1].Width = 150;

                dgvLDLApplications.Columns[2].HeaderText = "National No.";
                dgvLDLApplications.Columns[2].Width = 100;

                dgvLDLApplications.Columns[3].HeaderText = "Full Name";
                dgvLDLApplications.Columns[3].Width = 200;

                dgvLDLApplications.Columns[4].HeaderText = "Application Date";
                dgvLDLApplications.Columns[4].Width = 120;

                dgvLDLApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLDLApplications.Columns[5].Width = 80;
            }
            cbFindBty.SelectedIndex = 0;
        }

        private void scheduleTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTestAppointments((int)dgvLDLApplications.CurrentRow.Cells[0].Value, clsBussenessTestTypes.enTestType.VisionTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleTestToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTestAppointments((int)dgvLDLApplications.CurrentRow.Cells[0].Value, clsBussenessTestTypes.enTestType.WrittenTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void scheduleTestToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTestAppointments((int)dgvLDLApplications.CurrentRow.Cells[0].Value, clsBussenessTestTypes.enTestType.StreetTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmLDLApplicationInfo((int)dgvLDLApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }           

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLocalDrivingLicsense((int)dgvLDLApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void cbFindBty_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFindBty.Text != "None");

            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }

            _AllLDLApplications.DefaultView.RowFilter = "";
            lblRecords.Text = dgvLDLApplications.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFindBty.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllLDLApplications.DefaultView.RowFilter = "";
                lblRecords.Text = dgvLDLApplications.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                //in this case we deal with integer not string.
                _AllLDLApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _AllLDLApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecords.Text = dgvLDLApplications.Rows.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase L.D.L.AppID id is selected.
            if (cbFindBty.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected application with id = " + dgvLDLApplications.CurrentRow.Cells[0].Value.ToString() + " ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int LDLAppID = (int)dgvLDLApplications.CurrentRow.Cells[0].Value;

            clsBussenessLocBalDrivingLicenseApplications _LDLApplications = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(LDLAppID);


            if (_LDLApplications != null)
            {
                if (_LDLApplications.DeleteLDLApplication())
                {
                    MessageBox.Show("The Application is Deleted Successfully!", "Application Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                    MessageBox.Show("Error Happened While Deleting the Application!", "Error Happened", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void CancleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancle the selected application with id = " + dgvLDLApplications.CurrentRow.Cells[0].Value.ToString() + " ?", "Confirm Cancle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LDLAppID = (int)dgvLDLApplications.CurrentRow.Cells[0].Value;
            clsBussenessLocBalDrivingLicenseApplications _LDLApplications = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(LDLAppID);
            if (_LDLApplications != null)
            {
                if (clsBussenessLocBalDrivingLicenseApplications.Cancle(_LDLApplications.ApplicationID))
                {
                    MessageBox.Show("The Application is Cancled Successfully!", "Application Cancled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListLocalDrivingLicenseApplications_Load(null, null);
                }
                else
                    MessageBox.Show("Error Happened While Cancling the Application!", "Error Happened", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }
 
        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {
            clsBussenessLocBalDrivingLicenseApplications _LDLApplications = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID((int)dgvLDLApplications.CurrentRow.Cells[0].Value);

            int TotalPassedTests = (int)dgvLDLApplications.CurrentRow.Cells[5].Value;

            bool LicenseExists = _LDLApplications.IsLicenseIssued();

            //Enabled only if person passed all tests and Does not have license. 
            IssueToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;

            showLicenseToolStripMenuItem.Enabled = LicenseExists;
            editToolStripMenuItem.Enabled = !LicenseExists && (_LDLApplications.ApplicationStatus == clsBussenessApplications.enApplicationStatus.New);
            scheduleTestToolStripMenuItem.Enabled = !LicenseExists && _LDLApplications.ApplicationStatus != clsBussenessApplications.enApplicationStatus.Cancelled;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            CancleToolStripMenuItem.Enabled = (_LDLApplications.ApplicationStatus == clsBussenessApplications.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteToolStripMenuItem.Enabled = (_LDLApplications.ApplicationStatus != clsBussenessApplications.enApplicationStatus.Completed);

            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = _LDLApplications.DoesPassTestType(clsBussenessTestTypes.enTestType.VisionTest); ;
            bool PassedWrittenTest = _LDLApplications.DoesPassTestType(clsBussenessTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = _LDLApplications.DoesPassTestType(clsBussenessTestTypes.enTestType.StreetTest);

            scheduleTestToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) 
             && (_LDLApplications.ApplicationStatus == clsBussenessApplications.enApplicationStatus.New);

            if (scheduleTestToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                schedulevisionTestToolStripMenuItem1.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                schedulewrittenTestToolStripMenuItem2.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                schedulestreetTestToolStripMenuItem3.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }

        }

        private void IssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLDLApplications.CurrentRow.Cells[0].Value;
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
            //refresh
            frmListLocalDrivingLicenseApplications_Load(null, null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLDLApplications.CurrentRow.Cells[0].Value;

            int LicenseID = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLDLApplications.CurrentRow.Cells[0].Value;
            clsBussenessLocBalDrivingLicenseApplications localDrivingLicenseApplication = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(LocalDrivingLicenseApplicationID);

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(localDrivingLicenseApplication.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
