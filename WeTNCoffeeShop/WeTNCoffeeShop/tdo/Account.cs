using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeTNCoffeShop.tdo;
using WeTNCoffeeShop.TableClass;
using System.Windows.Forms;

namespace WeTNCoffeeShop.tdo
{
    public class Account
    {
        private static Account instance;

        public static Account Instance
        {
            get { if (instance == null) instance = new Account(); return instance; }
            private set { instance = value; }
        }
        public Account()
        {
            this.Id = -1;
            this.Name = "";
            this.Password = "";
            this.Username = "";
            this.Status = 0;
        }
        public Account(int id, string name, string password, string username, int status)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Username = username;
            this.Status = status;
        }

        public Account(DataRow dr)
        {
            this.Id = (int)dr["AccountID"];
            this.Name = dr["Name"].ToString();
            this.Password = dr["Password"].ToString();
            this.Username = dr["Username"].ToString();
            this.Status = (int)dr["Role"];
        }
        private int id;
        private string name;
        private string password;
        private string username;
        private int status;
        public string Name { get { return name; } set { name = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Username { get { return username; } set { username = value; } }
        public int Status { get { return status; } set { status = value; } }

        public int Id { get { return id; } set { id = value; } }
        public List<Account> getAccountsList()
        {
            List<Account> accList = new List<Account>();
            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Account", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Account newAcc = new Account(dr);
                accList.Add(newAcc);
            }

            conn.Close();
            return accList;
        }
        public void removeAccount(string getUsername)
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Account WHERE Username = '" +
                       getUsername + "'", con))
                {
                    //cmd.Parameters.AddWithValue("@getCategoryName", getCategoryName);
                    int rows = cmd.ExecuteNonQuery();

                    //rows number of record got inserted
                }
                con.Close();
            }
        }

        public bool ChangeUserName(int accountId, string newUsername)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE Account SET Username = '" + newUsername + "' WHERE AccountID = '" + accountId + "'", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                return true;
            }
            catch //(SqlException e)
            {
                MessageBox.Show("Đã tồn tại tên tài khoản, vui lòng nhập tên khác");
                return false;
            }

        }

        public void ChangeName(int accountId, string newName)
        {

            SqlConnection conn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = CoffeeShop; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("UPDATE Account SET Name = '" + newName + "' WHERE AccountID = '" + accountId + "'", conn);
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();

        }

        public Account getManagerAccount()
        {

            SqlConnection conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CoffeeShop;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account where role = 1", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string username = dt.Rows[0]["username"].ToString();
            string password = dt.Rows[0]["password"].ToString();
            string name = dt.Rows[0]["name"].ToString();
            //int role = Convert.ToInt32(dt.Rows[0]["role"].ToString());
            int id = (int)dt.Rows[0]["AccountID"];
            Account result = new Account(id, name, password, username, 1);
            return result;

        }
        public bool ChangePass(int accountId, string newPass)
        {

            SqlConnection conn = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = CoffeeShop; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("UPDATE Account SET password = '" + newPass + "' WHERE AccountID = '" + accountId + "'", conn);
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
            return true;
        } 
    } 

}

