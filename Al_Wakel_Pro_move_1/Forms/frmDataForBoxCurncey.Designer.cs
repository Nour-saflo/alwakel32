namespace Al_Wakel_Pro_move_1.Forms
{
    partial class frmDataForBoxCurncey
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
            this.pareintPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pareintPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pareintPanel
            // 
            this.pareintPanel.Controls.Add(this.bodyPanel);
            this.pareintPanel.Controls.Add(this.topPanel);
            this.pareintPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pareintPanel.Location = new System.Drawing.Point(0, 0);
            this.pareintPanel.Name = "pareintPanel";
            this.pareintPanel.Size = new System.Drawing.Size(1114, 694);
            this.pareintPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1114, 88);
            this.topPanel.TabIndex = 0;
            // 
            // bodyPanel
            // 
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 88);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(1114, 606);
            this.bodyPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(302, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "معلومات بكل شئ دخل وخرج من الصندوق ";
            // 
            // frmDataForBoxCurncey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 694);
            this.Controls.Add(this.pareintPanel);
            this.Name = "frmDataForBoxCurncey";
            this.Text = "frmDataForBoxCurncey";
            this.pareintPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pareintPanel;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label label1;
    }
}