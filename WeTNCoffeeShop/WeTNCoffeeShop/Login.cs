using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WeTNCoffeeShop.tdo;
using WeTNCoffeeShop.TableClass;

namespace WeTNCoffeeShop
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ( textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập ");
            }
            else if ( textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
            }
            else if (LoginCheck(textBox1.Text,textBox2.Text))
            {
                Account newAcc = CheckAccount.Instance.GetInfoAccount(textBox1.Text);
                if (newAcc.Status == 0)
                {
                    MainPage ma = new MainPage(newAcc);
                    textBox1.Clear();
                    textBox2.Clear();
                    this.Hide();
                    ma.ShowDialog();
                    //Staff mainpage
                }
                else
                {
                    ManagerMainPageForm main = new ManagerMainPageForm();
                    //this.Hide();
                    textBox1.Clear();
                    textBox2.Clear();
                    main.ShowDialog();
                    //Manager mainpage
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, vui lòng nhập lại ");
            }
        }
        bool LoginCheck(string username, string password)
        {
                return CheckAccount.Instance.Login(username, password);
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát không? ","Thoát ", MessageBoxButtons.OKCancel) == DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
