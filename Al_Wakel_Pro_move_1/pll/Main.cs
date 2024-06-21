using Al_Wakel_Pro_move_1.Core;
using Al_Wakel_Pro_move_1.Model;
using Al_Wakel_Pro_move_1.Repository;
using Al_Wakel_Pro_move_1.Services;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Commands;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.pll
{
    public partial class Main : XtraForm
    {
        private readonly AppDataContext _context;
        private readonly IUserRepository _userRepo;
        private User _user;

        public Main()
        {
            InitializeComponent();
            _context = new AppDataContext();
            _userRepo = new UserRepository(_context);
            LoadPersonalData();
            this.Load += Main_Load;
        }

        private   void Main_Load(object sender, EventArgs e)
        {
              SetData();
        }

        public   void SetData()
        {
              UpdateCurrencyData();
          //    LoadCombinedChartData();
        }
        private async void LoadCombinedChartData()
        {
            var allOperations = await _context.Operation
                                              .Include(o => o.Customer)
                                              .Include(o => o.Currency)
                                              .ToListAsync();
            var groupedByCustomer = allOperations.GroupBy(operation => operation.Customer.Name);
            var combinedData = new List<(string CustomerName, string CurrencyType, string OperationName, decimal TotalQuantity)>();

            foreach (var customerGroup in groupedByCustomer)
            {
                var customerName = customerGroup.Key;
                var groupedByCurrencyType = customerGroup.GroupBy(operation => operation.Currency.Name);

                foreach (var currencyGroup in groupedByCurrencyType)
                {
                    var currencyType = currencyGroup.Key;
                    var operationsGroupedByName = currencyGroup.GroupBy(operation => operation.Name);

                    foreach (var operationGroup in operationsGroupedByName)
                    {
                        var operationName = operationGroup.Key;
                        var totalQuantityForOperation = operationGroup.Sum(operation => operation.Quantity);
                        combinedData.Add((customerName, currencyType, operationName, totalQuantityForOperation));
                    }
                }
            }
            // Clear the existing series in the chart
            chartControl1.Series.Clear();

            // Create a new series for the combined data
            Series combinedSeries = new Series("Transaction", ViewType.Bar);

            // Add data points to the combined series
            foreach (var data in combinedData)
            {
                SeriesPoint point = new SeriesPoint($"{data.CustomerName} - {data.CurrencyType} - {data.OperationName}", data.TotalQuantity);
                combinedSeries.Points.Add(point);
            }

            // Add the combined series to the chart
            chartControl1.Series.Add(combinedSeries);

            // Set axis titles and chart title
            ((XYDiagram)chartControl1.Diagram).AxisX.Title.Text = "Customer - Currency - Operation";
            ((XYDiagram)chartControl1.Diagram).AxisY.Title.Text = "Quantity";
            chartControl1.Titles.Add(new ChartTitle() { Text = "Customer Transactions" });

            // Refresh the chart
            chartControl1.Refresh();

            MessageBox.Show("Chart data loaded successfully.");
        }


        private void LoadPersonalData()
        {
            try
            {
                lbl_Name.Text = GlobalUser.Name;
                lbl_CompanyName.Text = GlobalUser.CompanyName;
                lbl_Number.Text = GlobalUser.PhoneNumber.ToString();
                lbl_Address.Text = GlobalUser.Address;
                CultureInfo en = CultureInfo.GetCultureInfo("en-Us");
                label68.Text = DateTime.Now.ToString("yyyy-MM-dd", en);
                label35.Text = DateTime.Now.ToString("hh:mm");
                LoadImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading personal data: " + ex.Message);
            }
        }

        private void UpdateCurrencyData()
        {
            try
            {
                using (var context = new AppDataContext())
                {
                    var currencyData =  context.Currency.Where(x => (bool)!x.IsDelete).ToList();
                    gridControl1.DataSource = currencyData;
                }
            }
            catch (Exception ex)
            {
                Clipboard.SetText("An error occurred while updating currency data: " + ex.Message);
                MessageBox.Show("An error occurred while updating currency data: " + ex.Message);
            }
        }

        private void LoadImage()
        {
            if (GlobalUser.Image != null)
            {
                guna2CirclePictureBox2.Image = ExportData.byteArrayToImage(GlobalUser.Image);
            }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_Number_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_Address_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

