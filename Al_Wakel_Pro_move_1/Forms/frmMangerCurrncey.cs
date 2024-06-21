using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class frmMangerCurrncey : DevExpress.XtraEditors.XtraForm
    {
        AppDataContext _context = new AppDataContext();
        private int selectedId = 0;

        public frmMangerCurrncey()
        {
            InitializeComponent();
            LoadData();
            InintMenuStrip();

        }

        private void InintMenuStrip()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("حذف");
            contextMenuStrip.Items.Add(deleteMenuItem);
            deleteMenuItem.Click += DeleteMenuItem_Click;
            this.ContextMenuStrip = contextMenuStrip;

        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                XtraMessageBox.Show("من فضلك قم باختيار عملة", "اختيار عملة");
            }
            else
            {
                try
                {
                    var curencey = _context.Currency.Where(x => x.Id == selectedId).FirstOrDefault();
                    var result = XtraMessageBox.Show("هل انت متأكد من أنك تريد حذف العملة" + curencey.Name, "حذف عملة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        curencey.IsDelete = true;
                        _context.Entry(curencey).State = System.Data.Entity.EntityState.Modified; // Indicate that the entity is modified
                        _context.SaveChanges();
                        CurrnceyMang.isUpdateing=true;
                        HelperMessage.DoneOpertaion(this, "تم حذف العملة بنجاح");
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message);
                }
            }

        }
        private void LoadData()
        {
            gridControl1.DataSource = _context.Currency.ToList();
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void currencyBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void frmMangerCurrncey_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void frmMangerCurrncey_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ContextMenuStrip.Show(this, e.Location);
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            selectedId = (int)gridView1.GetFocusedRowCellValue("Id");
        }
    }
}