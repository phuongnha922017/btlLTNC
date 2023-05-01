using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
//using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;

namespace WeTNCoffeShop.tdo
{
    public class CategoryListModel
    {
        private static CategoryListModel instance;
       
        public static CategoryListModel Instance
        {
            get { if (instance == null) instance = new CategoryListModel(); return instance; }
            private set { instance = value; }
        }
  
        
        /// <summary>
        /// Represents total number of drink categories
        /// </summary>
        public int NumOfCategory { get; set; }
        /// <summary>
        /// Represents list of categories in system
        /// </summary>
        public List<DrinkCategoryModel> CategoryList { get; set; } = new List<DrinkCategoryModel>();
        
        //Add new category to category table in DB
        public bool addGroup(string getCategoryName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Category(Name) VALUES (" +
                           "@getCategoryName)", con))
                    {
                        cmd.Parameters.AddWithValue("@getCategoryName", getCategoryName);
                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }
                  
                        con.Close();
                        return true;

                }
                
         
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã tồn tại, vui lòng chọn tên nhóm món khác. ERROR: " + ex);
                return false;
            }
            

        }

        //Get list of all categories in DB
        public CategoryListModel GetCategoryList()
        {
            CategoryListModel catList = new CategoryListModel();
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from [Category]", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DrinkCategoryModel newCat = new DrinkCategoryModel(dr);
                catList.CategoryList.Add(newCat);
            }
            catList.NumOfCategory = catList.CategoryList.Count;
            conn.Close();
            return catList;
        }

        public void removeCategory(int getCategoryId)
        {
              using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
              {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Category WHERE CategoryID = '" +
                           getCategoryId + "'", con))
                    {
                        //cmd.Parameters.AddWithValue("@getCategoryName", getCategoryName);
                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }
                    con.Close();
               }
           
        
        }
    }
}
