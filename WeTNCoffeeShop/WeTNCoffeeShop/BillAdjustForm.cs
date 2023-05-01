using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace WeTNCoffeeShop
{
    public partial class BillAdjustForm : Form
    {
        string TableName1 = "[dbo].[2114857]";
        string TableName2 = "[dbo].[2111892]";
        private int percentsurcharge;
        private int priceUnit;
        private int pointGet;
        private int pointUnit;
        private int discountGet;
        public BillAdjustForm()
        {
            InitializeComponent();
           /* this.discountGet = 0;
            this.pointGet = 0; 
            this.pointUnit = 0;
            this.percentsurcharge = 0;
            this.priceUnit = 0;*/
            
        }
        private bool CheckMoney(string price)
        {
            string pat = @"^[1-9]\d*000$";
            bool suc = Regex.IsMatch(price.ToString(), pat);
            if (!suc)
            {
                MessageBox.Show("Dữ liệu cần nhập phải đúng định dạng giá tiền Việt Nam Đồng! VD:1000 -> 1 nghìn VND", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }
        private bool CheckNum(string num)
        {
            string p = @"^[1-9]\d*$";
            bool check = Regex.IsMatch(num.ToString(), p);
            if (!check)
            {
                MessageBox.Show("Dữ liệu cần nhập phải là một số!", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void createFileTXT(string TableName1, string TableName2)
        {
            try
            {
                string SourceFile_GetPoint = @"D:\2114857.txt";// File contains priceUnit and pointGet (label 11 and label 10)
                string[] data1 = { this.priceUnit.ToString(), this.pointGet.ToString() };
                File.WriteAllText(SourceFile_GetPoint, String.Empty); // clear file if it exists
                File.WriteAllLines(SourceFile_GetPoint, data1);
                string SourceFile_GetPrice = @"D:\2111892.txt";
                string[] data2 = { this.pointUnit.ToString(), this.discountGet.ToString() };
                File.WriteAllText(SourceFile_GetPrice, String.Empty); // clear file if it exists
                File.WriteAllLines(SourceFile_GetPrice, data2);
                string rowterminator = "'\n'";

                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
                System.IO.StreamReader SourceFile1 = new System.IO.StreamReader(SourceFile_GetPoint);
                System.IO.StreamReader SourceFile2 = new System.IO.StreamReader(SourceFile_GetPrice);

                string line1 = "";
                string line2 = "";
                con.Open();
                // begin to clear all values on tables
                SqlCommand delete1 = new SqlCommand("truncate table" +  TableName1, con);
                delete1.ExecuteNonQuery();
                SqlCommand delete2 = new SqlCommand("truncate table" +  TableName2, con);
                delete2.ExecuteNonQuery();
                //end to clear
                
                while ((line1 = SourceFile1.ReadLine()) != null)
                {
                        string query1 = "Insert into " + TableName1 +
                               " Values ('" + line1.Replace(rowterminator, "'\n'") + "')";
                        SqlCommand myCommand1 = new SqlCommand(query1, con);
                        myCommand1.ExecuteNonQuery();
                }
                SourceFile1.Close();
                while ((line2 = SourceFile2.ReadLine()) != null)
                {
                        string query2 = "Insert into " + TableName2 +
                              " Values ('" + line2.Replace(rowterminator, "'\n'") + "')";
                        SqlCommand myCommand2 = new SqlCommand(query2, con);
                        myCommand2.ExecuteNonQuery();
                }
                SourceFile2.Close();
                con.Close();
            }
            catch (IOException Exception)
            {
                Console.Write(Exception);
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            createFileTXT(TableName1,TableName2);
            ManagerMainPageForm m = new ManagerMainPageForm();
            this.Close();
            m.Show();
            //Back previous page
        }

        private void BillAdjustForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            createFileTXT(TableName1, TableName2);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label4.Text = textBox2.Text.ToString();

                this.percentsurcharge = Convert.ToInt32(int.Parse(textBox1.Text.ToString()));
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            label11.Text = textBox3.Text.ToString();
            label10.Text = textBox4.Text.ToString();
            label14.Text = textBox5.Text.ToString();
            label15.Text = textBox6.Text.ToString();
                this.priceUnit = Convert.ToInt32(int.Parse(textBox3.Text.ToString()));
                this.pointGet = Convert.ToInt32(int.Parse(textBox4.Text.ToString()));
                this.pointUnit = Convert.ToInt32(int.Parse(textBox5.Text.ToString()));
                this.discountGet = Convert.ToInt32(int.Parse(textBox6.Text.ToString())); 
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            button1.Visible = true;
            button1.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            button2.Visible = true;
            button2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (CheckNum(textBox1.Text.ToString()))
            {
                this.percentsurcharge = Convert.ToInt32(int.Parse(textBox1.Text.ToString()));
            }
            else
            {
                textBox1.Text = string.Empty;
                textBox1.Show();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(CheckMoney(textBox3.Text.ToString())) { this.priceUnit = Convert.ToInt32(int.Parse(textBox3.Text.ToString())); }
            else { textBox3.Text = string.Empty; }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(CheckMoney(textBox4.Text.ToString())) { this.pointGet = Convert.ToInt32(int.Parse(textBox4.Text.ToString())); }
            else { textBox4.Text = string.Empty; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(CheckMoney(textBox4.Text.ToString())) { this.pointUnit = Convert.ToInt32(int.Parse(textBox5.Text.ToString())); }
            else { textBox5.Text = string.Empty; }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(CheckMoney(textBox6.Text.ToString())) { this.discountGet = Convert.ToInt32(int.Parse(textBox6.Text.ToString())); }
            else { textBox6.Text = string.Empty; }
        }

        private void surchargeBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
