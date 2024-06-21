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

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class FrmMangerAccount : DevExpress.XtraEditors.XtraForm
    {
        AppDataContext _context;
        IUserRepository _userRepository;
        private int _userId;

        public FrmMangerAccount()
        {
            InitializeComponent();
            _context = new AppDataContext();
            _userRepository = new UserRepository(_context);
            LoadData();
        }

        private async void LoadData()
        {
            using (AppDataContext ccc = new AppDataContext())
            {
                var users = await ccc.User.Where(r => !r.Role.Equals("admin")).ToListAsync();
                gridControl1.DataSource = users;
                gridView1.FocusedRowHandle = 0;
            }
        }
        private   void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks >= 2 && e.Button == MouseButtons.Left)
            {
                var _user =   _userRepository.GetById(_userId);
                EditUSer editUSer = new EditUSer(_user);
                editUSer.ShowDialog();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int focusedRowHandle = gridView1.FocusedRowHandle;
            if (focusedRowHandle >= 0)  
            {
                _userId = Convert.ToInt32(gridView1.GetRowCellValue(focusedRowHandle, "Id"));
            }
        }
    }
}