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
using WeTNCoffeeShop.tdo;

namespace WeTNCoffeeShop
{
    public partial class EndDay : Form
    {
        private Account acc;
        private long sum;
        public EndDay(Account acc, long sum)
        {
            InitializeComponent();
            this.acc = acc;
            this.sum = sum;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Sáng");
            comboBox1.Items.Add("Chiều");
            comboBox1.Items.Add("Tối");
            
        }

        private void EndDay_Load(object sender, EventArgs e)
        {
            label4.Text = acc.Name;
            label4.Show();
            label6.Text = DateTime.Now.ToString();
            label6.Show();
            label8.Text = sum.ToString();
            label8.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO revenue(date, shift, staff,shiftrevenue) VALUES (" +
                       "@date,@shift,@staff,@shiftrevenue)", con))
                    {
                        cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Now.ToString()));
                        cmd.Parameters.AddWithValue("@shift", comboBox1.Items[comboBox1.SelectedIndex].ToString());
                        cmd.Parameters.AddWithValue("@staff", acc.Name.ToString());
                        cmd.Parameters.AddWithValue("@shiftrevenue", sum);
                        int rows = cmd.ExecuteNonQuery();

                        //rows number of record got inserted
                    }

                    con.Close();
                }
                this.Close();
                LoginPage n = new LoginPage();
                n.Show();
            }
            catch
            {
                MessageBox.Show("Ca làm đã tồn tại!");
            }
        }
    }
}
