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
using WeTNCoffeeShop.TableClass;

namespace WeTNCoffeeShop
{
    
    public partial class InfoForm : Form
    {
        static Account thisManager = new Account();
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 600);
            thisManager = Account.Instance.getManagerAccount();
            nameLbl.Text = thisManager.Name;
            userLbl.Text = thisManager.Username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newNameTb.Text == "" && newUsernameTb.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin cần thay đổi");
            }
            else
            {
                if (newUsernameTb.Text != "")
                {
                    bool check = Account.Instance.ChangeUserName(thisManager.Id, newUsernameTb.Text);
                    if (check)
                    {
                        userLbl.Text = newUsernameTb.Text;
                    }
                }
                if (newNameTb.Text != "")
                {
                    Account.Instance.ChangeName(thisManager.Id, newNameTb.Text);
                    nameLbl.Text = newNameTb.Text;
                    ManagerMainPageForm.managerPage.welcomeLabel.Text = "Welcome: " + newNameTb.Text;
                }
                
            }
            
        }

        private void changePassBtn_Click(object sender, EventArgs e)
        {
            ChangePassForm newPage = new ChangePassForm();
            //this.Hide();
            newPage.ShowDialog();
        }

        private void mangeLogoutBtn_Click(object sender, EventArgs e)
        {
            ManagerMainPageForm newPage = new ManagerMainPageForm();
            this.Hide();
            newPage.ShowDialog(); 
        }
    }
}
