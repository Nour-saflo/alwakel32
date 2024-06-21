using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Forms;
using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Repository;
using Al_Wakel_Pro_move_1.Resourse;
using Al_Wakel_Pro_move_1.Services;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Al_Wakel_Pro_move_1.pll
{
    public partial class frmAcount : XtraForm
    {
        AppDataContext _context;
        private Customer selectedCustomer;
        private int customerId;
        IUserRepository _userRepository;
        List<Customer> _customers;
        int countEdit = 0;

        public frmAcount()
        {
            InitializeComponent();
            _context = new AppDataContext();
            _userRepository = new UserRepository(_context);
            LoadData();
            CheckRole();
            InintMenuStrip();
        }

        private void CheckRole()
        {
            var _user = _userRepository.GetById(GlobalUser.Id);
            //if(!_user.Role.Equals("admin"))
            //{
            //   btn_AddAcountCustomer.Enabled = false;
            //   btn_AddAcountCustomer.Visible = false;
            //}
        }

        private   void LoadData()
        {
            _customers =  _context.Customer.ToList();
            gridControl1.DataSource = _customers;
            gridView1.FocusedRowHandle = 0;
        }

        private void btn_AddAcountCustomer_Click(object sender, EventArgs e)
        {
            frmCustmer frmAddCustomer= new frmCustmer(new Customer(), TagResourse.AddCustomer);
            frmAddCustomer.ShowDialog();
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                CustomerInformation customerInformation = new CustomerInformation(selectedCustomer);
                customerInformation.ShowDialog();
            }
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
              selectedCustomer = gridView1.GetFocusedRow() as Customer;
            customerId= selectedCustomer.Id;
        }

        private async void label1_Click(object sender, EventArgs e)
        {
            //var xx = await _context.Operation.Where(cc => cc.Name.Equals("إضافة")).SumAsync(q => q.Quantity);
            //XtraMessageBox.Show("إجمالي المدفوع: " + xx);
            //var xxx = await _context.Operation.Where(cc => cc.Name.Equals("قبض")).SumAsync(q => q.Quantity);
            //XtraMessageBox.Show("إجمالي المقبوض: " + xxx);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource= _customers
                .Where(x=>x.Name.Contains(txt_Search.Text.Trim())
                        ||x.Id.ToString().Contains(txt_Search.Text.Trim()))
                .ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAcount_Load(object sender, EventArgs e)
        {
            LoadData();
            CheckRole();
        }
        private void InintMenuStrip()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("تعديل");
            contextMenuStrip.Items.Add(deleteMenuItem);
            deleteMenuItem.Click += DeleteMenuItem_Click;
            this.ContextMenuStrip = contextMenuStrip;

        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedCustomer is null)
            {
                XtraMessageBox.Show("من فضلك قم باختيار عميل", "تعديل العميل");
            }
            else
            {
                try
                {
                    var customerX = _context.Customer.Where(x => x.Id ==customerId).AsNoTracking().FirstOrDefault();
                    var result = XtraMessageBox.Show(" هل انت متأكد من أنك تريد تعديل بيانات " + customerX.Name, "تعديل", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        frmCustmer frmCustmer = new frmCustmer(customerX, TagResourse.EditCustomer);
                        frmCustmer.ShowDialog();
                        HelperMessage.DoneOpertaion(this, "تم التعديل بنجاح");
                        countEdit += 1;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message+"\n"+ex?.InnerException+"\n"+ex?.InnerException?.InnerException.Message);
                }
            }

        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (countEdit == 0)
            {
                
                if (e.Button == MouseButtons.Right)
                {
                    this.ContextMenuStrip.Show(this, e.Location);
                }
            }
            else
            {
                XtraMessageBox.Show("حتى تقوم بتعديل بيانات عميل يرجى اطفاء البرنامج وإعادة تشغيله");
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void guna2ShadowPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
