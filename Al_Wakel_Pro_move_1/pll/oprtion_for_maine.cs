using DevExpress.Utils;
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
    public partial class oprtion_for_maine : Form
    {
        public oprtion_for_maine()
        {
            InitializeComponent();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage2;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            pll.curmer_informtion mm =new curmer_informtion();
            mm.ShowDialog();    
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage1;
        }
    }
}
