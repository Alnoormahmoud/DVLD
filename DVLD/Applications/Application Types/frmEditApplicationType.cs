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

namespace DVLD.Application.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        private int _ID;
        private clsBussenessApplicationTypes _Application;

        public frmEditApplicationType(int id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _Application =  clsBussenessApplicationTypes.GetApplicationTypeByApplicationTypeID(_ID);
            if (_Application != null)
            {
                lblId.Text = _ID.ToString();
                txtFees.Text = _Application.Fees.ToString();
                txtTitle.Text = _Application.Title;
            }
            else
            {
                MessageBox.Show("Application Type Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Application.Id = _ID;  
            _Application.Title = txtTitle.Text;
            _Application.Fees = decimal.Parse(txtFees.Text);

            if (_Application.Save())
            {
                MessageBox.Show("Application Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error Occured while updating the Application Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
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

        private void txtFees_Validating(object sender, CancelEventArgs e)
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

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
