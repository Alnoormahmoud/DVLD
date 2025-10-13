namespace DVLD.Applications.ReplaceLicense
{
    partial class frmReplaceLicenseDamagedOrLostLicense
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
            this.ucDriverLicenseInfoWithFilter1 = new DVLD.Licenses.Local_Licenses.Controls.ucDriverLicenseInfoWithFilter();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.llShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.gpApplicationInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lblRreplacedLicenseID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.gbReplacementFor.SuspendLayout();
            this.gpApplicationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // ucDriverLicenseInfoWithFilter1
            // 
            this.ucDriverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ucDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(-4, 84);
            this.ucDriverLicenseInfoWithFilter1.Name = "ucDriverLicenseInfoWithFilter1";
            this.ucDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1230, 640);
            this.ucDriverLicenseInfoWithFilter1.TabIndex = 0;
            this.ucDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ucDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rbLostLicense);
            this.gbReplacementFor.Controls.Add(this.rbDamagedLicense);
            this.gbReplacementFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacementFor.Location = new System.Drawing.Point(912, 108);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(281, 109);
            this.gbReplacementFor.TabIndex = 192;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Repalcement For:";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(9, 55);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(148, 26);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Location = new System.Drawing.Point(8, 27);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(194, 26);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(370, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(547, 37);
            this.lblTitle.TabIndex = 193;
            this.lblTitle.Text = "Replacement for Damaged License";
            // 
            // llShowLicenseInfo
            // 
            this.llShowLicenseInfo.AutoSize = true;
            this.llShowLicenseInfo.Enabled = false;
            this.llShowLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseInfo.Location = new System.Drawing.Point(322, 991);
            this.llShowLicenseInfo.Name = "llShowLicenseInfo";
            this.llShowLicenseInfo.Size = new System.Drawing.Size(273, 26);
            this.llShowLicenseInfo.TabIndex = 198;
            this.llShowLicenseInfo.TabStop = true;
            this.llShowLicenseInfo.Text = "Show New Licenses Info";
            this.llShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseInfo_LinkClicked);
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Enabled = false;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenseHistory.Location = new System.Drawing.Point(25, 991);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(254, 26);
            this.llShowLicenseHistory.TabIndex = 197;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show Licenses History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Enabled = false;
            this.btnIssueReplacement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIssueReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(921, 973);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(272, 57);
            this.btnIssueReplacement.TabIndex = 196;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // gpApplicationInfo
            // 
            this.gpApplicationInfo.Controls.Add(this.pictureBox4);
            this.gpApplicationInfo.Controls.Add(this.pictureBox9);
            this.gpApplicationInfo.Controls.Add(this.pictureBox5);
            this.gpApplicationInfo.Controls.Add(this.pictureBox2);
            this.gpApplicationInfo.Controls.Add(this.lblOldLicenseID);
            this.gpApplicationInfo.Controls.Add(this.label12);
            this.gpApplicationInfo.Controls.Add(this.pictureBox7);
            this.gpApplicationInfo.Controls.Add(this.lblRreplacedLicenseID);
            this.gpApplicationInfo.Controls.Add(this.label10);
            this.gpApplicationInfo.Controls.Add(this.pictureBox1);
            this.gpApplicationInfo.Controls.Add(this.label1);
            this.gpApplicationInfo.Controls.Add(this.lblCreatedByUser);
            this.gpApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gpApplicationInfo.Controls.Add(this.label2);
            this.gpApplicationInfo.Controls.Add(this.pictureBox3);
            this.gpApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gpApplicationInfo.Controls.Add(this.label5);
            this.gpApplicationInfo.Controls.Add(this.lblApplicationID);
            this.gpApplicationInfo.Controls.Add(this.label4);
            this.gpApplicationInfo.Location = new System.Drawing.Point(20, 742);
            this.gpApplicationInfo.Name = "gpApplicationInfo";
            this.gpApplicationInfo.Size = new System.Drawing.Size(1173, 213);
            this.gpApplicationInfo.TabIndex = 194;
            this.gpApplicationInfo.TabStop = false;
            this.gpApplicationInfo.Text = "Application Info for License Replacement";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox9.Location = new System.Drawing.Point(270, 133);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(50, 55);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 198;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox5.Location = new System.Drawing.Point(269, 37);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(51, 42);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 196;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox2.Location = new System.Drawing.Point(810, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 195;
            this.pictureBox2.TabStop = false;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(868, 95);
            this.lblOldLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(68, 29);
            this.lblOldLicenseID.TabIndex = 194;
            this.lblOldLicenseID.Text = "[???]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(611, 95);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(192, 29);
            this.label12.TabIndex = 193;
            this.label12.Text = "Old License ID:";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.pictureBox7.Location = new System.Drawing.Point(810, 24);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(51, 55);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 192;
            this.pictureBox7.TabStop = false;
            // 
            // lblRreplacedLicenseID
            // 
            this.lblRreplacedLicenseID.AutoSize = true;
            this.lblRreplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRreplacedLicenseID.Location = new System.Drawing.Point(868, 38);
            this.lblRreplacedLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRreplacedLicenseID.Name = "lblRreplacedLicenseID";
            this.lblRreplacedLicenseID.Size = new System.Drawing.Size(68, 29);
            this.lblRreplacedLicenseID.TabIndex = 191;
            this.lblRreplacedLicenseID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(541, 38);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(262, 29);
            this.label10.TabIndex = 190;
            this.label10.Text = "Replaced License ID:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pictureBox1.Location = new System.Drawing.Point(810, 146);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 182;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(654, 149);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 29);
            this.label1.TabIndex = 181;
            this.label1.Text = "Created By:";
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.AutoSize = true;
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(868, 146);
            this.lblCreatedByUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(81, 29);
            this.lblCreatedByUser.TabIndex = 180;
            this.lblCreatedByUser.Text = "[????]";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(330, 146);
            this.lblApplicationFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(71, 29);
            this.lblApplicationFees.TabIndex = 179;
            this.lblApplicationFees.Text = "[$$$]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 29);
            this.label2.TabIndex = 177;
            this.label2.Text = "Application Fees:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(211, 146);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 178;
            this.pictureBox3.TabStop = false;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(327, 95);
            this.lblApplicationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(149, 29);
            this.lblApplicationDate.TabIndex = 176;
            this.lblApplicationDate.Text = "[??/??/????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 95);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 29);
            this.label5.TabIndex = 174;
            this.label5.Text = "Application Date:";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(330, 51);
            this.lblApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(68, 29);
            this.lblApplicationID.TabIndex = 173;
            this.lblApplicationID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 29);
            this.label4.TabIndex = 172;
            this.label4.Text = "L.R.Application ID:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(664, 973);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(207, 57);
            this.btnClose.TabIndex = 195;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox4.Location = new System.Drawing.Point(269, 85);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(51, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 199;
            this.pictureBox4.TabStop = false;
            // 
            // frmReplaceLicenseDamagedOrLostLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1238, 1044);
            this.Controls.Add(this.llShowLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.gpApplicationInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.ucDriverLicenseInfoWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplaceLicenseDamagedOrLostLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace Damaged Or Lost License";
            this.Activated += new System.EventHandler(this.frmReplaceLicenseDamagedOrLostLicense_Activated);
            this.Load += new System.EventHandler(this.frmReplaceLicenseDamagedOrLostLicense_Load);
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.gpApplicationInfo.ResumeLayout(false);
            this.gpApplicationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.Local_Licenses.Controls.ucDriverLicenseInfoWithFilter ucDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.LinkLabel llShowLicenseInfo;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.GroupBox gpApplicationInfo;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lblRreplacedLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}