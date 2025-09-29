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

namespace DVLD.Tests
{
    public partial class frmScheduleTest : Form
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        clsBussenessTestTypes.enTestType _Type;
        int _LDLAppID = -1;
        int _AppointmentID = -1;

        public frmScheduleTest(int LDLApplicationID, clsBussenessTestTypes.enTestType type, int AppointmentID = -1)
        {
            InitializeComponent();
            _LDLAppID = LDLApplicationID;
            _Type = type;
            _AppointmentID = AppointmentID;
        }
 
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ucScheduleTest1.TestType = _Type;
            ucScheduleTest1.LoadControl(_LDLAppID, _AppointmentID);

        }

  

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
