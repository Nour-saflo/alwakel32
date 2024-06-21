using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.CodedUISupport;

namespace Al_Wakel_Pro_move_1.Core
{
    public class ExportData
    {
        public static void ExportToExcel(string filePath,GridControl gridControl)
        {
            GridView gridView = gridControl.MainView as GridView;

            if (gridView != null)
            {
                gridView.ExportToXlsx(filePath);
            }
        }

        public static string GetSaveFilePath(string defaultFileName)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = defaultFileName+ ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return null; // User canceled the dialog
        }
        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(ms);
                 
            }

        }
    }
}
