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
    public partial class stting : Form
    {
        public stting()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
           Adding_and_withdrawing bb =new Adding_and_withdrawing();
            bb.Show();

        }
    }
}
