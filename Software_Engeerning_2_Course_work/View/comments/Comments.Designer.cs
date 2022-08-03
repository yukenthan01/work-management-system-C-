
namespace Software_Engeerning_2_Course_work.View.comments
{
    partial class Comments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comments));
            this.groupBoxProjects = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelChatPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.richTextBoxComment = new System.Windows.Forms.RichTextBox();
            this.groupBoxProjects.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxProjects
            // 
            this.groupBoxProjects.Controls.Add(this.panel1);
            this.groupBoxProjects.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProjects.Name = "groupBoxProjects";
            this.groupBoxProjects.Size = new System.Drawing.Size(490, 737);
            this.groupBoxProjects.TabIndex = 0;
            this.groupBoxProjects.TabStop = false;
            this.groupBoxProjects.Text = "Projects";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 10);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panelChatPanel);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(508, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(490, 737);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comments";
            this.groupBox1.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(484, 10);
            this.panel4.TabIndex = 1;
            // 
            // panelChatPanel
            // 
            this.panelChatPanel.AutoScroll = true;
            this.panelChatPanel.Location = new System.Drawing.Point(3, 38);
            this.panelChatPanel.Name = "panelChatPanel";
            this.panelChatPanel.Size = new System.Drawing.Size(481, 547);
            this.panelChatPanel.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddComment);
            this.panel2.Controls.Add(this.richTextBoxComment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 591);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 143);
            this.panel2.TabIndex = 0;
            // 
            // btnAddComment
            // 
            this.btnAddComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddComment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddComment.Image")));
            this.btnAddComment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddComment.Location = new System.Drawing.Point(348, 41);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(111, 60);
            this.btnAddComment.TabIndex = 2;
            this.btnAddComment.Text = "Send";
            this.btnAddComment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // richTextBoxComment
            // 
            this.richTextBoxComment.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxComment.Name = "richTextBoxComment";
            this.richTextBoxComment.Size = new System.Drawing.Size(339, 128);
            this.richTextBoxComment.TabIndex = 1;
            this.richTextBoxComment.Text = "";
            // 
            // Comments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(135)))), ((int)(((byte)(168)))));
            this.ClientSize = new System.Drawing.Size(1319, 761);
            this.Controls.Add(this.groupBoxProjects);
            this.Controls.Add(this.groupBox1);
            this.Name = "Comments";
            this.Text = "Comments";
            this.groupBoxProjects.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProjects;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelChatPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.RichTextBox richTextBoxComment;
    }
}