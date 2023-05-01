using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
//using System.Data;
using WeTNCoffeeShop.tdo;
using WeTNCoffeeShop;

namespace WeTNCoffeShop.tdo
{//Product
    public class DrinkModel
    {
        private static DrinkModel instance;

        public static DrinkModel Instance
        {
            get { if (instance == null) instance = new DrinkModel(); return instance; }
            private set { instance = value; }
        }

        public DrinkModel()
        {
            this.productId = -1;
            this.DrinkName = "";
            this.CategoryId = -1;
            this.DrinkPrice = 0;
        }

        public DrinkModel(DataRow dr)
        {
            this.productId = (int)dr["ProductID"];
            this.DrinkName = dr["Name"].ToString();
            this.DrinkPrice = (long)dr["PerPrice"];
            this.CategoryId = (int)dr["CategoryID"];
        }
        private string name;
        private long price;
        private int categoryId;
        private int productId;
        /// <summary>
        /// Represents name of a drink
        /// </summary>
        public string DrinkName { get { return name; } set { name = value; } }
        /// <summary>
        /// Represents price of a drink (by million dong)
        /// </summary>
        public long DrinkPrice { get { return price; } set { price = value; } }
        public int CategoryId { get {  return categoryId; } set { categoryId = value; } }

        public int ProductId { get { return productId; } set { productId = value; } }

        public bool addDrink(string getDrinkName, int getCatId, long getPrice)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Product(CategoryId, Name, PerPrice) VALUES (" +
                           "@getCatId, @getDrinkName, @getPrice)", con))
                    {
                        cmd.Parameters.AddWithValue("@getDrinkName", getDrinkName);
                        cmd.Parameters.AddWithValue("@getCatId", getCatId);
                        cmd.Parameters.AddWithValue("@getPrice", getPrice);
                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }

                    con.Close();
                    return true;

                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã tồn tại, vui lòng chọn tên món khác. ERROR: " + ex);
                return false;
            }


        }
        public void removeDrink(int getProductId)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE ProductID = '" +
                       getProductId + "'", con))
                {
                    
                    int rows = cmd.ExecuteNonQuery();

                    //rows number of record got inserted
                }
                con.Close();
            }
        }

        public void changePrice(int getProductId, long getNewPrice)
        {
            SqlConnection conn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = CoffeeShop; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("UPDATE Product SET Perprice = '" + getNewPrice + "' WHERE ProductID = '" + getProductId + "'", conn);
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
        }
    }
}
