using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeTNCoffeeShop.tdo;

namespace WeTNCoffeeShop
{
    public partial class ChangePassForm : Form
    {
        Account thisManager = new Account();
        public ChangePassForm()
        {
            InitializeComponent();
        }

        private void ChangPassForm_Load(object sender, EventArgs e)
        {
            thisManager = Account.Instance.getManagerAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (oldTypeTb.Text == "" || newTypeTb.Text == "" || newRetypeTb.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else if (oldTypeTb.Text != thisManager.Password)
            {
                MessageBox.Show("Nhập mật khẩu cũ sai");
            }
            else if (newTypeTb.Text != newRetypeTb.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp");
            }
            else
            {
                Account.Instance.ChangePass(thisManager.Id, newTypeTb.Text);
                MessageBox.Show("Đổi mật khẩu thành công");
            }
            
        }

        private void mangeLogoutBtn_Click(object sender, EventArgs e)
        {
            InfoForm newPage = new InfoForm();
            this.Hide();
            newPage.ShowDialog();
        }
    }
}
