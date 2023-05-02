using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeTNCoffeShop.tdo;

namespace WeTNCoffeeShop
{
    public partial class StaticForm : Form
    {
        public StaticForm()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void StaticForm_Load(object sender, EventArgs e)
        {
            FillChart();
        }

        private void FillChart()
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from [Revenue]", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            chart.DataSource = dt;
            chart.Series["revenue"].XValueMember = "date";
            chart.Series["revenue"].YValueMembers = "shiftRevenue";
            chart.Series.Add("Revenue");
            conn.Close();


        } 
    }
}
