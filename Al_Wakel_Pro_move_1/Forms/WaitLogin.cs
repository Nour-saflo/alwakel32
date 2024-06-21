using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Forms
{
    public partial class WaitLogin : WaitForm
    {
        public WaitLogin()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }
        #region Overrides
        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
   
        #endregion

        public enum WaitFormCommand
        {
        }

        private void progressPanel1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}