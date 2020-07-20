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
    public partial class frm_ViewSales : Form
    {
        public frm_ViewSales()
        {
            InitializeComponent();
        }

        private void frm_ViewSales_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Database.SELECT("SELECT Bill.BillID,Bill.Date,Count(Bill_Products.BillID) AS NProducts FROM Bill LEFT OUTER JOIN Bill_Products ON Bill.BillID=Bill_Products.BillID GROUP BY Bill.BillID,Bill.Date ORDER BY Bill.Date DESC");
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "View";
            btn.Text = "View";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex].Name =="btn")
            {
                using (var ss = new frm_ViewBill(Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value)))
                    ss.ShowDialog();
            }
        }

  
    }
}
