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
    public partial class frm_ViewBill : Form
    {
        public frm_ViewBill(int BillID)
        {
            InitializeComponent();
            var dt = Database.SELECT($"SELECT Bill.Date,Product.Name,Bill_Products.ProdPrice,Bill_Products.Quantity,Bill_Products.ProdPrice*Bill_Products.Quantity AS Total FROM Bill INNER JOIN Bill_Products ON Bill.BillID=Bill_Products.BillID INNER JOIN Product ON Bill_Products.ProdID=Product.ID WHERE Bill.BillID={BillID};");

            dataGridView1.DataSource = dt;
            int total = 0;
            foreach (DataRow row in dt.Rows)
                total += Convert.ToInt32(row.ItemArray[dt.Columns.Count - 1]);
            lbl_Total.Text = total.ToString();
        }

        private void frm_ViewBill_Load(object sender, EventArgs e)
        {

        }
    }
}
