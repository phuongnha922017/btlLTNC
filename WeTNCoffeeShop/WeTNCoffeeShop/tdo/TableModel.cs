using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTNCoffeeShop;
using WeTNCoffeeShop.tdo;

namespace WeTNCoffeShop.tdo
{
    public class TableModel
    {
        private TableModel() { }
        private static TableModel instance;

        public static TableModel Instance
        {
            get { if (instance == null) instance = new TableModel(); return instance; }
            private set { instance = value; }
        }
        public TableModel(DataRow dr)
        {
            this.TableId = (int)dr["TableID"];
            this.TableState = (int)dr["Status"];
            this.AreaId = (int)dr["AreaID"];
        }

        public TableModel(int id, int areaId)
        {
            this.TableId= id;
            this.AreaId = areaId;
        }

        private int id;
        private int status;
        private int areaId;
        /// <summary>
        /// Id of a table
        /// </summary>
        public int TableId { get { return id; } set { id = value; } }
        /// <summary>
        /// Current state of a number: In use or empty
        /// </summary>
        public int TableState { get { return status; } set { status = value; } }

        /// <summary>
        /// List of drink serving at this table
        /// </summary>

        public int AreaId { get { return areaId; } set { areaId = value; } }
        public List<DrinkModel> ServeList { get; set; } = new List<DrinkModel>();

        public void moveToArea(int getTableId, int getAreaId)
        {

            SqlConnection conn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = CoffeeShop; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("UPDATE [Table] SET areaID = '" + getAreaId +  "' WHERE tableID = '" + getTableId + "'", conn);
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
        }

        public int getAreaId(int tableId)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select AreaID from [Table] where tableID = '" + tableId + "'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return (int)dt.Rows[0]["AreaID"];
        }

        public void insertTable(int getTableId, int getAreaId)
        {
              using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO [Table](TableID, Status, AreaID) VALUES (" +
                           "@getTableId, 0, @getAreaId)", con))
                    {
                        cmd.Parameters.AddWithValue("@getTableId", getTableId);
                        cmd.Parameters.AddWithValue("@getAreaId", getAreaId);
                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }

                    con.Close();

                }

        }

        public void removeTable(int getTableId)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM [Table] WHERE TableID = '" +
                       getTableId + "'", con))
                {

                    int rows = cmd.ExecuteNonQuery();

                    //rows number of record got inserted
                }
                con.Close();
            }
        }


    }
}
