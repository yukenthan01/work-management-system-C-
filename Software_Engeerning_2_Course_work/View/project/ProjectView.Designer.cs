
namespace Software_Engeerning_2_Course_work.View.project
{
    partial class ProjectView
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
            this.btnsearch = new System.Windows.Forms.Button();
            this.comboBoxSelectedOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewProjects = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tittle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPojectSearch = new System.Windows.Forms.TextBox();
            this.dateTimePickerSelectDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(959, 12);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(129, 38);
            this.btnsearch.TabIndex = 210;
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
            this.comboBoxSelectedOption.Location = new System.Drawing.Point(390, 18);
            this.comboBoxSelectedOption.Name = "comboBoxSelectedOption";
            this.comboBoxSelectedOption.Size = new System.Drawing.Size(121, 28);
            this.comboBoxSelectedOption.TabIndex = 208;
            this.comboBoxSelectedOption.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedOption_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(106, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 26);
            this.label1.TabIndex = 213;
            this.label1.Text = "Select the search option";
            // 
            // dataGridViewProjects
            // 
            this.dataGridViewProjects.AllowUserToAddRows = false;
            this.dataGridViewProjects.AllowUserToDeleteRows = false;
            this.dataGridViewProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.tittle,
            this.startDate,
            this.endDate,
            this.duration,
            this.percentage,
            this.status});
            this.dataGridViewProjects.Location = new System.Drawing.Point(12, 84);
            this.dataGridViewProjects.Name = "dataGridViewProjects";
            this.dataGridViewProjects.ReadOnly = true;
            this.dataGridViewProjects.RowHeadersWidth = 62;
            this.dataGridViewProjects.RowTemplate.Height = 28;
            this.dataGridViewProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProjects.Size = new System.Drawing.Size(1290, 663);
            this.dataGridViewProjects.TabIndex = 212;
            this.dataGridViewProjects.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjects_CellClick);
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
            // tittle
            // 
            this.tittle.DataPropertyName = "tittle";
            this.tittle.HeaderText = "Tittle";
            this.tittle.MinimumWidth = 8;
            this.tittle.Name = "tittle";
            this.tittle.ReadOnly = true;
            this.tittle.Width = 150;
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
            this.duration.Width = 150;
            // 
            // percentage
            // 
            this.percentage.DataPropertyName = "percentage";
            this.percentage.HeaderText = "Percentage";
            this.percentage.MinimumWidth = 8;
            this.percentage.Name = "percentage";
            this.percentage.ReadOnly = true;
            this.percentage.Width = 80;
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(540, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 26);
            this.label15.TabIndex = 211;
            this.label15.Text = "Enter ";
            // 
            // txtPojectSearch
            // 
            this.txtPojectSearch.Location = new System.Drawing.Point(647, 20);
            this.txtPojectSearch.Name = "txtPojectSearch";
            this.txtPojectSearch.Size = new System.Drawing.Size(220, 26);
            this.txtPojectSearch.TabIndex = 209;
            // 
            // dateTimePickerSelectDate
            // 
            this.dateTimePickerSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSelectDate.Location = new System.Drawing.Point(647, 20);
            this.dateTimePickerSelectDate.Name = "dateTimePickerSelectDate";
            this.dateTimePickerSelectDate.Size = new System.Drawing.Size(220, 26);
            this.dateTimePickerSelectDate.TabIndex = 214;
            this.dateTimePickerSelectDate.Value = new System.DateTime(2022, 3, 22, 0, 0, 0, 0);
            this.dateTimePickerSelectDate.Visible = false;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Not Started",
            "In Progress",
            "Completed",
            "Close"});
            this.comboBoxStatus.Location = new System.Drawing.Point(647, 18);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(220, 28);
            this.comboBoxStatus.TabIndex = 215;
            this.comboBoxStatus.Visible = false;
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(135)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1313, 764);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.dateTimePickerSelectDate);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.comboBoxSelectedOption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewProjects);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPojectSearch);
            this.Name = "ProjectView";
            this.Text = "ProjectView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.ComboBox comboBoxSelectedOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewProjects;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPojectSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn tittle;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DateTimePicker dateTimePickerSelectDate;
        private System.Windows.Forms.ComboBox comboBoxStatus;
    }
}