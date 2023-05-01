using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTNCoffeShop.tdo;
using System.Windows.Forms;

namespace WeTNCoffeeShop.tdo
{
    public class AreaModel
    {
        public AreaModel(int id, string name)
        {
            this.AreaId = id;
            this.Name = name;
        }
        public AreaModel(DataRow dr)
        {
            this.AreaId = (int)dr["AreaID"];
            this.Name = dr["Name"].ToString();
        }

        private int id;
        private string name;
        public int AreaId { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }

        public List<TableModel> getTableList()
        {
            List<TableModel> tableList = new List<TableModel>();
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from [Table] where AreaID = '" + this.AreaId + "'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TableModel newTable = new TableModel(dr);
                tableList.Add(newTable);
            }
            conn.Close();
            return tableList;
        }

        

    }
}
