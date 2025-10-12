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

namespace DVLD.Licenses.International_License.control
{
    public partial class ucDriverInternationalLicenseInfo : UserControl
    {
        int LicenseID = -1;
        clsBuessenessInternationalLicenses License;

        public ucDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public int InternationalLicenseID
        {
            get { return LicenseID; }
        }
        private void LoadImage()
        {
            if (License.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                pbPersonImage.Load(ImagePath);
    
        }

        public void LoadLicenseInfo(int LicenseId)
        {
            LicenseID = LicenseId;
            License = clsBuessenessInternationalLicenses.Find(LicenseId);

            if (License == null)
            {
                MessageBox.Show("License not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            lblFullName.Text = License.DriverInfo.PersonInfo.FullName;
            lblLocalLicenseID.Text = License.IssuedUsingLocalLicenseID.ToString();
            lblInternationalLicenseID.Text = License.InternationalLicenseID.ToString();

            lblDriverID.Text = License.DriverID.ToString();
            lblApplicationID.Text = License.ApplicationID.ToString();
            lblIssueDate.Text = License.IssueDate.ToShortDateString();

            lblExpirationDate .Text = License.ExpirationDate.ToShortDateString();
            lblGendor.Text = License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblNationalNo.Text = License.DriverInfo.PersonInfo.NationalNo;
            LoadImage();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucDriverInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
