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
    public partial class ChangePass : Form
    {
        private MainPage pre;
        private Account newAcc;
        public Account NewAcc { get { return newAcc; } set { newAcc = value; } }
        public ChangePass(Account newAcc, MainPage pre)
        {
            InitializeComponent();
            this.NewAcc = newAcc;
            this.pre = pre;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newPass newpass = new newPass(NewAcc, this);
            this.Hide();
            newpass.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            pre.Show();
        }

        private void ChangePass_Load(object sender, EventArgs e)
        {
            label4.Text = NewAcc.Name;
            label5.Text = NewAcc.Username;
            label6.Text = NewAcc.Password;
        }
    }
}
