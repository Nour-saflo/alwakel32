namespace Al_Wakel_Pro_move_1.Forms
{
    partial class frmMangerCurrncey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMangerCurrncey));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.currencyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.currencyBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(782, 557);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            // 
            // currencyBindingSource
            // 
            this.currencyBindingSource.DataSource = typeof(Al_Wakel_Pro_move_1.Model.Currency);
            this.currencyBindingSource.CurrentChanged += new System.EventHandler(this.currencyBindingSource_CurrentChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colQuantity,
            this.colCurrencyCode,
            this.colIsDelete});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colId
            // 
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.AppearanceHeader.Options.UseTextOptions = true;
            this.colId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = "رقم العملة";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 4;
            this.colId.Width = 94;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "اسم العملة ";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 25;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 94;
            // 
            // colQuantity
            // 
            this.colQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.colQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.colQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQuantity.Caption = "المبلغ الموجود";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.MinWidth = 25;
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 1;
            this.colQuantity.Width = 94;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCurrencyCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrencyCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCurrencyCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCurrencyCode.Caption = "رمز العملة";
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.MinWidth = 25;
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.Visible = true;
            this.colCurrencyCode.VisibleIndex = 2;
            this.colCurrencyCode.Width = 94;
            // 
            // colIsDelete
            // 
            this.colIsDelete.AppearanceCell.Options.UseTextOptions = true;
            this.colIsDelete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsDelete.Caption = "حالة حذف العملة ";
            this.colIsDelete.FieldName = "IsDelete";
            this.colIsDelete.MinWidth = 25;
            this.colIsDelete.Name = "colIsDelete";
            this.colIsDelete.Visible = true;
            this.colIsDelete.VisibleIndex = 0;
            this.colIsDelete.Width = 94;
            // 
            // frmMangerCurrncey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 557);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("frmMangerCurrncey.IconOptions.LargeImage")));
            this.Name = "frmMangerCurrncey";
            this.Text = "إدارة العملات";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmMangerCurrncey_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMangerCurrncey_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currencyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
        private System.Windows.Forms.BindingSource currencyBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colIsDelete;
    }
}