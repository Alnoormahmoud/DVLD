using BussenessAccesses;
using DVLD.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.Tests.Controls.ucScheduleTest;

namespace DVLD.Tests.Controls
{
    public partial class ucScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public enum enCreationMode { NewAppointment = 0, RetakeTest = 1 };
        enCreationMode CreationMode = enCreationMode.NewAppointment;

        private clsBussenessTestTypes.enTestType _Type = clsBussenessTestTypes.enTestType.VisionTest;


        private clsBussenessLocBalDrivingLicenseApplications _LDLApplication;
        private int _LDLApplicationID = -1;

        int _AppointmentID = -1;
        clsBussenssTestAppointments _Appointment;

        public clsBussenessTestTypes.enTestType TestType
        {
            get { return _Type; }

            set
            {
                _Type = value;

                switch (_Type)
                {
                    case clsBussenessTestTypes.enTestType.VisionTest:
                        groupBox1.Text = "Vision Test";
                        pbTestTypeImage.Image = DVLD.Properties.Resources.Vision_512;
                        break;
                    case clsBussenessTestTypes.enTestType.WrittenTest:
                        groupBox1.Text = "Written Test";
                        pbTestTypeImage.Image = DVLD.Properties.Resources.Written_Test_512;

                        break;

                    case clsBussenessTestTypes.enTestType.StreetTest:
                        groupBox1.Text = "Street Test";
                        pbTestTypeImage.Image = DVLD.Properties.Resources.Street_Test_32;

                        break;

                }
            }
        }

        public ucScheduleTest()
        {
            InitializeComponent();
        }

        public void LoadControl(int LDLAppID, int AppointmentID = -1)
        {
            if(AppointmentID == -1)
                Mode = enMode.AddNew;             
            else          
                Mode = enMode.Update;

            _LDLApplicationID = LDLAppID;
            _AppointmentID = AppointmentID;
            _LDLApplication = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(_LDLApplicationID);

            if(_LDLApplication == null)
            {
                MessageBox.Show("Error in loading application info For LDLApplicationID "+(_LDLApplicationID).ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;

                return;
            }

            if (_LDLApplication.DoesAttendTestType(_Type))
                CreationMode = enCreationMode.RetakeTest;
            else
                CreationMode = enCreationMode.NewAppointment;


            if (CreationMode == enCreationMode.RetakeTest)
            {
                lblRetakeAppFees.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTestInfo.Enabled = (CreationMode == enCreationMode.RetakeTest);
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                lblRetakeAppFees.Text = "0";
                gbRetakeTestInfo.Enabled = (CreationMode == enCreationMode.RetakeTest);
                lblTitle.Text = "Schedule Test";
                lblRetakeTestAppID.Text = "N/A";
            }


            lblLocalDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblFullName.Text = _LDLApplication.ApplicantFullName;
            lblDrivingClass.Text = _LDLApplication.LicenseClassInfo.ClassName;

            lblTrial.Text = _LDLApplication.TotalTrialsPerTest(_Type).ToString();

            if (Mode == enMode.AddNew)
            {
                lblFees.Text = clsBussenessTestTypes.GetTestTypeByID(_Type).TestFees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                dtpTestDate.Value = DateTime.Now.AddDays(1);
                lblRetakeTestAppID.Text = "N/A";

                _Appointment = new clsBussenssTestAppointments();
            }

            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }
            lblTotalFees.Text= (Convert.ToSingle(lblFees.Text)+(Convert.ToSingle(lblRetakeAppFees.Text)).ToString());

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;

        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (Mode == enMode.AddNew && _LDLApplication.IsThereAnActiveScheduledTest( _Type))
            {
                lblUserMessage.Visible = true;

                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_Appointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                lblUserMessage.Visible = false;

            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (_Type)
            {
                case clsBussenessTestTypes.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    lblUserMessage.Visible = false;

                    return true;

                case clsBussenessTestTypes.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LDLApplication.DoesPassTestType(clsBussenessTestTypes.enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

                case clsBussenessTestTypes.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LDLApplication.DoesPassTestType(clsBussenessTestTypes.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

            }
            return true;

        }
        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (Mode == enMode.AddNew && CreationMode == enCreationMode.RetakeTest)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsBussenessApplications Application = new clsBussenessApplications();

                Application.ApplicantPersonID = _LDLApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsBussenessApplications.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsBussenessApplications.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsBussenessApplicationTypes.GetApplicationTypeByApplicationTypeID(7).Fees;
                Application.CreatedByUserID = 19;// clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    _Appointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _Appointment.RetakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }
        private bool _LoadTestAppointmentData()
        {
           _Appointment = clsBussenssTestAppointments.Find(_AppointmentID);

            if (_Appointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _AppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _Appointment.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, _Appointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _Appointment.AppointmentDate;

            dtpTestDate.Value = _Appointment.AppointmentDate;

            if (_Appointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                lblRetakeAppFees.Text = _Appointment.RetakeTestAppInfo.PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = _Appointment.RetakeTestApplicationID.ToString();

            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_HandleRetakeApplication())
                return;

            _Appointment.TestTypeID = _Type;
            _Appointment.LocalDrivingLicenseApplicationID = _LDLApplicationID;
            _Appointment.AppointmentDate = dtpTestDate.Value;
            _Appointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _Appointment.CreatedByUserID = 19; //clsGlobal.CurrentUser.UserID;
            //IsLocked is set to false by default in the constructor
            //RetakeTestApplicationID is handled in the _HandleRetakeApplication function



            if (_Appointment.Save() )
            {
                Mode = enMode.Update;
                MessageBox.Show("Appointment Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Faild to Save Appointment", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

        }
    }
}
