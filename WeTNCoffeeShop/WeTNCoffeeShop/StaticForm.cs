using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WeTNCoffeShop.tdo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
            chart.Series.Clear();
            string fromDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string toDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            if (byRevenueBtn.Checked)
            {
                
                SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select sum(shiftRevenue) as dateRevenue, [date] from [Revenue] where [date] >= @getFromDate and [date] <= @getToDate group by [date]", conn);
                cmd.Parameters.AddWithValue("@getFromDate", fromDate);
                cmd.Parameters.AddWithValue("@getToDate", toDate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                chart.DataSource = dt;
                chart.Series.Add("revenue");
                chart.Series[0].ChartType = SeriesChartType.Spline;
                chart.Series["revenue"].XValueMember = "date";
                chart.Series["revenue"].YValueMembers = "dateRevenue";
                chart.Titles[0].Text = "Thống kê doanh thu";
                chart.ChartAreas[0].AxisX.LabelStyle.Interval = Double.NaN;
                conn.Close();

            }

            else if (byDrinkBtn.Checked)
            {
                
                SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
                conn.Open();
                string cmdString = "SELECT TOP 20 SUM(quantity) AS totalQuantity, nameOfProduct ";
                cmdString += "FROM statistic ";
                cmdString += "WHERE CAST(dateStaff AS DATE) >= @getFromDate AND CAST(dateStaff AS DATE) <= @getToDate ";
                cmdString += "GROUP BY nameOfProduct ";
                cmdString += "ORDER BY totalQuantity DESC";
                SqlCommand cmd = new SqlCommand(cmdString, conn);
                cmd.Parameters.AddWithValue("@getFromDate", fromDate);
                cmd.Parameters.AddWithValue("@getToDate", toDate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                chart.DataSource = dt;
                chart.Series.Add("quantity");
                chart.Series[0].ChartType = SeriesChartType.Column;
                chart.Series["quantity"].XValueMember = "nameOfProduct";
                chart.Series["quantity"].YValueMembers = "totalQuantity";
                chart.Titles[0].Text = "Top 20 bán chạy";
                chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                conn.Close();
            }
        }

        private void StaticForm_Load(object sender, EventArgs e)
        {
            
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }

        /*
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
        */
    }
}
