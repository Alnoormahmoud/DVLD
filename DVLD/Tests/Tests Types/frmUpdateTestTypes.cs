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

namespace DVLD.Tests.Tests_Types
{
    public partial class frmUpdateTestTypes : Form
    {
         private clsBussenessTestTypes.enTestType _TestTypeID = clsBussenessTestTypes.enTestType.VisionTest;

        private clsBussenessTestTypes _Test;

        public frmUpdateTestTypes(clsBussenessTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }
        
        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _Test = clsBussenessTestTypes.GetTestTypeByID(_TestTypeID);

            if (_Test != null)
            {
                lblId.Text = ((int)_TestTypeID).ToString();
                txtFees.Text = _Test.TestFees.ToString();
                txtDescription.Text = _Test.TestDescription.ToString();
                txtTitle.Text = _Test.TestTile;
            }
            else
            {
                MessageBox.Show("Test Type Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Test.TestTile = txtTitle.Text;
            _Test.TestDescription = txtDescription.Text.Trim();
            _Test.TestFees = decimal.Parse(txtFees.Text.Trim());

            if (_Test.Save())
            {
                MessageBox.Show("Test Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error Occured while updating the Test Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtTitle_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Give It a Title Please.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Give It a Description Please.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDescription, "");
            }
        }

        private void txtFees_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees Is Required.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }
        }

        private void txtFees_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
