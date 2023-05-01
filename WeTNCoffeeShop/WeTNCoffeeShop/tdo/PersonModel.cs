using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTNCoffeeShop.tdo;

namespace WeTNCoffeShop.tdo
{//Bill's Child
    // CustomerListModel's Child
    public class PersonModel
    {
        private PersonModel() { }
        private string name;
        private string phonenumber;
        private int points;

        public string Name { get { return name; } set { name = value; } }
        public string CellPhoneNumber { get { return phonenumber; } set { phonenumber = value; } }
        /// <summary>
        /// Represents points that a customer have accumulated
        /// </summary>
        public int Points { get { return points; } set { points = value; } }
    }
}
