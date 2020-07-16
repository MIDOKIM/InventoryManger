using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;

namespace InventoryManger
{
    public partial class frm_Sell : Form
    {
        Dictionary<int,Product> Products;
        private Bill Bill = new Bill();
        public frm_Sell()
        {
            InitializeComponent();
        }
        private void RefreshProducts()
        {
            var dt = Database.SELECT("SELECT * FROM Product;");
            Products = dt.Rows.Cast<DataRow>().Select(x => new Product(x)).ToDictionary(z => z.ID);
            cb_name.Items.Clear();
            cb_name.Items.AddRange(Products.Values.ToArray());
        }
        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var p in Bill.Products.Values)          
                dataGridView1.Rows.Add(p.Name, p.Price, p.Quantity, p.Price * p.Quantity);
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshProducts();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            Product p = (Product)cb_name.SelectedItem;
            if (p == null|| p.Quantity ==0)
                return;
            Bill.AddProduct(new Product(p.ID, p.Name, (int)num_Qty.Value, p.Price));
            Products[p.ID].Quantity -= (int)num_Qty.Value;
            RefreshDataGrid();
            cb_name_SelectedValueChanged(null, null);
        }
        
        private void cb_name_SelectedValueChanged(object sender, EventArgs e)
        {
            Product p = (Product)cb_name.SelectedItem;
            if (p == null)
                return;
            num_Qty.Maximum = p.Quantity;
            lbl_qty.Text = p.Quantity.ToString();
            if (p.Quantity == 0)
            {
                num_Qty.Value = 0;
                MessageBox.Show("Selected Item is out of stock");
                return;
            }
            num_Qty.Minimum = 1;
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            
            Bill.Finish();
            this.Close();
        }
    }
}
