namespace DVLD.Applications.LocalDrivingLicense
{
    partial class frmAddUpdateLocalDrivingLicsense
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tcPersonInfo = new System.Windows.Forms.TabPage();
            this.ucInfoWithFillter1 = new DVLD.UCInfoWithFillter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tcAllApplicatonInfo = new System.Windows.Forms.TabControl();
            this.tcApplicatonInfo = new System.Windows.Forms.TabPage();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblAppFee = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblLDLApllicationId = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tcPersonInfo.SuspendLayout();
            this.tcAllApplicatonInfo.SuspendLayout();
            this.tcApplicatonInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(333, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(597, 37);
            this.lblTitle.TabIndex = 108;
            this.lblTitle.Text = "New Local Driving License Application";
            // 
            // tcPersonInfo
            // 
            this.tcPersonInfo.Controls.Add(this.ucInfoWithFillter1);
            this.tcPersonInfo.Controls.Add(this.btnNext);
            this.tcPersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tcPersonInfo.Name = "tcPersonInfo";
            this.tcPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tcPersonInfo.Size = new System.Drawing.Size(1242, 737);
            this.tcPersonInfo.TabIndex = 0;
            this.tcPersonInfo.Text = "Person Info";
            this.tcPersonInfo.UseVisualStyleBackColor = true;
            // 
            // ucInfoWithFillter1
            // 
            this.ucInfoWithFillter1.FilterEnabled = true;
            this.ucInfoWithFillter1.Location = new System.Drawing.Point(14, 12);
            this.ucInfoWithFillter1.Name = "ucInfoWithFillter1";
            this.ucInfoWithFillter1.ShowAddPerson = true;
            this.ucInfoWithFillter1.Size = new System.Drawing.Size(1210, 650);
            this.ucInfoWithFillter1.TabIndex = 108;
            this.ucInfoWithFillter1.OnPersonSelected += new System.Action<int>(this.ucInfoWithFillter1_OnPersonSelected);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = global::DVLD.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(1065, 668);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(159, 52);
            this.btnNext.TabIndex = 107;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tcAllApplicatonInfo
            // 
            this.tcAllApplicatonInfo.Controls.Add(this.tcPersonInfo);
            this.tcAllApplicatonInfo.Controls.Add(this.tcApplicatonInfo);
            this.tcAllApplicatonInfo.Location = new System.Drawing.Point(24, 76);
            this.tcAllApplicatonInfo.Name = "tcAllApplicatonInfo";
            this.tcAllApplicatonInfo.SelectedIndex = 0;
            this.tcAllApplicatonInfo.Size = new System.Drawing.Size(1250, 770);
            this.tcAllApplicatonInfo.TabIndex = 110;
            // 
            // tcApplicatonInfo
            // 
            this.tcApplicatonInfo.Controls.Add(this.cbLicenseClass);
            this.tcApplicatonInfo.Controls.Add(this.lblAppFee);
            this.tcApplicatonInfo.Controls.Add(this.lblCreatedBy);
            this.tcApplicatonInfo.Controls.Add(this.lblAppDate);
            this.tcApplicatonInfo.Controls.Add(this.pictureBox4);
            this.tcApplicatonInfo.Controls.Add(this.label2);
            this.tcApplicatonInfo.Controls.Add(this.pictureBox3);
            this.tcApplicatonInfo.Controls.Add(this.label1);
            this.tcApplicatonInfo.Controls.Add(this.pictureBox1);
            this.tcApplicatonInfo.Controls.Add(this.label9);
            this.tcApplicatonInfo.Controls.Add(this.lblLDLApllicationId);
            this.tcApplicatonInfo.Controls.Add(this.pictureBox6);
            this.tcApplicatonInfo.Controls.Add(this.label10);
            this.tcApplicatonInfo.Controls.Add(this.pictureBox2);
            this.tcApplicatonInfo.Controls.Add(this.label4);
            this.tcApplicatonInfo.Location = new System.Drawing.Point(4, 29);
            this.tcApplicatonInfo.Name = "tcApplicatonInfo";
            this.tcApplicatonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tcApplicatonInfo.Size = new System.Drawing.Size(1242, 737);
            this.tcApplicatonInfo.TabIndex = 1;
            this.tcApplicatonInfo.Text = "Application Info";
            this.tcApplicatonInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLicenseClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLicenseClass.BackColor = System.Drawing.Color.AliceBlue;
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(452, 292);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(471, 37);
            this.cbLicenseClass.TabIndex = 127;
            // 
            // lblAppFee
            // 
            this.lblAppFee.AutoSize = true;
            this.lblAppFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFee.Location = new System.Drawing.Point(448, 376);
            this.lblAppFee.Name = "lblAppFee";
            this.lblAppFee.Size = new System.Drawing.Size(68, 29);
            this.lblAppFee.TabIndex = 126;
            this.lblAppFee.Text = "[???]";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(447, 462);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(68, 29);
            this.lblCreatedBy.TabIndex = 125;
            this.lblCreatedBy.Text = "[???]";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(448, 218);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(68, 29);
            this.lblAppDate.TabIndex = 124;
            this.lblAppDate.Text = "[???]";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pictureBox4.Location = new System.Drawing.Point(322, 462);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(79, 36);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 122;
            this.pictureBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 462);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 32);
            this.label2.TabIndex = 121;
            this.label2.Text = "Created By :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(322, 376);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(79, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 117;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 32);
            this.label1.TabIndex = 115;
            this.label1.Text = "Application Fee :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(322, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 114;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(284, 32);
            this.label9.TabIndex = 113;
            this.label9.Text = "LDL Application ID :";
            // 
            // lblLDLApllicationId
            // 
            this.lblLDLApllicationId.AutoSize = true;
            this.lblLDLApllicationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLDLApllicationId.ForeColor = System.Drawing.Color.Red;
            this.lblLDLApllicationId.Location = new System.Drawing.Point(447, 125);
            this.lblLDLApllicationId.Name = "lblLDLApllicationId";
            this.lblLDLApllicationId.Size = new System.Drawing.Size(65, 32);
            this.lblLDLApllicationId.TabIndex = 112;
            this.lblLDLApllicationId.Text = "???";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.Properties.Resources.License_Type_32;
            this.pictureBox6.Location = new System.Drawing.Point(322, 292);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(79, 36);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 111;
            this.pictureBox6.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(56, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 32);
            this.label10.TabIndex = 106;
            this.label10.Text = "Application Date :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox2.Location = new System.Drawing.Point(322, 212);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(79, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 107;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(82, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 32);
            this.label4.TabIndex = 103;
            this.label4.Text = "License Class :";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1093, 862);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(159, 52);
            this.btnSave.TabIndex = 109;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(909, 862);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 52);
            this.btnClose.TabIndex = 107;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddUpdateLocalDrivingLicsense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 934);
            this.Controls.Add(this.tcAllApplicatonInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateLocalDrivingLicsense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Update Local Driving License";
            this.Load += new System.EventHandler(this.frmAddLocalDrivingLicsense_Load);
            this.tcPersonInfo.ResumeLayout(false);
            this.tcAllApplicatonInfo.ResumeLayout(false);
            this.tcApplicatonInfo.ResumeLayout(false);
            this.tcApplicatonInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tcPersonInfo;
        private UCInfoWithFillter ucInfoWithFillter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabControl tcAllApplicatonInfo;
        private System.Windows.Forms.TabPage tcApplicatonInfo;
        private System.Windows.Forms.Label lblAppFee;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblLDLApllicationId;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLicenseClass;
    }
}