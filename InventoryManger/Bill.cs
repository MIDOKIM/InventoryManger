using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryManger
{
    public class Bill
    {
        public int ID;
        public Dictionary<int,Product> Products = new Dictionary<int, Product>();
        public void AddProduct(Product p)
        {
            if (Products.ContainsKey(p.ID))
            {
                Products[p.ID].Quantity += p.Quantity;
                return;
            }
            Products.Add(p.ID, p);
        }
        public void Finish()
        {
            if (!Products.Any())
                return;
            Database.INSERT($"INSERT INTO Bill(Date) VALUES('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')");
            var ID = Convert.ToInt32(Database.SELECT("SELECT SCOPE_IDENTITY();").Rows[0][0]);
            foreach (var item in Products)
            {
                Database.UPDATE($"UPDATE Product SET Quantity=Quantity-{item.Value.Quantity} WHERE ID={item.Key}");
                Database.INSERT($"INSERT INTO Bill_Products(BillID,ProdID,ProdPrice,Quantity) VALUES({ID},{item.Value.ID},{item.Value.Price},{item.Value.Quantity})");
            }
        }
        public void UpdatePrice(int ID,double Price)
        {
            Products[ID].Price = Price;
        }
    }
}
