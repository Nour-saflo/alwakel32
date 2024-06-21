using Al_Wakel_Pro_move_1.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.pll
{
    public partial class Adding_and_withdrawing : Form
    {
        public Adding_and_withdrawing()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_ShowAddCurncey_Click(object sender, EventArgs e)
        {
            frmAddCurncey frm= new frmAddCurncey();
            frm.ShowDialog();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
