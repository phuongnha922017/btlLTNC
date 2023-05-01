using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WeTNCoffeeShop.TableClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WeTNCoffeeShop.tdo;

namespace WeTNCoffeeShop.TableClass
{
    public class CheckAccount
    {
        private static CheckAccount instance;

        public static CheckAccount Instance
        {
            get { if (instance == null) instance = new CheckAccount(); return instance; }
            private set { instance = value; }
        }

        private CheckAccount() { }
        public bool Login(string username, string password)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT * FROM Account where username = @username and password = @password ", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex); }
            return false;
        }
        public bool InsertAccount(string getNewUserName, string getNewName, string getNewPassword, string againPass)
        {

            bool isequal = (getNewPassword == againPass) ? true : false;
            if (isequal)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Account(Name,Username,Password,Role) VALUES (" +
                               "@getNewName,@getNewUserName,@getNewPassWord,@role)", con))
                        {
                            cmd.Parameters.AddWithValue("@getNewName", getNewName);
                            cmd.Parameters.AddWithValue("@getNewUserName", getNewUserName);
                            cmd.Parameters.AddWithValue("@getNewPassword", getNewPassword);
                            cmd.Parameters.AddWithValue("@role", 0); // if it's a staff
                            int rows = cmd.ExecuteNonQuery();

                            //rows number of record got inserted
                        }
                        con.Close();
                    }
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Đã tồn tại tên tài khoản, vui lòng chọn tên tài khoản khác. ERROR: " + ex);
                    return false;
                }
            }
            else if (!isequal)
            {
                MessageBox.Show("Mật khẩu nhập lại không giống nhau, vui lòng nhập lại lần nữa ");
                return false;
            }
            else
            {
                MessageBox.Show("ID Staff không hợp lệ ");
                return false;
            }
        }
        public Account GetInfoAccount(string username)
        {
            SqlConnection conn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = CoffeeShop; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account where username = '" + username + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string password = dt.Rows[0]["password"].ToString();
            string name = dt.Rows[0]["name"].ToString();
            int role = Convert.ToInt32(dt.Rows[0]["role"].ToString());
            int id = (int)dt.Rows[0]["AccountID"];
            Account result = new Account(id, name, password, username, role);
            return result;

        }

        
        public bool ChangePass(string oldPass, string newPass, string again)
        {
            if (newPass == again && oldPass != "" && newPass != "")
            {
                SqlConnection conn = new SqlConnection("Data Source = MSI\\SQLEXPRESS; Initial Catalog = CoffeeShop; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("UPDATE Account SET password = '" + newPass + "' WHERE password = '" + oldPass + "'", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                return true;
            }
            else
            {
                if (oldPass == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu cũ ");
                    return false;
                }
                else if (newPass == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới ");
                    return false;
                }
                else
                {
                    MessageBox.Show("Nhập lại mật khẩu mới không khớp ");
                    return false;
                }
            }


        }
        

    }
}
