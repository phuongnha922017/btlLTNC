using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeTNCoffeShop.tdo;

namespace WeTNCoffeeShop.tdo
{
    public class BillModel
    {
        public BillModel() { }
        public BillModel(string perprice, string amount, string groupProduct, string nameProduct, string quantity)
        {
            this.Perprice = perprice;
            this.Amount = amount;
            this.GroupProduct = groupProduct;
            this.NameProduct = nameProduct;
            this.Quantity = quantity;
        }
        private string perprice;
        private string amount;
        private string groupProduct;
        private string nameProduct;
        private string quantity;
        public string Perprice { get { return perprice; } set { perprice = value; } }
        public string Amount { get { return amount; } set { amount = value; } }
        public string GroupProduct { get { return groupProduct; } set { groupProduct = value; } }
        public string NameProduct { get { return nameProduct; } set { nameProduct = value; } }
        public string Quantity { get { return quantity; } set { quantity = value; } }


    }
}
