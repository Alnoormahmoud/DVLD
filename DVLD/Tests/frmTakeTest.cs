using BussenessAccesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        clsBussenessTests _Test;

        int _TestAppointmentID = -1;
        clsBussenssTestAppointments _Appointment;

        clsBussenessTestTypes.enTestType _Type;

        public frmTakeTest(int TestAppointmentID, clsBussenessTestTypes.enTestType type)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _Type = type;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ucScheduledTest1.LoadControl(_TestAppointmentID, _Type);

            if (ucScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;


            int _TestID = ucScheduledTest1.TestID;
            if (_TestID != -1)
            {
                _Test = clsBussenessTests.Find(_TestID);

                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                tbNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }

            else
                _Test = new clsBussenessTests();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
              "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No )
            {
                return;
            }

            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.CreatedByUserId = 19;
            _Test.Notes = tbNotes.Text;
            _Test.TestResult = (rbFail.Checked) ? false : true;

            if (_Test.Save())
            {
                _Appointment=clsBussenssTestAppointments.Find(_TestAppointmentID);

                _Appointment.IsLocked = true;

                if (_Appointment.Save())
                    MessageBox.Show("Test Result Saved Successfully");
            }
            else
            {
                MessageBox.Show("Error Saving Test Info");
            }
        }
    }
}
