using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Wakel_Pro_move_1.Core
{
    public static class BackUpDataBase
    {
        public static string GetBackupFilePath()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Backup Files (*.bak)|*.bak|All Files (*.*)|*.*";
                saveFileDialog.Title = "Select Backup File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
            }
            return null;
        }
        public static void BackupDatabase(string connectionString, string backupFilePath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlCommand = $"BACKUP DATABASE [{connection.Database}] TO DISK = @backupFilePath";

                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.Parameters.AddWithValue("@backupFilePath", backupFilePath);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
