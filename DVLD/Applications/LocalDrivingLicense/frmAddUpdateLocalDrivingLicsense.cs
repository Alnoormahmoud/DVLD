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
using System.Windows.Controls;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicense
{
    public partial class frmAddUpdateLocalDrivingLicsense : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;

        private clsBussenessLocBalDrivingLicenseApplications  _LDLApplication;

        private int _LDLApplicationID = -1;
        private int _SelectedPersoniD = -1;

        public frmAddUpdateLocalDrivingLicsense()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicsense(  int LDLApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LDLApplicationID = LDLApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tcApplicatonInfo.Enabled = true;
                tcAllApplicatonInfo.SelectedTab = tcAllApplicatonInfo.TabPages["tcApplicatonInfo"];
                return;
            }
            //incase of add new mode.
            if (ucInfoWithFillter1.PersonID < 0)
            {
                MessageBox.Show("Find Or Add Person First To Add New Liecese!", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucInfoWithFillter1.FilterFocus();

                return;
            }        

            else
            {
                btnSave.Enabled = true;
                tcApplicatonInfo.Enabled = true;
                tcAllApplicatonInfo.SelectedTab = tcAllApplicatonInfo.TabPages["tcApplicatonInfo"];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int LicenseClassID = clsBussenessLicenseClasses.Find(cbLicenseClass.Text).LicenseClassID;


            int ActiveApplicationID = clsBussenessApplications.GetActiveApplicationIDForLicenseClass(_SelectedPersoniD, clsBussenessApplications.enApplicationType.NewDrivingLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id = " + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            //check if user already have issued license of the same driving  class.
            //KKKKKKKK I Don't Have The Licenses Right Now SO I"ll Come For This Lette
            //if (clsBussenessLicenseClasses.IsLicenseExistByPersonID(ucInfoWithFillter1.PersonID, LicenseClassID))
            //{

            //    MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            _LDLApplication.ApplicantPersonID = ucInfoWithFillter1.PersonID;
            _LDLApplication.ApplicationDate = DateTime.Now;
            _LDLApplication.ApplicationTypeID = 1; //local driving license
            _LDLApplication.ApplicationStatus = clsBussenessApplications.enApplicationStatus.New; //new
            _LDLApplication.LastStatusDate = DateTime.Now;
            _LDLApplication.PaidFees = Convert.ToDecimal(lblAppFee.Text);
            _LDLApplication.CreatedByUserID = 19; //clsGlobal.CurrentUser.UserID;

            _LDLApplication.LicenseClassID = LicenseClassID;


            if (_LDLApplication.Save())
            {
                lblLDLApllicationId.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Application Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Can't Save Application Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillLicenseClassesInCompoBox()
        {
            DataTable dataTable = clsBussenessLicenseClasses.GetAllLicenseClasses();

            foreach (DataRow row in dataTable.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }
        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            FillLicenseClassesInCompoBox();

            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LDLApplication = new clsBussenessLocBalDrivingLicenseApplications();
                ucInfoWithFillter1.FilterFocus();
                tcApplicatonInfo.Enabled = false;
                cbLicenseClass.SelectedIndex = 2;
                lblAppFee.Text = clsBussenessApplicationTypes.Find((int)clsBussenessApplications.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblAppDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = "Alnoor";//clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tcApplicatonInfo.Enabled = true;
                btnSave.Enabled = true;
            }

        }
        private void _LoadData()
        {
            ucInfoWithFillter1.FilterEnabled = false;
            _LDLApplication = clsBussenessLocBalDrivingLicenseApplications.FindLDLApplicationBYID(_LDLApplicationID);

            if (_LDLApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LDLApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ucInfoWithFillter1.LoadPersonInfo(_LDLApplication.ApplicantPersonID);
            _SelectedPersoniD = _LDLApplication.ApplicantPersonID;
            lblLDLApllicationId.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppDate.Text = _LDLApplication.ApplicationDate.ToString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsBussenessLicenseClasses.Find(_LDLApplication.LicenseClassID).ClassName);
            lblAppFee.Text = _LDLApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsBussenessUsersManagement.Find(_LDLApplication.CreatedByUserID).UserName;

        }
        private void frmAddLocalDrivingLicsense_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }
        private void ucInfoWithFillter1_OnPersonSelected(int obj)
        {
            _SelectedPersoniD = obj;
        }
 
    }
}
