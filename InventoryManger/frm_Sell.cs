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
    public partial class frm_Sell : Form
    {
        DataTable CurrentBill;
        public frm_Sell()
        {
            InitializeComponent();
            CurrentBill = new DataTable();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            CurrentBill.Rows.Add();
        }
    }
}
