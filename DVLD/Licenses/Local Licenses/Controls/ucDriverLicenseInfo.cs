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

namespace DVLD.Licenses.Local_Licenses.Controls
{
    public partial class ucDriverLicenseInfo : UserControl
    {
        clsBussenessLicenses LicenseInfo;
        int LicenseID = -1;
        public ucDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadLicenseData(int LicenseID)
        {
            LicenseInfo = clsBussenessLicenses.FindLicenseByLicenseId(LicenseID);

            if (LicenseInfo == null)
            {
                MessageBox.Show("License With ID : "+LicenseID.ToString()+" not found.");
                return;
            }
            lblClass.Text = LicenseInfo.LicenseClassIfo.ClassName;
            lblFullName.Text = LicenseInfo.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = LicenseInfo.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblExpirationDate.Text = LicenseInfo.ExpirationDate.ToShortDateString();
            lblIssueDate.Text = LicenseInfo.IssueDate.ToShortDateString();
            if(LicenseInfo.Notes == "")
            {
                lblNotes.Text = "N/A";
            }
            else
            lblNotes.Text = LicenseInfo.Notes;
            lblIsActive.Text = LicenseInfo.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = LicenseInfo.DriverID.ToString();
            lblIsDetained.Text =  "No"; 
            lblIssueReason.Text = LicenseInfo.IssueReason.ToString();

            pbPersonImage.ImageLocation = LicenseInfo.DriverInfo.PersonInfo.ImagePath;


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
