namespace DVLD.Licenses
{
    partial class frmShowPersonLicenseHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucDriverLicennses1 = new DVLD.Licenses.Controls.ucDriverLicennses();
            this.ucInfoWithFillter1 = new DVLD.UCInfoWithFillter();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(573, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(366, 37);
            this.label3.TabIndex = 101;
            this.label3.Text = "Person License History";
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_512;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(9, 297);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(279, 293);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 102;
            this.pbPersonImage.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(26, 639);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(262, 61);
            this.btnClose.TabIndex = 104;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucDriverLicennses1
            // 
            this.ucDriverLicennses1.Location = new System.Drawing.Point(12, 727);
            this.ucDriverLicennses1.Name = "ucDriverLicennses1";
            this.ucDriverLicennses1.Size = new System.Drawing.Size(1557, 464);
            this.ucDriverLicennses1.TabIndex = 105;
            // 
            // ucInfoWithFillter1
            // 
            this.ucInfoWithFillter1.AutoScroll = true;
            this.ucInfoWithFillter1.FilterEnabled = true;
            this.ucInfoWithFillter1.Location = new System.Drawing.Point(295, 74);
            this.ucInfoWithFillter1.Name = "ucInfoWithFillter1";
            this.ucInfoWithFillter1.ShowAddPerson = true;
            this.ucInfoWithFillter1.Size = new System.Drawing.Size(1256, 663);
            this.ucInfoWithFillter1.TabIndex = 0;
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1578, 1211);
            this.Controls.Add(this.ucDriverLicennses1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucInfoWithFillter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Person License History";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UCInfoWithFillter ucInfoWithFillter1;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private Controls.ucDriverLicennses ucDriverLicennseInfo1;
        private Controls.ucDriverLicennses ucDriverLicennses1;
    }
}