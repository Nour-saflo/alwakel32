namespace Al_Wakel_Pro_move_1.Forms
{
    partial class frmConfirmPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmPass));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Password = new DevExpress.XtraEditors.TextEdit();
            this.btn_Verfiy = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Almarai Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(332, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "ادخل كلمة السر";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(153, 98);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Properties.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(169, 20);
            this.txt_Password.TabIndex = 1;
            // 
            // btn_Verfiy
            // 
            this.btn_Verfiy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Verfiy.ImageOptions.Image")));
            this.btn_Verfiy.Location = new System.Drawing.Point(179, 152);
            this.btn_Verfiy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Verfiy.Name = "btn_Verfiy";
            this.btn_Verfiy.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Verfiy.Size = new System.Drawing.Size(104, 40);
            this.btn_Verfiy.TabIndex = 2;
            this.btn_Verfiy.Text = "تحقق ";
            this.btn_Verfiy.Click += new System.EventHandler(this.btn_Verfiy_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(447, 2);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(39, 35);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.ToolTip = "إغلاق";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Almarai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "التحقق من بيانات المستخدم ";
            // 
            // frmConfirmPass
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(153)))), ((int)(((byte)(94)))));
            this.Appearance.ForeColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 332);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btn_Verfiy);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmConfirmPass.IconOptions.SvgImage")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmConfirmPass";
            this.Text = "24; 153; 94";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConfirmPass_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txt_Password;
        private DevExpress.XtraEditors.SimpleButton btn_Verfiy;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label2;
    }
}