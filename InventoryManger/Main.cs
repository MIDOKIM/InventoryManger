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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frm_Sell ss = new frm_Sell())
                ss.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ss = new frm_Add())
                ss.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Database.Load();

        }
    }
}
