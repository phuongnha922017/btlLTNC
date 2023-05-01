using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeTNCoffeeShop.TableClass;
using WeTNCoffeeShop.tdo;

namespace WeTNCoffeeShop
{
    public partial class newPass : Form
    {
        private ChangePass pre;
        private Account newAcc;
        public Account NewAcc { get { return newAcc; } set { newAcc = value; } }
        public newPass(Account newAcc, ChangePass pre)
        {
            InitializeComponent();
            this.NewAcc = newAcc;
            this.pre = pre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckAccount.Instance.ChangePass(maskedTextBox1.Text,maskedTextBox2.Text,maskedTextBox3.Text) == true) {
                MessageBox.Show("Đổi mật khẩu thành công ");
                NewAcc.Password = maskedTextBox2.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            pre.Show();
        }

        private void newPass_Load(object sender, EventArgs e)
        {

        }
    }
}
