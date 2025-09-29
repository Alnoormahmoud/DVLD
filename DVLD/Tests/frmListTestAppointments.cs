using BussenessAccesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BussenessAccesses.clsBussenessTestTypes;


namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {
        DataTable _AllAppointements;

        int _LDLAppID = -1;
        clsBussenessTestTypes.enTestType _Type;
        public frmListTestAppointments(int LDLAppID, clsBussenessTestTypes.enTestType Type)
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _Type = Type;
        }

        private void _LoadTypeandImage()
        {
            switch(_Type)
            {
                case clsBussenessTestTypes.enTestType.VisionTest:

                    pbTestAppointmentmage.Image = Properties.Resources.Vision_512;
                    lblTitle.Text = "Vision Test Appointments";
                    this.Text = "Vision Test Appointments";
                    break;
                case clsBussenessTestTypes.enTestType.WrittenTest:
                    pbTestAppointmentmage.Image = Properties.Resources.Written_Test_512;
                    lblTitle.Text = "Written Test Appointments";
                    this.Text = "Written Test Appointments";
                    break;
                case clsBussenessTestTypes.enTestType.StreetTest:
                    pbTestAppointmentmage.Image = Properties.Resources.Street_Test_32;
                    lblTitle.Text = "Street Test Appointments";
                    this.Text = "Street Test Appointments";
                    break;
            }
 

        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTypeandImage();

            ucDrivingLicenseApplicationInfo1.LoadAppliactionInfoByLDLAppID(_LDLAppID);
            _AllAppointements = clsBussenssTestAppointments.GetApplicationTestAppointmentsPerTestType(_LDLAppID, _Type);

            dgvAppointments.DataSource = _AllAppointements;
            lblRecords.Text = dgvAppointments.Rows.Count.ToString();

            if (dgvAppointments.Rows.Count > 0)
            {

                dgvAppointments.Columns[0].HeaderText = "[Test Appointment ID]";
                dgvAppointments.Columns[0].Width = 200;

                dgvAppointments.Columns[1].HeaderText = "[Appointment Date]";
                dgvAppointments.Columns[1].Width = 200;


                dgvAppointments.Columns[2].HeaderText = "[Paid Fees]";
                dgvAppointments .Columns[2].Width = 150;

                dgvAppointments.Columns[3].HeaderText = "[Is Locked]";
                dgvAppointments.Columns[3].Width = 150;

 
            }

        } 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbTakeTest_Click(object sender, EventArgs e)
        {
            clsBussenessLocBalDrivingLicenseApplications localDrivingLicenseApplication = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(_LDLAppID);

            if(localDrivingLicenseApplication.DoesPassTestType(_Type))
            {
                MessageBox.Show("This person already passed this test, you cannot retake it", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_Type))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
 
            frmScheduleTest frm1 = new frmScheduleTest(_LDLAppID, _Type);
            frm1.ShowDialog();
            frmListTestAppointments_Load(null, null);
 
        } 

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            Form frm = new frmTakeTest(TestAppointmentID, _Type);
            frm.ShowDialog();

            frmListTestAppointments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            Form frm = new frmScheduleTest(_LDLAppID, _Type, TestAppointmentID);
            frm.ShowDialog();

            frmListTestAppointments_Load(null,null);
        }
    }
}
