using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WeTNCoffeeShop.TableClass;
using static System.Net.WebRequestMethods;
using WeTNCoffeeShop.tdo;
using WeTNCoffeShop.tdo;
using System.Data.SqlClient;
using System.Runtime.Remoting.Channels;
using System.Text.RegularExpressions;

namespace WeTNCoffeeShop
{
    public partial class MainPage : Form
    {
        private long sum = 0;
        private DataTable table;
        private long totalPriceForDay;
        private int result;
        private Dictionary<string, DataTable> list;
        private DataTable display;
        public int Result { get { return result; } set { result = value; } }
        public DataTable Display { get { return display; } set { display = value; } }
        public long TodayPrice { get { return totalPriceForDay; } set { totalPriceForDay = value; } }
        private Account newAcc;
        public Account NewAcc { get { return newAcc; } set { newAcc = value; } }
        public MainPage(Account newAcc)
        {
            InitializeComponent();
            this.NewAcc = newAcc;
            this.TodayPrice = 0;
            this.Result = 0;
            list = new Dictionary<string, DataTable>();
            label3.Hide();
            label2.Hide();
            dataGridView1.Hide();
            tabControl1.Hide();
            pictureBox1.Show();
            label1.Show();
            table = new DataTable();
            table.Columns.Add("Bàn số");
            table.Columns.Add("Tên nhân viên");
            table.Columns.Add("Ngày hiện tại");
            table.Columns.Add("Tổng tiền đã bán được (Đã bao gồm phụ thu)");
            table.Columns.Add("Tiền phụ thu");
            table.Columns.Add("Lý do");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (list.Count == 0)
            {
                EndDay en = new EndDay(newAcc, this.sum);
                this.Close();
                this.Hide();
                en.ShowDialog();
            }
            else
            {
                MessageBox.Show("Có hóa đơn chưa thanh toán!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Hide();
            label2.Hide();
            dataGridView1.Hide();
            tabControl1.Hide();
            pictureBox1.Show();
            label1.Show();
        }
        private void LoadListArea()
        {
            label3.Hide();
            label2.Hide();
            dataGridView1.Hide();
            pictureBox1.Hide();
            label1.Hide();
            tabControl1.Show();
            List<AreaModel> areaModels = AreaListModel.Instance.getListArea();
            tabControl1.Controls.Clear();
            for (int  i = 0; i < areaModels.Count; i++)
            {
                TabPage tp = new TabPage();
                tp.Text = areaModels[i].Name;
                tp.BackColor = Color.LightSteelBlue;
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.AutoSize = true;
                flp.BackColor = Color.LightSteelBlue;
                List<TableModel> l = TableListModel.Instance.getListTable(areaModels[i].AreaId);
                for (int j = 0; j < l.Count; j++)
                {
                    Button btn = new Button();
                    btn.Text = "Bàn số " + (j + 1).ToString();
                    btn.BackColor = Color.LightSteelBlue;
                    btn.Size = new Size(200, 120);
                    btn.Font = new Font("Times New Roman", 18);
                    btn.BackColor = Color.LightSteelBlue;
                    string patt = String.Format("{0}-{1}", (i+1).ToString(), (j+1).ToString());
                   
                    btn.Tag = patt;
                    btn.Click += new EventHandler(button_Click);
                      
                    flp.Controls.Add(btn);
                }
                flp.AutoScroll = true;
                tp.Controls.Add(flp);
                tabControl1.Controls.Add(tp);
            }
        }
        private BillForm billForm;
        private void button_Click(object sender, System.EventArgs e)
        {
            if (!list.ContainsKey((string)(sender as Button).Tag))
            {
                billForm = new BillForm(this.NewAcc);
                billForm.Tag = (string)(sender as Button).Tag;
                DataTable dataTable = new DataTable();
                billForm.Display = dataTable;
                billForm.ShowDialog();
                //Display = billForm.Display;
                list[(string)(sender as Button).Tag]  = dataTable;
            }
            else
            {
                billForm.Display = list[(string)(sender as Button).Tag];
                billForm.ShowDialog();
            }
            if (billForm.Result == 1)// da thanh toan hoac chua thanh toan nhung da xoa het cac mon an trong bill
            {
                    TodayPrice = billForm.AmountForTable;
            (sender as Button).BackColor = Color.LightSteelBlue;
                if (TodayPrice != 0)
                {
                    sum += TodayPrice;
                    using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
                    {
                        con.Open();
                        for (int i = 0; i < list[(string)(sender as Button).Tag].Rows.Count; i++)
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Statistic(dateStaff, nameOfProduct, Quantity) VALUES (" +
                               "@dateStaff,@nameOfProduct,@Quantity)", con))
                            {
                                cmd.Parameters.AddWithValue("@dateStaff", Convert.ToDateTime(list[(string)(sender as Button).Tag].Rows[i][12].ToString()));
                                cmd.Parameters.AddWithValue("@nameOfProduct", list[(string)(sender as Button).Tag].Rows[i][1].ToString());
                                cmd.Parameters.AddWithValue("@Quantity", list[(string)(sender as Button).Tag].Rows[i][3].ToString());
                                int rows = cmd.ExecuteNonQuery();

                                //rows number of record got inserted
                            }
                        }
                        con.Close();
                    }
                    DataRow ravi = table.NewRow();
                    ravi["Bàn số"] = (sender as Button).Tag.ToString();
                    ravi["Tên nhân viên"] = this.NewAcc.Name.ToString();
                    ravi["Ngày hiện tại"] = DateTime.Now.ToString();
                    ravi["Tổng tiền đã bán được (Đã bao gồm phụ thu)"] = TodayPrice.ToString();
                    ravi["Tiền phụ thu"] = list[(string)(sender as Button).Tag].Rows[list[(string)(sender as Button).Tag].Rows.Count - 1][5].ToString();
                    ravi["Lý do"] = list[(string)(sender as Button).Tag].Rows[list[(string)(sender as Button).Tag].Rows.Count - 1][6].ToString();
                    table.Rows.Add(ravi);
                }
                list.Remove((string)(sender as Button).Tag);
                (sender as Button).Text = "Bàn số " + GetIDTable((sender as Button).Tag.ToString());
            }
            else // luu & chua thanh toan
            {
                (sender as Button).BackColor = Color.LightSlateGray;
                (sender as Button).Text = "Bàn số " + GetIDTable((sender as Button).Tag.ToString()) + " chưa thanh toán";
            }
        }
        private string GetIDTable(string tag)
        {
            Regex regex = new Regex("(-)");         // Split on hyphens.
            string[] substrings = regex.Split(tag);
            int count = 1;
            foreach (string match in substrings)
            {
                if(count == substrings.Length) { return match; }
                count++;
            }
            return "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            label3.Hide();
            label2.Hide();
            dataGridView1.Hide();
            pictureBox1.Hide();
            label1.Hide();
            tabControl1.Show();
            if (this.tabControl1.TabCount == 0)
            { LoadListArea(); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ChangePass changePass = new ChangePass(this.NewAcc, this);
            this.Hide();
            changePass.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Show();
            dataGridView1.Show();
            pictureBox1.Hide();
            label1.Hide();
            tabControl1.Hide();
            dataGridView1.DataSource = table;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            label3.Text = String.Format("Tổng kết trong ngày: {0}", this.sum.ToString());
            label3.Show();
            //dataGridView1.Show();
        }
        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát không? ", "Thoát ", MessageBoxButtons.OKCancel) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
