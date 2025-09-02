using BussenessAccesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmUserDetailscs : Form
    {
        private int _UserId = 0;
        private clsBussenessUsersManagement _User;

        public frmUserDetailscs(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
            _User = clsBussenessUsersManagement.Find(UserId); 
        }

        private void frmUserDetailscs_Load(object sender, EventArgs e)
        {
            ucUserInfo1.LoadUserInfo(_UserId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
