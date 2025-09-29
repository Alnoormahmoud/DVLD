 using DVLD.Properties;
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

namespace DVLD.Applications.Controls
{
    public partial class ucApplicationBasicInfo : UserControl
    {
        public ucApplicationBasicInfo()
        {
            InitializeComponent();
        }

        clsBussenessApplications Application;

        int ApplicationId = -1;

        public int ApplicationID
        {
            get { return ApplicationId; }
        }

        private void _FillApplicationInfo()
        {
            ApplicationId = Application.ApplicationID;
            lblApplicationID.Text = Application.ApplicationID.ToString();
            lblType.Text = Application.ApplicationTypeInfo.Title;
            lblDate.Text = Application.ApplicationDate.ToShortDateString();
            lblStatus.Text = Application.StatusText;
            lblStatusDate.Text = Application.LastStatusDate.ToString();
            lblApplicant.Text = Application.ApplicantFullName;
            lblFees.Text = Application.PaidFees.ToString();
            lblCreatedByUser.Text = Application.CreatedByUserInfo.UserName;
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            Application = clsBussenessApplications.FindBaseApplication(ApplicationID);
            if (Application == null)
            {
                MessageBox.Show("Error, Cant't load application info", "Error", MessageBoxButtons.OK);
                return;

            }
            else
            {
                _FillApplicationInfo();
            }

        }

       

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmPersonDetails(Application.ApplicantPersonID);
            frm.ShowDialog();

            LoadApplicationInfo(ApplicationId);

        }
    }
}



 