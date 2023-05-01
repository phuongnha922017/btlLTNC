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
    public partial class ManagerMainPageForm : Form
    {
        public static ManagerMainPageForm managerPage;
        public Label welcomeLabel;
        public ManagerMainPageForm()
        {
            InitializeComponent();
            managerPage = this;
            welcomeLabel = this.label1;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            flowLayoutPanel1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaticForm newPage = new StaticForm(); 
            newPage.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ManagerMainPageForm_Load(object sender, EventArgs e)
        {
            Account thisManager = Account.Instance.getManagerAccount();
            label1.Text = "Welcome: " + thisManager.Name;
            //this.Size = new Size(1200, 900);
        }

        private void discountButton_Click(object sender, EventArgs e)
        {
            BillAdjustForm newPage = new BillAdjustForm();
            this.Hide();    
            newPage.ShowDialog();
        }

        private void staffManageButton_Click(object sender, EventArgs e)
        {
            StaffAccountForm newPage = new StaffAccountForm();
            newPage.ShowDialog();
        }

        private void changPassBtn_Click(object sender, EventArgs e)
        {
            InfoForm newPage = new InfoForm();
            this.Hide();
            newPage.ShowDialog();
        }

        private void changePassBtn_Click(object sender, EventArgs e)
        {
            InfoForm newPage = new InfoForm();
            newPage.ShowDialog();
        }

        private void mangeLogoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addRemoveDrinkButton_Click(object sender, EventArgs e)
        {
            AddRemoveDrinkForm newPage = new AddRemoveDrinkForm();
            panel2.Visible = false;
            flowLayoutPanel1.Visible = true;
            newPage.ShowDialog();
        }

        private void addRemoveTableButton_Click(object sender, EventArgs e)
        {
            ReorderTableForm newPage = new ReorderTableForm();
            panel2.Visible = false;
            flowLayoutPanel1.Visible = true;
            newPage.ShowDialog();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
