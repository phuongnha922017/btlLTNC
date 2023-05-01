using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTNCoffeShop.tdo;
using System.Windows.Forms;

namespace WeTNCoffeeShop.tdo
{
    public class AreaListModel
    {
        private AreaListModel() { }
        private static AreaListModel instance;

        public static AreaListModel Instance
        {
            get { if (instance == null) instance = new AreaListModel(); return instance; }
            private set { instance = value; }
        }
        private int totalArea;
        //private int areaInUse;
        public int TotalArea { get { return totalArea; } set { totalArea = value; } }
        //public int AreaInUse { get { return AreaInUse; } set { AreaInUse = value; } }
        public List<AreaModel> getListArea()
        {
            List<AreaModel> AreaList = new List<AreaModel>();
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Area", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                AreaModel newArea = new AreaModel(dr);
                AreaList.Add(newArea);
            }
            conn.Close();
            this.TotalArea = AreaList.Count;
            return AreaList;
        }

        public bool addArea(string getAreaName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Area(Name) VALUES (" +
                           "@getAreaName)", con))
                    {
                        cmd.Parameters.AddWithValue("@getAreaName", getAreaName);
                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }

                    con.Close();
                    return true;

                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Đã tồn tại, vui lòng chọn tên khu vực khác. ERROR: " + ex);
                return false;
            }
        }

        public void removeArea(int getAreaId)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Area WHERE AreaID = '" +
                       getAreaId + "'", con))
                {
                    int rows = cmd.ExecuteNonQuery();

                    //rows number of record got inserted
                }
                con.Close();
            }
        }
    }
}
