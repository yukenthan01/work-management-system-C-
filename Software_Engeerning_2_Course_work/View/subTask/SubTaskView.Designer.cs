
namespace Software_Engeerning_2_Course_work.View.subTask
{
    partial class SubTaskView
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
            this.dataGridViewSubTasks = new System.Windows.Forms.DataGridView();
            this.btnsearch = new System.Windows.Forms.Button();
            this.comboBoxSelectedOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.dateTimePickerSelectDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tittle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSubTasks
            // 
            this.dataGridViewSubTasks.AllowUserToAddRows = false;
            this.dataGridViewSubTasks.AllowUserToDeleteRows = false;
            this.dataGridViewSubTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.user,
            this.task_id,
            this.tittle,
            this.description,
            this.startDate,
            this.endDate,
            this.duration,
            this.percentage,
            this.status});
            this.dataGridViewSubTasks.Location = new System.Drawing.Point(12, 83);
            this.dataGridViewSubTasks.Name = "dataGridViewSubTasks";
            this.dataGridViewSubTasks.ReadOnly = true;
            this.dataGridViewSubTasks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewSubTasks.RowTemplate.Height = 28;
            this.dataGridViewSubTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSubTasks.Size = new System.Drawing.Size(1249, 663);
            this.dataGridViewSubTasks.TabIndex = 232;
            this.dataGridViewSubTasks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSubTasks_CellClick);
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(959, 22);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(129, 38);
            this.btnsearch.TabIndex = 227;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // comboBoxSelectedOption
            // 
            this.comboBoxSelectedOption.FormattingEnabled = true;
            this.comboBoxSelectedOption.Items.AddRange(new object[] {
            "All",
            "ID",
            "Tittle",
            "Start Date",
            "Status"});
            this.comboBoxSelectedOption.Location = new System.Drawing.Point(390, 28);
            this.comboBoxSelectedOption.Name = "comboBoxSelectedOption";
            this.comboBoxSelectedOption.Size = new System.Drawing.Size(121, 28);
            this.comboBoxSelectedOption.TabIndex = 225;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(106, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 26);
            this.label1.TabIndex = 229;
            this.label1.Text = "Select the search option";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Not Started",
            "In Progress",
            "Completed",
            "Close"});
            this.comboBoxStatus.Location = new System.Drawing.Point(647, 36);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(220, 28);
            this.comboBoxStatus.TabIndex = 231;
            this.comboBoxStatus.Visible = false;
            // 
            // dateTimePickerSelectDate
            // 
            this.dateTimePickerSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSelectDate.Location = new System.Drawing.Point(647, 34);
            this.dateTimePickerSelectDate.Name = "dateTimePickerSelectDate";
            this.dateTimePickerSelectDate.Size = new System.Drawing.Size(220, 26);
            this.dateTimePickerSelectDate.TabIndex = 230;
            this.dateTimePickerSelectDate.Value = new System.DateTime(2022, 3, 22, 0, 0, 0, 0);
            this.dateTimePickerSelectDate.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(540, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 26);
            this.label15.TabIndex = 228;
            this.label15.Text = "Enter ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(647, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 26);
            this.txtSearch.TabIndex = 226;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // user
            // 
            this.user.DataPropertyName = "firstname";
            this.user.HeaderText = "User";
            this.user.MinimumWidth = 8;
            this.user.Name = "user";
            this.user.ReadOnly = true;
            this.user.Width = 150;
            // 
            // task_id
            // 
            this.task_id.DataPropertyName = "task_tittle";
            this.task_id.HeaderText = "Task";
            this.task_id.MinimumWidth = 8;
            this.task_id.Name = "task_id";
            this.task_id.ReadOnly = true;
            this.task_id.Width = 80;
            // 
            // tittle
            // 
            this.tittle.DataPropertyName = "tittle";
            this.tittle.HeaderText = "Tittle";
            this.tittle.MinimumWidth = 8;
            this.tittle.Name = "tittle";
            this.tittle.ReadOnly = true;
            this.tittle.Width = 150;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.MinimumWidth = 8;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 150;
            // 
            // startDate
            // 
            this.startDate.DataPropertyName = "startDate";
            this.startDate.HeaderText = "Start Date";
            this.startDate.MinimumWidth = 8;
            this.startDate.Name = "startDate";
            this.startDate.ReadOnly = true;
            this.startDate.Width = 150;
            // 
            // endDate
            // 
            this.endDate.DataPropertyName = "endDate";
            this.endDate.HeaderText = "End Date";
            this.endDate.MinimumWidth = 8;
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            this.endDate.Width = 150;
            // 
            // duration
            // 
            this.duration.DataPropertyName = "duration";
            this.duration.HeaderText = "Duration";
            this.duration.MinimumWidth = 8;
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            this.duration.Width = 70;
            // 
            // percentage
            // 
            this.percentage.DataPropertyName = "percentage";
            this.percentage.HeaderText = "Percentage";
            this.percentage.MinimumWidth = 8;
            this.percentage.Name = "percentage";
            this.percentage.ReadOnly = true;
            this.percentage.Width = 70;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 8;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 80;
            // 
            // SubTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(135)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1290, 769);
            this.Controls.Add(this.dataGridViewSubTasks);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.comboBoxSelectedOption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.dateTimePickerSelectDate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSearch);
            this.Name = "SubTaskView";
            this.Text = "SubTaskView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewSubTasks;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.ComboBox comboBoxSelectedOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.DateTimePicker dateTimePickerSelectDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn task_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tittle;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}