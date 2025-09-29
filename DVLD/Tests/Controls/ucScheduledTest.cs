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

namespace DVLD.Tests.Controls
{
    public partial class ucScheduledTest : UserControl
    {
        clsBussenessTestTypes.enTestType _Type;

        int _LDLAppID = -1;
        int _TestID = -1;

        clsBussenessLocBalDrivingLicenseApplications _LDLApplication;

        int _AppointmentID = -1;
        clsBussenssTestAppointments _Appointment;

        public int TestAppointmentID
        {
            get
            {
                return _AppointmentID;
            }
        }

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }

        public ucScheduledTest()
        {
            InitializeComponent();
        }

        public void LoadControl(int AppointmentID, clsBussenessTestTypes.enTestType Type)
        {
            _Type = Type;
            _Appointment = clsBussenssTestAppointments.Find(AppointmentID);
            _AppointmentID = AppointmentID;

            //incase we did not find any appointment .
            if (_Appointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + AppointmentID.ToString(),"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppointmentID  = -1;
                return;
            }

            _LDLAppID = _Appointment.LocalDrivingLicenseApplicationID;
            _LDLApplication = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(_LDLAppID);

            _TestID = _Appointment.TestID;

 

            if (_LDLApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LDLAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblFullName.Text = _LDLApplication.ApplicantFullName;
            lblDrivingClass.Text = _LDLApplication.LicenseClassInfo.ClassName;
            lblTrial.Text = _LDLApplication.TotalTrialsPerTest(_Type).ToString();
            lblFees.Text = _Appointment.PaidFees.ToString();
            lblDate.Text = _Appointment.AppointmentDate.ToString("dd/MM/yyyy");
            lblTestID.Text = (_Appointment.TestID == -1) ? "Not Taken Yet" : _Appointment.TestID.ToString();

        }

    }
}
