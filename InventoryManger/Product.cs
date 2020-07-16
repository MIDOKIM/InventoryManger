using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace InventoryManger
{
    public class Product
    {
        public int ID;
        public string Name; 
        public int Quantity;
        public double Price;
        public Product(DataRow dr)
        {
            ID = Convert.ToInt32(dr[0]);
            Name = Convert.ToString(dr[1]);
            Price = Convert.ToDouble(dr[2]);
            Quantity = Convert.ToInt32(dr[3]);

        }

        public Product(int iD, string name, int quantity, double price)
        {
            ID = iD;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
