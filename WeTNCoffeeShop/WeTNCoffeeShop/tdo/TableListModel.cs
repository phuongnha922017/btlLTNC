using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeTNCoffeShop.tdo
{
    public class TableListModel
    {
        private TableListModel() { }
        private static TableListModel instance;

        public static TableListModel Instance
        {
            get { if (instance == null) instance = new TableListModel(); return instance; }
            private set { instance = value; }
        }
        private int totalTable;
        private int tableInUse;
        /// <summary>
        /// Total number of table in the system
        /// </summary>
        public int TotalTable { get { return totalTable; } set { totalTable = value; } }
        /// <summary>
        /// Number of table that are busy
        /// </summary>
        public int TableInUse { get { return tableInUse; } set { tableInUse = value; } }
        public List<TableModel> getListTable(int AreaId)
        {
            List<TableModel> TablemodelList = new List<TableModel>();
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from [Table] where AreaID = '" + AreaId + "'", conn);    
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                TableModel newTable = new TableModel(dr);
                TablemodelList.Add(newTable);
            }
            this.totalTable = TablemodelList.Count;
            conn.Close();
            return TablemodelList;
        }

    public List<TableModel> getAllTable()
        {
            List<TableModel> allTable = new List<TableModel>();
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from [Table]", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TableModel newTable = new TableModel(dr);
                allTable.Add(newTable);
            }
            conn.Close();
            return allTable;
        }
    }
}
