
namespace Software_Engeerning_2_Course_work.View.project
{
    partial class ProjectAdd
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
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelProjectId = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelErrorUsers = new System.Windows.Forms.Label();
            this.labelErrorPercentage = new System.Windows.Forms.Label();
            this.labelErrorStatus = new System.Windows.Forms.Label();
            this.labelErrorEndDate = new System.Windows.Forms.Label();
            this.labelErrorDuration = new System.Windows.Forms.Label();
            this.labelErrorStartDate = new System.Windows.Forms.Label();
            this.labelErrorDescription = new System.Windows.Forms.Label();
            this.labelErrorTittle = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtProjectTittle = new System.Windows.Forms.TextBox();
            this.listBoxUsersSelected = new System.Windows.Forms.ListBox();
            this.checkedListBoxUsers = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Not Started",
            "In Progress",
            "Completed",
            "Closed"});
            this.comboBoxStatus.Location = new System.Drawing.Point(772, 152);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(220, 28);
            this.comboBoxStatus.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(615, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 235;
            this.label1.Text = "Status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(73, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 26);
            this.label9.TabIndex = 221;
            this.label9.Text = "Project Tittle";
            // 
            // labelProjectId
            // 
            this.labelProjectId.AutoSize = true;
            this.labelProjectId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjectId.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelProjectId.Location = new System.Drawing.Point(241, 58);
            this.labelProjectId.Name = "labelProjectId";
            this.labelProjectId.Size = new System.Drawing.Size(18, 26);
            this.labelProjectId.TabIndex = 219;
            this.labelProjectId.Text = ".";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(73, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 26);
            this.label15.TabIndex = 218;
            this.label15.Text = "Project ID";
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(422, 565);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(155, 58);
            this.btnsubmit.TabIndex = 9;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(92, 450);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 26);
            this.label11.TabIndex = 215;
            this.label11.Text = "Duration";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(249, 450);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(220, 26);
            this.txtDuration.TabIndex = 4;
            this.txtDuration.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDuration_KeyUp);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(249, 219);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(226, 85);
            this.txtDescription.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(73, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 26);
            this.label5.TabIndex = 211;
            this.label5.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(78, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 26);
            this.label2.TabIndex = 213;
            this.label2.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(135)))), ((int)(((byte)(168)))));
            this.groupBox1.Controls.Add(this.labelErrorUsers);
            this.groupBox1.Controls.Add(this.labelErrorPercentage);
            this.groupBox1.Controls.Add(this.labelErrorStatus);
            this.groupBox1.Controls.Add(this.labelErrorEndDate);
            this.groupBox1.Controls.Add(this.labelErrorDuration);
            this.groupBox1.Controls.Add(this.labelErrorStartDate);
            this.groupBox1.Controls.Add(this.labelErrorDescription);
            this.groupBox1.Controls.Add(this.labelErrorTittle);
            this.groupBox1.Controls.Add(this.dateTimePickerEndDate);
            this.groupBox1.Controls.Add(this.dateTimePickerStartDate);
            this.groupBox1.Controls.Add(this.txtProjectTittle);
            this.groupBox1.Controls.Add(this.listBoxUsersSelected);
            this.groupBox1.Controls.Add(this.checkedListBoxUsers);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPercentage);
            this.groupBox1.Controls.Add(this.comboBoxStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.labelProjectId);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnsubmit);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtDuration);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(1412, 689);
            this.groupBox1.TabIndex = 224;
            this.groupBox1.TabStop = false;
            // 
            // labelErrorUsers
            // 
            this.labelErrorUsers.AccessibleName = "labelErrorUsers";
            this.labelErrorUsers.AutoSize = true;
            this.labelErrorUsers.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorUsers.ForeColor = System.Drawing.Color.DarkRed;
            this.labelErrorUsers.Location = new System.Drawing.Point(781, 565);
            this.labelErrorUsers.Name = "labelErrorUsers";
            this.labelErrorUsers.Size = new System.Drawing.Size(156, 23);
            this.labelErrorUsers.TabIndex = 254;
            this.labelErrorUsers.Text = "eg@example.com";
            this.labelErrorUsers.Visible = false;
            // 
            // labelErrorPercentage
            // 
            this.labelErrorPercentage.AccessibleName = "labelErrorPercentage";
            this.labelErrorPercentage.AutoSize = true;
            this.labelErrorPercentage.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorPercentage.ForeColor = System.Drawing.Color.DarkRed;
            this.labelErrorPercentage.Location = new System.Drawing.Point(781, 264);
            this.labelErrorPercentage.Name = "labelErrorPercentage";
            this.labelErrorPercentage.Size = new System.Drawing.Size(156, 23);
            this.labelErrorPercentage.TabIndex = 253;
            this.labelErrorPercentage.Text = "eg@example.com";
            this.labelErrorPercentage.Visible = false;
            // 
            // labelErrorStatus
            // 
            this.labelErrorStatus.AccessibleName = "labelErrorStatus";
            this.labelErrorStatus.AutoSize = true;
            this.labelErrorStatus.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.labelErrorStatus.Location = new System.Drawing.Point(781, 183);
            this.labelErrorStatus.Name = "labelErrorStatus";
            this.labelErrorStatus.Size = new System.Drawing.Size(156, 23);
            this.labelErrorStatus.TabIndex = 252;
            this.labelErrorStatus.Text = "eg@example.com";
            this.labelErrorStatus.Visible = false;
            // 
            // labelErrorEndDate
            // 
            this.labelErrorEndDate.AccessibleName = "labelErrorEndDate";
            this.labelErrorEndDate.AutoSize = true;
            this.labelErrorEndDate.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorEndDate.ForeColor = System.Drawing.Color.DarkRed;
            this.labelErrorEndDate.Location = new System.Drawing.Point(781, 97);
            this.labelErrorEndDate.Name = "labelErrorEndDate";
            this.labelErrorEndDate.Size = new System.Drawing.Size(156, 23);
            this.labelErrorEndDate.TabIndex = 251;
            this.labelErrorEndDate.Text = "eg@example.com";
            this.labelErrorEndDate.Visible = false;
            // 
            // labelErrorDuration
            // 
            this.labelErrorDuration.AccessibleName = "labelErrorDuration";
            this.labelErrorDuration.AutoSize = true;
            this.labelErrorDuration.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorDuration.ForeColor = System.Drawing.Color.DarkRed;
            this.labelErrorDuration.Location = new System.Drawing.Point(257, 479);
            this.labelErrorDuration.Name = "labelErrorDuration";
            this.labelErrorDuration.Size = new System.Drawing.Size(156, 23);
            this.labelErrorDuration.TabIndex = 250;
            this.labelErrorDuration.Text = "eg@example.com";
            this.labelErrorDuration.Visible = false;
            // 
            // labelErrorStartDate
            // 
            this.labelErrorStartDate.AccessibleName = "labelErrorStartDate";
            this.labelErrorStartDate.AutoSize = true;
            this.labelErrorStartDate.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorStartDate.ForeColor = System.Drawing.Color.DarkRed;
            this.labelErrorStartDate.Location = new System.Drawing.Point(257, 397);
            this.labelErrorStartDate.Name = "labelErrorStartDate";
            this.labelErrorStartDate.Size = new System.Drawing.Size(156, 23);
            this.labelErrorStartDate.TabIndex = 249;
            this.labelErrorStartDate.Text = "eg@example.com";
            this.labelErrorStartDate.Visible = false;
            // 
            // labelErrorDescription
            // 
            this.labelErrorDescription.AccessibleName = "labelErrorDescription";
            this.labelErrorDescription.AutoSize = true;
            this.labelErrorDescription.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorDescription.ForeColor = System.Drawing.Color.DarkRed;
            this.labelErrorDescription.Location = new System.Drawing.Point(257, 314);
            this.labelErrorDescription.Name = "labelErrorDescription";
            this.labelErrorDescription.Size = new System.Drawing.Size(156, 23);
            this.labelErrorDescription.TabIndex = 248;
            this.labelErrorDescription.Text = "eg@example.com";
            this.labelErrorDescription.Visible = false;
            // 
            // labelErrorTittle
            // 
            this.labelErrorTittle.AccessibleName = "labelErrorTittle";
            this.labelErrorTittle.AutoSize = true;
            this.labelErrorTittle.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorTittle.ForeColor = System.Drawing.Color.DarkRed;
            this.labelErrorTittle.Location = new System.Drawing.Point(257, 164);
            this.labelErrorTittle.Name = "labelErrorTittle";
            this.labelErrorTittle.Size = new System.Drawing.Size(156, 23);
            this.labelErrorTittle.TabIndex = 247;
            this.labelErrorTittle.Text = "eg@example.com";
            this.labelErrorTittle.Visible = false;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(772, 66);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerEndDate.TabIndex = 5;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(249, 368);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerStartDate.TabIndex = 3;
            // 
            // txtProjectTittle
            // 
            this.txtProjectTittle.Location = new System.Drawing.Point(249, 135);
            this.txtProjectTittle.Name = "txtProjectTittle";
            this.txtProjectTittle.Size = new System.Drawing.Size(220, 26);
            this.txtProjectTittle.TabIndex = 1;
            // 
            // listBoxUsersSelected
            // 
            this.listBoxUsersSelected.FormattingEnabled = true;
            this.listBoxUsersSelected.HorizontalScrollbar = true;
            this.listBoxUsersSelected.ItemHeight = 20;
            this.listBoxUsersSelected.Location = new System.Drawing.Point(1013, 314);
            this.listBoxUsersSelected.Name = "listBoxUsersSelected";
            this.listBoxUsersSelected.ScrollAlwaysVisible = true;
            this.listBoxUsersSelected.Size = new System.Drawing.Size(220, 224);
            this.listBoxUsersSelected.TabIndex = 242;
            // 
            // checkedListBoxUsers
            // 
            this.checkedListBoxUsers.CheckOnClick = true;
            this.checkedListBoxUsers.FormattingEnabled = true;
            this.checkedListBoxUsers.Location = new System.Drawing.Point(772, 314);
            this.checkedListBoxUsers.Name = "checkedListBoxUsers";
            this.checkedListBoxUsers.Size = new System.Drawing.Size(220, 234);
            this.checkedListBoxUsers.TabIndex = 8;
            this.checkedListBoxUsers.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxUsers_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(615, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 26);
            this.label6.TabIndex = 239;
            this.label6.Text = "Users";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(615, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 26);
            this.label4.TabIndex = 237;
            this.label4.Text = "Percentage";
            // 
            // txtPercentage
            // 
            this.txtPercentage.Location = new System.Drawing.Point(772, 235);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.Size = new System.Drawing.Size(220, 26);
            this.txtPercentage.TabIndex = 7;
            this.txtPercentage.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(599, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 26);
            this.label3.TabIndex = 211;
            this.label3.Text = "End Date";
            // 
            // ProjectAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(135)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1435, 712);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProjectAdd";
            this.Text = "ProjectAdd";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelProjectId;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPercentage;
        private System.Windows.Forms.CheckedListBox checkedListBoxUsers;
        private System.Windows.Forms.ListBox listBoxUsersSelected;
        private System.Windows.Forms.TextBox txtProjectTittle;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label labelErrorUsers;
        private System.Windows.Forms.Label labelErrorPercentage;
        private System.Windows.Forms.Label labelErrorStatus;
        private System.Windows.Forms.Label labelErrorEndDate;
        private System.Windows.Forms.Label labelErrorDuration;
        private System.Windows.Forms.Label labelErrorStartDate;
        private System.Windows.Forms.Label labelErrorDescription;
        private System.Windows.Forms.Label labelErrorTittle;
    }
}