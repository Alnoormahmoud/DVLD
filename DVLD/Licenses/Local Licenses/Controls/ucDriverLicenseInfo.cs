using BussenessAccesses;
using DVLD.Properties;
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

        public int LicenseId
        {
            get { return LicenseID; }
        }

        public clsBussenessLicenses SelectedLicenseInfo
        { get { return LicenseInfo; } }
        private void _LoadPersonImage()
        {
            if (LicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = LicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                pbPersonImage.Load(ImagePath);
 
        }

        public void LoadLicenseData(int LicenseId)
        {
            LicenseInfo = clsBussenessLicenses.FindLicenseByLicenseId(LicenseId);
            LicenseID = LicenseId;
            if (LicenseInfo == null)
            {

                MessageBox.Show("License With ID : "+LicenseID.ToString()+" not found.");
                LicenseID = -1;

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
            lblIsDetained.Text = LicenseInfo.IsDetained ? "Yes" : "No"; 
 
            lblIssueReason.Text = LicenseInfo.IssueReasonText;

            _LoadPersonImage();
        }

        private void ucDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
