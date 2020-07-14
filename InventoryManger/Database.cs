using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryManger
{
    public static class Database
    {
        private const string myconnstrng = "Data Source=(local);Initial Catalog=InventoryManger;Integrated Security=True";
        private static SqlConnection conn = new SqlConnection(myconnstrng);

        public static void Load()
        {
            conn.Open();
        }
        public static DataTable SELECT(string query)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static bool UPDATE(string query)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static bool INSERT(string query)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
    }
}

