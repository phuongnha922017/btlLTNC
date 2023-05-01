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
using static System.Windows.Forms.LinkLabel;

namespace WeTNCoffeeShop
{
    public partial class StaffAccountForm : Form
    {
        //String stdDetail = "{0, -6}{1, -26}{2, -17}{3, -17}";
        List<Account> accList = new List<Account>();
        
        
        public StaffAccountForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void StaffAccountForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 600);
            accList = Account.Instance.getAccountsList();
            foreach(Account acc in accList)
            {
                
                if(acc.Status == 0) staffTable.Rows.Add(acc.Name, acc.Username, acc.Password);
               
            }
        }

        private void addAccountBtn_Click(object sender, EventArgs e)
        {
            if(getNameTb.Text == "" || getUserTb.Text == "" || getPassTb.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                CheckAccount.Instance.InsertAccount(getUserTb.Text, getNameTb.Text, getPassTb.Text, getPassTb.Text);
               ;
                staffTable.Rows.Add(getNameTb.Text, getUserTb.Text, getPassTb.Text);
               
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Bạn có chắc chắn muốn xóa tài khoản này?";
            string title = "Xóa tài khoản";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                foreach(DataGridViewRow row in staffTable.SelectedRows) {
                    Account.Instance.removeAccount(row.Cells["Username"].Value.ToString());
                    staffTable.Rows.Remove(row);
                }
                
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mangeLogoutBtn_Click(object sender, EventArgs e)
        {
            ManagerMainPageForm newPage = new ManagerMainPageForm();
            this.Hide();
            newPage.ShowDialog();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
