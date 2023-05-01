using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTNCoffeShop.tdo
{
    public class CustomerListModel
    {
        /// <summary>
        /// Represents number of customerss that are in the system
        /// </summary>
        public int CustomerInSystemCount{ get; set; }
        /// <summary>
        /// Represetns list of customers that are in the system
        /// </summary>
        public List<PersonModel> CustomerList { get; set; } = new List<PersonModel>();

    }
}
