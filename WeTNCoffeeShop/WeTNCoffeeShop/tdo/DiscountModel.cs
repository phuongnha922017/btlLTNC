using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTNCoffeeShop.tdo;

namespace WeTNCoffeShop.tdo
{// BillInfo's child
    public class DiscountModel
    {
        private DiscountModel() { }
        private long amount;
        private int discount;
        /// <summary>
        /// Represents the amount of discount (by million dong)
        /// </summary>
        public long DiscountAmount { get { return amount; } set { amount = value; } }
        /// <summary>
        /// Represents the percentage of discount (by %)
        /// </summary>
        public int DiscountPercentage { get { return discount; } set { discount = value; } }

    }
}
