namespace Al_Wakel_Pro_move_1.Forms
{
    partial class frmMainCustomerAcount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainCustomerAcount));
            this.panel1 = new System.Windows.Forms.Panel();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.btn_AddCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.piB_IdentityImage = new System.Windows.Forms.PictureBox();
            this.btn_UploadPhoto = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_CustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txt_CustomerAddress = new DevExpress.XtraEditors.TextEdit();
            this.txt_ProviderName = new DevExpress.XtraEditors.TextEdit();
            this.txt_IdentityNumber = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piB_IdentityImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CustomerAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ProviderName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_IdentityNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.layoutControl2);
            this.panel1.Controls.Add(this.layoutControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 461);
            this.panel1.TabIndex = 0;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.btn_AddCustomer);
            this.layoutControl2.Controls.Add(this.piB_IdentityImage);
            this.layoutControl2.Controls.Add(this.btn_UploadPhoto);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(344, 461);
            this.layoutControl2.TabIndex = 1;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // btn_AddCustomer
            // 
            this.btn_AddCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddCustomer.ImageOptions.Image")));
            this.btn_AddCustomer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_AddCustomer.Location = new System.Drawing.Point(12, 401);
            this.btn_AddCustomer.Margin = new System.Windows.Forms.Padding(5);
            this.btn_AddCustomer.Name = "btn_AddCustomer";
            this.btn_AddCustomer.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.btn_AddCustomer.Size = new System.Drawing.Size(320, 48);
            this.btn_AddCustomer.StyleController = this.layoutControl2;
            this.btn_AddCustomer.TabIndex = 6;
            this.btn_AddCustomer.Text = "حفظ";
            this.btn_AddCustomer.Click += new System.EventHandler(this.btn_AddCustomer_Click);
            // 
            // piB_IdentityImage
            // 
            this.piB_IdentityImage.Location = new System.Drawing.Point(12, 12);
            this.piB_IdentityImage.Name = "piB_IdentityImage";
            this.piB_IdentityImage.Size = new System.Drawing.Size(320, 200);
            this.piB_IdentityImage.TabIndex = 4;
            this.piB_IdentityImage.TabStop = false;
            // 
            // btn_UploadPhoto
            // 
            this.btn_UploadPhoto.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_UploadPhoto.ImageOptions.Image")));
            this.btn_UploadPhoto.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btn_UploadPhoto.Location = new System.Drawing.Point(12, 216);
            this.btn_UploadPhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btn_UploadPhoto.Name = "btn_UploadPhoto";
            this.btn_UploadPhoto.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btn_UploadPhoto.Size = new System.Drawing.Size(320, 46);
            this.btn_UploadPhoto.StyleController = this.layoutControl2;
            this.btn_UploadPhoto.TabIndex = 5;
            this.btn_UploadPhoto.Text = "رفع صورة ";
            this.btn_UploadPhoto.Click += new System.EventHandler(this.btn_UploadPhoto_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(344, 461);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 254);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(324, 135);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.piB_IdentityImage;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(324, 204);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btn_UploadPhoto;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 204);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(324, 50);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btn_AddCustomer;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 389);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(324, 52);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_CustomerName);
            this.layoutControl1.Controls.Add(this.txt_CustomerAddress);
            this.layoutControl1.Controls.Add(this.txt_ProviderName);
            this.layoutControl1.Controls.Add(this.txt_IdentityNumber);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.layoutControl1.Location = new System.Drawing.Point(332, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.layoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(423, 461);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_CustomerName
            // 
            this.txt_CustomerName.Location = new System.Drawing.Point(12, 12);
            this.txt_CustomerName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CustomerName.Name = "txt_CustomerName";
            this.txt_CustomerName.Properties.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txt_CustomerName.Size = new System.Drawing.Size(318, 32);
            this.txt_CustomerName.StyleController = this.layoutControl1;
            this.txt_CustomerName.TabIndex = 4;
            // 
            // txt_CustomerAddress
            // 
            this.txt_CustomerAddress.Location = new System.Drawing.Point(12, 48);
            this.txt_CustomerAddress.Margin = new System.Windows.Forms.Padding(5);
            this.txt_CustomerAddress.Name = "txt_CustomerAddress";
            this.txt_CustomerAddress.Properties.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txt_CustomerAddress.Size = new System.Drawing.Size(318, 32);
            this.txt_CustomerAddress.StyleController = this.layoutControl1;
            this.txt_CustomerAddress.TabIndex = 4;
            // 
            // txt_ProviderName
            // 
            this.txt_ProviderName.Location = new System.Drawing.Point(12, 84);
            this.txt_ProviderName.Margin = new System.Windows.Forms.Padding(5);
            this.txt_ProviderName.Name = "txt_ProviderName";
            this.txt_ProviderName.Properties.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txt_ProviderName.Size = new System.Drawing.Size(318, 32);
            this.txt_ProviderName.StyleController = this.layoutControl1;
            this.txt_ProviderName.TabIndex = 4;
            // 
            // txt_IdentityNumber
            // 
            this.txt_IdentityNumber.Location = new System.Drawing.Point(12, 120);
            this.txt_IdentityNumber.Margin = new System.Windows.Forms.Padding(5);
            this.txt_IdentityNumber.Name = "txt_IdentityNumber";
            this.txt_IdentityNumber.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txt_IdentityNumber.Properties.MaskSettings.Set("mask", "d");
            this.txt_IdentityNumber.Properties.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txt_IdentityNumber.Size = new System.Drawing.Size(318, 32);
            this.txt_IdentityNumber.StyleController = this.layoutControl1;
            this.txt_IdentityNumber.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(423, 461);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_CustomerName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(403, 36);
            this.layoutControlItem1.Text = "اسم العميل";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_CustomerAddress;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem2.CustomizationFormText = "اسم العميل";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(403, 36);
            this.layoutControlItem2.Text = "العنوان";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(69, 17);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_ProviderName;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem3.CustomizationFormText = "اسم العميل";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(403, 36);
            this.layoutControlItem3.Text = "اسم الكفيل";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(69, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_IdentityNumber;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlItem4.CustomizationFormText = "اسم العميل";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 108);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(403, 333);
            this.layoutControlItem4.Text = "رقم الهوية";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(69, 17);
            // 
            // frmAddCustomerAcount
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 461);
            this.Controls.Add(this.panel1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmAddCustomerAcount.IconOptions.LargeImage")));
            this.InactiveGlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "frmAddCustomerAcount";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة حساب عميل";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.piB_IdentityImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_CustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CustomerAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ProviderName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_IdentityNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_CustomerName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txt_CustomerAddress;
        private DevExpress.XtraEditors.TextEdit txt_ProviderName;
        private DevExpress.XtraEditors.TextEdit txt_IdentityNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.PictureBox piB_IdentityImage;
        private DevExpress.XtraEditors.SimpleButton btn_UploadPhoto;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btn_AddCustomer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}