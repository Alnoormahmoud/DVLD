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

namespace DVLD.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        int PersonID = -1;

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {

            if (PersonID != -1)
            {
                ucInfoWithFillter1.LoadPersonInfo(PersonID);
                ucInfoWithFillter1.FilterEnabled = false;
                ucDriverLicennses1.LoadInfoByPersonID(PersonID);
            }
            else
            {
                ucInfoWithFillter1.Enabled = true;
                ucInfoWithFillter1.FilterFocus();
            }
        }
      

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            PersonID = obj;
            if (PersonID == -1)
            {
                ucDriverLicennseInfo1.Clear();
            }
            else
                ucDriverLicennses1.LoadInfoByPersonID(PersonID);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
