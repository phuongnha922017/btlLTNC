using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
using WeTNCoffeeShop.tdo;
using WeTNCoffeShop.tdo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using Microsoft.ReportingServices.Interfaces;
namespace WeTNCoffeeShop
{
    public partial class BillForm : Form
    {
        private long amountForTable;
        private DataTable dt_category;
        private DataTable dt_product;
        private BillModel model;
        private DataTable display;
        private Account NewAcc;
        public DataTable Display { get { return display; } set { display = value; } }
        public long AmountForTable { get { return amountForTable; } set { amountForTable = value; } }
        string pattern = "^[0-9]+$";
       // public BillForm() { InitializeComponent(); this.Display = new DataTable(); this.NewAcc = new Account(1, "nhanvien", "pass", "username", 0); }
        public BillForm(Account newAcc)
        {
            InitializeComponent();
            model = new BillModel();
            model.GroupProduct = "";
            this.NewAcc = newAcc;
            dt_category = new DataTable();
            dt_product = new DataTable();
            LoadCategory_Product_ModeOfPayment();
            this.Result = -1;
            panel2.Show();
        }
        private void BillForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Result == -1 && Display.Rows.Count == 0)
            {
                AmountForTable = 0;
                this.Result = 1; return;
            }
            if (this.Result != 1)
            {
                this.Result = -1;
            }
            e.Cancel = false;
        }
        private long countSum()
        {long sum = 0;
            if (Display.Rows.Count > 0)
            {
                
                for (int i = 0; i < Display.Rows.Count; i++)
                {
                    if (Display.Rows[i][5].ToString() == "")
                    {
                        Display.Rows[i][5] = "0";
                    }
                    sum += (Convert.ToInt64(Display.Rows[i][7].ToString()));
                }
                sum += Convert.ToInt32(int.Parse(Display.Rows[Display.Rows.Count - 1][5].ToString()));
                sum -= Convert.ToInt32(int.Parse(Display.Rows[Display.Rows.Count - 1][4].ToString()));
            }
            return sum;
        }
        private void LoadCategory_Product_ModeOfPayment()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter category = new SqlDataAdapter("Select * from [category] ", conn);
            category.Fill(dt_category);
            foreach (DataRow dr in dt_category.Rows)
            {
                comboBox1.Items.Add(dr["Name"].ToString());
            }
            SqlDataAdapter product = new SqlDataAdapter("Select * from [product]", conn);
            product.Fill(dt_product);
            foreach (DataRow dr in dt_product.Rows)
            {
                comboBox2.Items.Add(dr["Name"].ToString());
            }
            conn.Close();
            comboBox3.Items.Add("Chuyển khoản");
            comboBox3.Items.Add("Tiền mặt");
        }
        private void ChangecomboBox2(string selectedvalue)
        {
            string categoryID = ((from DataRow dr_category in dt_category.Rows
                                  where (string)dr_category["Name"] == selectedvalue
                                  select (int)dr_category["CategoryID"]).FirstOrDefault()).ToString();
            foreach (DataRow dr_product in dt_product.Rows)
            {
                if (dr_product["CategoryID"].ToString() == categoryID)
                {
                    comboBox2.Items.Add(dr_product["Name"].ToString());
                }
            }
        }
        private bool isEnterComboBox2()
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy nhập món hàng trước nha~", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool isNumericbiggerThan0()
        {
            string p = @"^[1-9]\d*$";
            bool check = Regex.IsMatch(numericUpDown1.Value.ToString(), p);
            if (numericUpDown1.Value == 0 | !check)
            {
                MessageBox.Show("Số lượng cần là một số lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnClick_continue()
        {
            bool contains = Display.AsEnumerable().Any(row => model.NameProduct.ToString() == row.Field<String>("Tên món hàng"));
            if (contains)
            {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        int old = Convert.ToInt32(dataGridView1.Rows[i].Cells["Số lượng"].Value);
                        string h = (dataGridView1.Rows[i].Cells["Tên món hàng"].Value).ToString();
                        if (h == model.NameProduct.ToString())
                        {
                            dataGridView1.Rows[i].Cells["Số lượng"].Value = (old + Convert.ToInt32(model.Quantity)).ToString();
                            long perprice = Convert.ToInt64(textBox3.Text.ToString());
                            int quantity = Convert.ToInt32((old + Convert.ToInt32(model.Quantity)).ToString());
                            int discount = Convert.ToInt32(textBox6.Text.ToString());
                            long s = (perprice * quantity) * (1 + discount);
                            dataGridView1.Rows[i].Cells["Tổng tiền"].Value = s.ToString();
                            textBox5.Text = countSum().ToString();
                            textBox5.Show();
                            break;
                        }
                    }
               

            }
            else
            {
                if (isEnterComboBox2())
                {
                    if (isNumericbiggerThan0())
                    {
                            DataRow ravi = Display.NewRow();
                            if (model.GroupProduct == "")
                            {
                                string categoryID = ((from DataRow dr_product in dt_product.Rows
                                                      where (string)dr_product["Name"] == model.NameProduct.ToString()
                                                      select (int)dr_product["CategoryID"]).FirstOrDefault()).ToString();
                                foreach (DataRow dr in dt_category.Rows)
                                {
                                    if (dr["CategoryID"].ToString() == categoryID)
                                    {
                                        ravi["Nhóm món hàng"] = dr["Name"];
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                ravi["Nhóm món hàng"] = model.GroupProduct.ToString();
                            }
                            ravi["Tên món hàng"] = model.NameProduct.ToString();
                            ravi["Giá tiền mỗi món hàng"] = textBox3.Text.ToString();
                            ravi["Số lượng"] = model.Quantity.ToString();
                            ravi["Phương thức thanh toán"] = "";
                            ravi["Phụ thu"] = "0";
                            ravi["Lý do"] = textBox7.Text.ToString();
                            long perprice = Convert.ToInt64(textBox3.Text.ToString());
                            int quantity = Convert.ToInt32(model.Quantity.ToString());
                            int discount = Convert.ToInt32(textBox6.Text.ToString());
                            long s = (perprice * quantity) * (1 + discount);
                            ravi["Tổng tiền"] = s.ToString();
                            Display.Rows.Add(ravi);
                            if (Display.Rows.Count == 0)
                            {
                                textBox5.Text = s.ToString();
                                textBox5.Show();
                            }
                            else
                            {
                                textBox5.Text = countSum().ToString();
                                textBox5.Show();
                            }
                        
                    }
                }

            }
        }
        private bool Check_InfoCustomer()
        {
            if (((textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "") || (textBox1.Text.ToString() == "" && textBox2.Text.ToString() == "")))
            {
                if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "")
                {
                    if (Check_Phonenumber())
                    {

                        return true;
                    }
                    else
                    {
                          MessageBox.Show("Số điện thoại chỉ bao gồm số!");
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin khách hàng hoặc bỏ trống cả hai ô");
                return false;
            }
            return false;
        }
        private bool Check_Phonenumber()
        {
            bool successfullyParsed = Regex.IsMatch(textBox2.Text.ToString(), pattern);
            if (!successfullyParsed)
            {
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btn1_isEnter = true;
            btnClick_continue();

            dataGridView1.DataSource = Display;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.Show();
            numericUpDown1.Value = 0;
        }
        private int result;
        public int Result { get { return result; } set { result = value; } }
        private bool btn1_isEnter = false;

        private void button2_Click(object sender, EventArgs e)
        {
            if (Display.Rows.Count > 0)
            {
                long sum = 0;
                if (Display.Rows.Count > 0)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                    if (Display.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            long perprice = Convert.ToInt64(Int64.Parse(dataGridView1.Rows[i].Cells["Giá tiền mỗi món hàng"].Value.ToString()));
                            int quantity = Convert.ToInt32(Int32.Parse(dataGridView1.Rows[i].Cells["Số lượng"].Value.ToString()));
                            int discount = Convert.ToInt32(Int32.Parse(dataGridView1.Rows[i].Cells["Giảm giá"].Value.ToString()));
                            int surcharge = Convert.ToInt32(Int32.Parse(dataGridView1.Rows[i].Cells["Phụ thu"].Value.ToString()));
                            sum = sum + (perprice * quantity) * (1 + discount) + surcharge;
                        }
                        Display.Rows[Display.Rows.Count - 1][7] = sum.ToString();
                    }
                }
                else
                {
                    sum = 0;
                }
                textBox5.Text = countSum().ToString();
                textBox5.Show();
            }
            else
            {
                MessageBox.Show("Không có món hàng nào để xóa!");
            }
        }
        
        private int getNewPoints(long phonenumber, int points, int pointUnit, int discountGet)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select points from customer where PhoneNumber = @phonenumber", con);
            cmd.Parameters.AddWithValue("@phonenumber", phonenumber);
            DataTable p = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(p);
            int oldPoints = Convert.ToInt32(p.Rows[0][0].ToString());
            SqlCommand cmd2 = new SqlCommand("declare @i int;" + " set @i = (select points from customer where PhoneNumber = @phonenumber );"+" update customer set points = @i + @points where PhoneNumber = @phonenumber;", con);
            cmd2.Parameters.AddWithValue("@phonenumber", phonenumber);
            cmd2.Parameters.AddWithValue("@points", points);
            int newpoint = (oldPoints + points) - (int)((oldPoints + points) / pointUnit) * pointUnit;
            int result = (int)(oldPoints + points) / pointUnit;
            result *= discountGet;
            SqlCommand c = new SqlCommand("update customer set points = @newpoints where PhoneNumber = @phonenumber", con);
            c.Parameters.AddWithValue("@phonenumber", phonenumber);
            c.Parameters.AddWithValue("@newpoints", newpoint);
            c.ExecuteNonQuery();
            con.Close();
            return result;

        }
        private void SaveInfoCustomer(long phonenumber, string nameofcustomer, int points)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from customer where phonenumber like @phonenumber AND nameofcustomer = @nameofcustomer", con))
                {
                    sqlCommand.Parameters.AddWithValue("@phonenumber", phonenumber);
                    sqlCommand.Parameters.AddWithValue("@nameofcustomer", nameofcustomer);
                    int userCount = (int)sqlCommand.ExecuteScalar();
                    if (userCount > 0)
                    {
                        
                    }
}
                using (SqlCommand c = new SqlCommand("INSERT INTO Customer(phonenumber, nameofcustomer, points) VALUES (" +
                              "@phonenumber,@nameofcustomer,@points)", con))
                {
                    c.Parameters.AddWithValue("@phonenumber", phonenumber);
                    c.Parameters.AddWithValue("@nameofcustomer", nameofcustomer);
                    c.Parameters.AddWithValue("@points", points);
                    int rows = c.ExecuteNonQuery();

                    //rows number of record got inserted
                }
                con.Close();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            foreach (DataRow dr_product in dt_product.Rows)
            {
                if (dr_product["Name"].ToString() == value)
                {
                    textBox3.Text = dr_product["PerPrice"].ToString();
                    textBox3.Show();
                }
            }
            model.NameProduct = value;
        }
        private bool ispaid = false;
        private bool Check_Surcharge()
        {
            if (((textBox4.Text.ToString() != "" && textBox7.Text.ToString() != "") || (textBox4.Text.ToString() == "" && textBox7.Text.ToString() == "")))
            {
                if (textBox4.Text.ToString() != "" && textBox7.Text.ToString() != "")
                {
                    if (Check_SurchargePrice())
                    {

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Hãy nhập số tiền phụ thu theo đúng định dạng tiền Việt Nam Đồng! VD:1000 -> 1 nghìn đồng.", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin phụ thu và lý do hoặc bỏ trống cả hai ô");
                return false;
            }
            return false;
        }
        private bool Check_SurchargePrice()
        {
            string pat = @"^[1-9]\d*000$";
            bool suc = Regex.IsMatch(textBox4.Text.ToString(), pat);
            if(!suc)
            {
               return false;
            }
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (btn1_isEnter)
            {
                if (Display.Rows.Count > 0)
                {
                    if (isEnterComboBox2() && Check_InfoCustomer())
                    {
                        if (Check_InfoCustomer())
                        {
                            if (!ispaid)
                            {
                                panel2.Hide();
                                panel1.Visible = true;
                                panel1.Show();
                                ispaid = true;
                                button1.Enabled = false;
                                button2.Enabled = false;
                            }
                            else
                            {
                                if (comboBox3.SelectedIndex == -1)
                                {
                                    MessageBox.Show("Vui lòng chọn phương thức thanh toán!");
                                }
                                else
                                {
                                    this.Result = 1;
                                    //Display.Columns["Trạng thái"].Expression = "'Đã thanh toán'";

                                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                    {
                                        dataGridView1.Rows[i].Cells["Phương thức thanh toán"].Value = comboBox3.Items[comboBox3.SelectedIndex].ToString();
                                        dataGridView1.Rows[i].Cells["Tên khách hàng"].Value = textBox1.Text.ToString();
                                        dataGridView1.Rows[i].Cells["Số điện thoại"].Value = textBox2.Text.ToString();
                                    }
                                    comboBox3.Enabled = false;
                                    if (Check_Surcharge())
                                    {
                                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                        {
                                            dataGridView1.Rows[i].Cells["Phụ thu"].Value = textBox4.Text.ToString();
                                        }
                                        //textBox4.ReadOnly = true; textBox4.ReadOnly = true;
                                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                        {
                                            dataGridView1.Rows[i].Cells["Lý do"].Value = textBox7.Text.ToString();
                                        }
                                        //textBox7.ReadOnly = true; textBox7.ReadOnly = true;
                                        textBox5.Text = countSum().ToString();
                                        textBox5.Show();
                                        int priceUnit = getTXT("Select top 1 * From [2114857]");
                                        int pointGet = getTXT("Select top (select COUNT(*) from [2114857]) * From [2114857] EXCEPT Select top ((select COUNT(*) from [2114857])-(1)) * From [2114857]");
                                        int pointUnit = getTXT("Select top 1 * From [2111892]");
                                        int discountGet = getTXT("Select top (select COUNT(*) from [2111892]) * From [2111892] EXCEPT Select top ((select COUNT(*) from [2111892])-(1)) * From [2111892]");
                                        int discountPrice = 0;
                                        int points = 0;
                                        if (priceUnit != 0)
                                        {
                                            points = (int)countSum() / priceUnit;
                                            points *= pointGet;
                                        }
                                        if (textBox2.Text.ToString() != "")
                                        {
                                            long phonenumber = Convert.ToInt64(Int64.Parse(textBox2.Text.ToString()));
                                            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
                                            {
                                                con.Open();
                                                using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from customer where phonenumber like @phonenumber AND nameofcustomer = @nameofcustomer", con))
                                                {
                                                    sqlCommand.Parameters.AddWithValue("@phonenumber", phonenumber);
                                                    sqlCommand.Parameters.AddWithValue("@nameofcustomer", textBox1.Text.ToString());
                                                    int userCount = (int)sqlCommand.ExecuteScalar();
                                                    if (userCount > 0)
                                                    {
                                                        if (pointUnit != 0)
                                                        { discountPrice = getNewPoints(phonenumber, points, pointUnit, discountGet); }
                                                    }
                                                    else
                                                    {
                                                        SaveInfoCustomer(phonenumber, textBox1.Text.ToString(), points);
                                                    }
                                                }
                                                con.Close();
                                            }
                                        }
                                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                                        {
                                            dataGridView1.Rows[i].Cells["Giảm giá"].Value = discountPrice.ToString();
                                        }
                                        Display.Columns["Trạng thái"].Expression = "'Đã thanh toán'";
                                        textBox5.Text = countSum().ToString();
                                        textBox5.Show();
                                        AmountForTable = countSum();
                                        if (MessageBox.Show("Thanh toán thành công, bạn có muốn in hóa đơn không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {

                                            List<BillModel> lst = new List<BillModel>();
                                            lst.Clear();
                                            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                                            {
                                                BillModel newbill = new BillModel(Display.Rows[i]["Giá tiền mỗi món hàng"].ToString(),
                                                   Display.Rows[i]["Tổng tiền"].ToString(),
                                                    Display.Rows[i]["Nhóm món hàng"].ToString(),
                                                    Display.Rows[i]["Tên món hàng"].ToString(),
                                                    Display.Rows[i]["Số lượng"].ToString());
                                                lst.Add(newbill);
                                            }
                                            PrintBill n = new PrintBill(lst, countSum(), GetAreaName_TableName(this.Tag.ToString()), textBox1.Text.ToString(),
                                                textBox6.Text.ToString(), textBox4.Text.ToString(), textBox7.Text.ToString());
                                            n.ShowDialog();
                                            this.Close();
                                        }
                                        this.Close();
                                    }

                                }
                            }
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn vẫn chưa ấn nút lưu nè!");
            }
        }
        private string GetAreaName_TableName(string tag)
        {
            List<AreaModel> areaModels = AreaListModel.Instance.getListArea();
            string result = "";
            Regex regex = new Regex("(-)");         // Split on hyphens.
            string[] substrings = regex.Split(tag);
            int count = 1;
            foreach (string match in substrings)
            {
                if (count == 1) { result = areaModels[Convert.ToInt32(match) - 1].Name; }
                if (count == substrings.Length) { result += " - Bàn số " + match; }
                count++;
            }
            return result;
        }
        private int getTXT(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable pr  = new DataTable();
                adapter.Fill(pr);
                int result = Convert.ToInt32(pr.Rows[0][0].ToString());
                con.Close();
                return result;
            }
            catch { }
            {
                MessageBox.Show("Lỗi lấy giá trị file txt");
            }
            return -1;
        }
        private void BillForm_Load(object sender, EventArgs e)
        {
            if (Display.Rows.Count > 0)
            {
                DataRow dr = Display.Rows[Display.Rows.Count - 1];
                comboBox3.Text = dr["Nhóm món hàng"].ToString();
                comboBox3.Show();
                comboBox2.Text = dr["Tên món hàng"].ToString();
                comboBox2.Show();
                textBox3.Text = dr["Giá tiền mỗi món hàng"].ToString();
                textBox3.Show();
                numericUpDown1.Value = Convert.ToInt32(dr["Số lượng"]);
                numericUpDown1.Show();
                textBox5.Text = countSum().ToString();
                textBox5.Show();
                comboBox3.Text = dr["Phương thức thanh toán"].ToString();
                comboBox3.Show();
                textBox1.Text = dr["Tên khách hàng"].ToString();
                textBox1.Show();
                textBox2.Text = dr["Số điện thoại"].ToString();
                textBox2.Show();
                textBox4.Text = dr["Phụ thu"].ToString();
                textBox4.Show();
                textBox7.Text = dr["Lý do"].ToString();
                textBox7.Show();
            }
            this.dataGridView1.DataSource = Display;
            dataGridView1.Show();
            if (this.Display.Rows.Count <= 0 && Display.Columns.Count <= 0)
            {
                Display.Columns.Add("Nhóm món hàng");
                Display.Columns.Add("Tên món hàng");
                Display.Columns.Add("Giá tiền mỗi món hàng");
                Display.Columns.Add("Số lượng");
                Display.Columns.Add("Giảm giá");
                Display.Columns.Add("Phụ thu");
                Display.Columns.Add("Lý do");
                Display.Columns.Add("Tổng tiền");
                Display.Columns.Add("Phương thức thanh toán");
                Display.Columns.Add("Nhân viên phục vụ");
                Display.Columns.Add("Tên khách hàng");
                Display.Columns.Add("Số điện thoại");
                Display.Columns.Add("Ngày giờ");
                Display.Columns.Add("Trạng thái");
                Display.Columns["Giảm giá"].DefaultValue = 0.ToString();
                Display.Columns["Nhân viên phục vụ"].DefaultValue = NewAcc.Name.ToString();
                Display.Columns["Ngày giờ"].DefaultValue = (DateTime.Now).ToString();
                Display.Columns["Trạng thái"].DefaultValue = "Chưa thanh toán";
                Display.Columns["Tên khách hàng"].DefaultValue = textBox1.Text.ToString();
                Display.Columns["Số điện thoại"].DefaultValue = textBox2.Text.ToString();
            }
            textBox6.Text = "0";
            textBox6.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 30)
            {
                MessageBox.Show("Chỉ có thể order dưới 30 món hàng trong một lần chọn!", "Cảnh báo");
                numericUpDown1.Value = 30;
            }
            if (numericUpDown1.Value < 0)
            {
                numericUpDown1.Value = 0;
            }
            model.Quantity = numericUpDown1.Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string selectedValue = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            if (selectedValue != "")
            {
                ChangecomboBox2(selectedValue);
            }
            else
            {
                foreach (DataRow dr_product in dt_product.Rows)
                {
                    comboBox2.Items.Add(dr_product["Name"].ToString());
                }
            }
            model.GroupProduct = selectedValue;
        }
        
    }
}
