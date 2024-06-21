using Al_Wakel_Pro_move_1.Forms;
using Al_Wakel_Pro_move_1.login;
using Al_Wakel_Pro_move_1.pll;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1
{
    public partial class Form1 : XtraForm
    {

        pll.Main fr_maine;
        pll.OprationForMaine fr_ofm;
        pll.Report reportt;
        pll.Setting steting;
        frmLogin frmLogin;
        private frmAcount fr_acont;
        static public bool isDone;
        private static readonly object frMaineLocker = new object();
        private static readonly object frOfmLocker = new object();
        private static readonly object reporttLocker = new object();
        private static readonly object frAcontLocker = new object();
        public Form1()
        {
            InitializeComponent();
            //InitializeComponentAppLaction();
            Login();
        }
        private void Login()
        {
            try
            {
                frmLogin = new frmLogin();
                frmLogin.ShowDialog();
                if (frmLogin.isLogin)
                {
                    SplashScreenManager.ShowForm(typeof(WaitLogin));
                   
                        fr_maine = new Main();
                        fr_ofm = new pll.OprationForMaine();
                        reportt = new Report();
                        fr_acont = new pll.frmAcount();
                         steting = new Setting();
                    SplashScreenManager.CloseForm();
                }
                else
                {
                    HandleLoginFailure();
                }
            }
            catch (Exception ex)
            {
                HandleExceptionDuringLogin(ex);
            }
            finally
            {
                if (frmLogin != null)
                {
                    frmLogin.Dispose();
                }
            }
        }
        private void HandleExceptionDuringLogin(Exception ex)
        {
            MessageBox.Show($"حدث خطأ أثناء إنشاء واجهة تسجيل الدخول: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
        private void HandleLoginFailure()
        {
            MessageBox.Show("فشل في تسجيل الدخول. سيتم إغلاق التطبيق.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
        bool isFormsCreationComplete = false;
        private async Task CreateAndAwaitForms()
        {
            await Task.Run(() =>
            {
                fr_maine = new Main();
            });

            await Task.Run(() =>
            {
                fr_ofm = new pll.OprationForMaine();
            });

            await Task.Run(() =>
            {
                reportt = new Report();
            });

            await Task.Run(() =>
            {
                steting = new Setting();
            });

            await Task.Run(() =>
            {
                fr_acont = new pll.frmAcount();
            });
            isFormsCreationComplete = true;
        }
        private void  movepanel(Control c)
        {
            p22.Visible = false;
            p22.Width = c.Width;
            p22.Left=c.Left;
            bunifuTransition1.ShowSync(p22);
        }
        private void bunifuImageButton13_Click(object sender, EventArgs e)
        {
       
            panel4.Controls.Clear();
            fr_maine.SetData();
            fr_maine.panel1.Width = panel4.Width;
            fr_maine.panel1.Height = panel4.Height;
            panel4.Controls.Add(fr_maine.panel1);
            movepanel(bunifuImageButton13);

            /// bunifuTransition1.ShowSync(fr_maine.panel1);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
           
            panel4.Controls.Clear();
            fr_ofm.panel1.Width = panel4.Width;
            fr_ofm.panel1.Height = panel4.Height;
            panel4.Controls.Add(fr_ofm.panel1);
            movepanel(bunifuImageButton2);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
            panel4.Controls.Clear();
            fr_acont.panel1.Width = panel4.Width;
            fr_acont.panel1.Height = panel4.Height;
            panel4.Controls.Add(fr_acont.panel1);
            movepanel(bunifuImageButton1);
        }
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
      
            panel4.Controls.Clear();
            steting.panel1.Width = panel4.Width;
            steting.panel1.Height = panel4.Height;
            panel4.Controls.Add(steting.panel1);
            movepanel(bunifuImageButton3);
        }
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
        
            panel4.Controls.Clear();
            reportt.panel1.Width = panel4.Width;
            reportt.panel1.Height = panel4.Height;
            panel4.Controls.Add(reportt.panel1);
            movepanel(bunifuImageButton4);
        }


        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            /*1061; 668*/
            if (this.Height == 740 & this.Width == 1172)
            {
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Location = new Point(0, 0);
            }
            else
            {
                this.Height = 740;
                this.Width = 1172;
                this.CenterToScreen();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            bunifuImageButton13_Click(sender, e);
        }
        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            string whatsappNumber = "+352681539607";
            string whatsappUrl = "https://wa.me/" + whatsappNumber;
            try
            {
                Process.Start(whatsappUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open WhatsApp: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {
            string facebookProfileUrl = "https://www.facebook.com/profile.php?id=61552252292560&mibextid=ZbWKwL";
            try
            {
                Process.Start(facebookProfileUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the Facebook profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            string instgramProfileUrl = "https://www.instagram.com/master_code4?igsh=MWQzN2Jscmh3NnI1cQ==";
            try
            {
                Process.Start(instgramProfileUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the Facebook profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {

            if (pt.Height == 57)
            {
                pt.Height = 0;
            }
            else
            {
                pt.Height = 57;
                pt.Visible = false;
                bunifuTransition2.ShowSync(pt);
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            string instgramProfileUrl = "https://youtube.com/@master_code30?si=CnFgDnftI49zMijk";
            try
            {
                Process.Start(instgramProfileUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to open the Facebook profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
