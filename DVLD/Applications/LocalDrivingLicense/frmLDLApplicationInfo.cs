using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.LocalDrivingLicense
{
    public partial class frmLDLApplicationInfo : Form
    {
        int _LDLAppId = -1;
        public frmLDLApplicationInfo(int LDLAppId)
        {
            InitializeComponent();
            _LDLAppId = LDLAppId;
        }

        private void frmLDLApplicationInfo_Load(object sender, EventArgs e)
        {
            ucDrivingLicenseApplicationInfo1.LoadAppliactionInfoByLDLAppID(_LDLAppId);
        }

        private void ucDrivingLicenseApplicationInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
