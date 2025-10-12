using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.International_License
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        int InternationalLicenseId = -1;
        public frmShowInternationalLicenseInfo(int InternationlLicenseId)
        {
            InitializeComponent();
            this.InternationalLicenseId = InternationlLicenseId;
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ucDriverInternationalLicenseInfo1.LoadLicenseInfo(InternationalLicenseId);
        }
    }
}
