using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryManger
{
    public partial class frm_Add : Form
    {
        public frm_Add()
        {
            InitializeComponent();
        }

        private void frm_Add_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Name.Text) || num_Price.Value == 0 || num_Qty.Value == 0)
                return;
            Database.INSERT($"INSERT INTO Product(Name,Price,Quantity) VALUES('{txt_Name.Text}',{num_Price.Value},{num_Qty.Value})");
            RefreshTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selected = dataGridView1.DataSource;

        }
        private void RefreshTable()
        {
           
            dataGridView1.DataSource = Database.SELECT("SELECT * FROM Product;");

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dt = (DataTable)dataGridView1.DataSource;
            if (e.ColumnIndex == 0)
                return;
            Database.
                UPDATE($"UPDATE Product SET {dt.Columns[e.ColumnIndex]}='{dt.Rows[e.RowIndex][e.ColumnIndex]}' WHERE ID={dt.Rows[e.RowIndex][0]}");
        }
    }
}
