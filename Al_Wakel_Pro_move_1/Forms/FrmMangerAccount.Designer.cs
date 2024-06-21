namespace Al_Wakel_Pro_move_1.Forms
{
    partial class FrmMangerAccount
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentityNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrnceyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemToggleSwitch1 = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1207, 604);
            this.panel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.userBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemToggleSwitch1});
            this.gridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl1.Size = new System.Drawing.Size(1207, 604);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Al_Wakel_Pro_move_1.Model.User);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colIdentityNumber,
            this.colCurrnceyName,
            this.colAddress,
            this.colUserName,
            this.colIsActive});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colId
            // 
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.AppearanceHeader.Options.UseTextOptions = true;
            this.colId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = "الرقم";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 94;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "الاسم";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 25;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 94;
            // 
            // colIdentityNumber
            // 
            this.colIdentityNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colIdentityNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIdentityNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colIdentityNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIdentityNumber.Caption = "رقم الجوال";
            this.colIdentityNumber.FieldName = "IdentityNumber";
            this.colIdentityNumber.MinWidth = 25;
            this.colIdentityNumber.Name = "colIdentityNumber";
            this.colIdentityNumber.Visible = true;
            this.colIdentityNumber.VisibleIndex = 2;
            this.colIdentityNumber.Width = 94;
            // 
            // colCurrnceyName
            // 
            this.colCurrnceyName.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrnceyName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrnceyName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrnceyName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrnceyName.Caption = "اسم الشركة";
            this.colCurrnceyName.FieldName = "CurrnceyName";
            this.colCurrnceyName.MinWidth = 25;
            this.colCurrnceyName.Name = "colCurrnceyName";
            this.colCurrnceyName.Visible = true;
            this.colCurrnceyName.VisibleIndex = 3;
            this.colCurrnceyName.Width = 94;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "العنوان";
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 25;
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            this.colAddress.Width = 94;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.Caption = "اسم المستخدم";
            this.colUserName.FieldName = "UserName";
            this.colUserName.MinWidth = 25;
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 5;
            this.colUserName.Width = 94;
            // 
            // colIsActive
            // 
            this.colIsActive.AppearanceCell.Options.UseTextOptions = true;
            this.colIsActive.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsActive.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsActive.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsActive.Caption = "حالة الحساب";
            this.colIsActive.ColumnEdit = this.repositoryItemToggleSwitch1;
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.MinWidth = 25;
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 6;
            this.colIsActive.Width = 94;
            // 
            // repositoryItemToggleSwitch1
            // 
            this.repositoryItemToggleSwitch1.AutoHeight = false;
            this.repositoryItemToggleSwitch1.Name = "repositoryItemToggleSwitch1";
            this.repositoryItemToggleSwitch1.OffText = "Off";
            this.repositoryItemToggleSwitch1.OnText = "On";
            // 
            // FrmMangerAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 604);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FrmMangerAccount";
            this.Text = "إدارة الحسابات";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource userBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentityNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrnceyName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch1;
    }
}