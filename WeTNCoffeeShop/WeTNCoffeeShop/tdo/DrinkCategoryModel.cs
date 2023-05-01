using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTNCoffeShop.tdo
{// Category
    public class DrinkCategoryModel
    {

        private int categoryId;
       
        private string name;
        public DrinkCategoryModel(int categoryId, string name)
        {
            this.categoryId = categoryId;
            this.name = name;  
        }
        public DrinkCategoryModel(DataRow dr)
        {
            categoryId = (int)dr["CategoryID"];
            name = dr["Name"].ToString();
        }
        public  int CategoryId { get { return categoryId; } set { categoryId = value; } }

        public string CategoryName { get { return name; } set { name = value; } }
        /// <summary>
        /// Represents list of drink inside category
        /// </summary>
        /// 
        public List<DrinkModel> getDrinkList()

        {
            List<DrinkModel> drinkModels = new List<DrinkModel>();
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from [Product] where CategoryID = '" + this.CategoryId + "'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DrinkModel newTable = new DrinkModel(dr);
                drinkModels.Add(newTable);
            }
            conn.Close();
            return drinkModels;
        }
    }
}
