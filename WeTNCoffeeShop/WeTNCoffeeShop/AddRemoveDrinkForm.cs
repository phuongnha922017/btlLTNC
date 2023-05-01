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
//using WeTNCoffeeShop.tdo;
using WeTNCoffeShop.tdo;
using System.Windows.Controls;
using WeTNCoffeeShop.tdo;
using System.Globalization;

namespace WeTNCoffeeShop
{
    public partial class AddRemoveDrinkForm : Form
    {
        //String stdDetail = "{0, -10}{1, -40}{2, -20}";
        private static CategoryListModel catList = new CategoryListModel();
        
        private int lastClickDrink = -1;
        public AddRemoveDrinkForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void setDrinkTab_Load()
        {
            setDrinkTab.Controls.Clear();
            catList = CategoryListModel.Instance.GetCategoryList();
            foreach (DrinkCategoryModel dc in catList.CategoryList)
            {
                TabPage tp = new TabPage();
                tp.Name = dc.CategoryId.ToString();
                tp.Text = dc.CategoryName.ToString();
                //tp.TabIndex = dc.CategoryId;
                setDrinkTab.Controls.Add(tp);
                DataGridView dgv = new DataGridView();
                dgv.Dock = DockStyle.Fill;
                dgv.Name = "table" + tp.Name;
                dgv.Font = new Font("Courier New", 14);
                List<DrinkModel> dl = getDrinkListOfCategory(dc.CategoryId);
                tp.Controls.Add(dgv);
                dgv.AutoGenerateColumns = false;
                dgv.ColumnHeadersHeight = 46;
                dgv.DataSource = dl;

                var nameCol = new DataGridViewTextBoxColumn();
                nameCol.HeaderText = "Tên";
                nameCol.DataPropertyName = "drinkName";
                nameCol.Name = "drinkName";
                nameCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns.Add(nameCol);

                var priceCol = new DataGridViewTextBoxColumn();
                priceCol.HeaderText = "Giá (VNĐ)";
                priceCol.DataPropertyName = "drinkPrice";
                priceCol.Name = "drinkPrice";
                priceCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgv.Columns.Add(priceCol);

                
                var productIdCol = new DataGridViewTextBoxColumn();
                productIdCol.HeaderText = "ID";
                productIdCol.DataPropertyName = "productId";
                productIdCol.Name = "productId";
                productIdCol.Visible = false;
                dgv.Columns.Add(productIdCol);
                

                var bindingList = new BindingList<DrinkModel>(dl);
                var source = new BindingSource(bindingList, null);
                dgv.DataSource = source;
                
                
            }
        }

        public void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ListBox selectedLb = (System.Windows.Forms.ListBox)sender;
            
        }

        private void AddRemoveDrinkForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'coffeeShopDataSet.Product' table. You can move, or remove it, as needed.
            //this.productTableAdapter.Fill(this.coffeeShopDataSet.Product);

            
            this.Size = new Size(1200, 900);
            
            setDrinkTab_Load();
            
            

            //listBox1.Items.Add(String.Format(stdDetail, "Stt", "Tên", "Giá (vnđ)")); 
            //listBox2.Items.Add(String.Format(stdDetail, "Stt", "Tên", "Giá (vnđ)"));
        }

        List<DrinkModel> getDrinkListOfCategory(int categoryId)
        {
            DrinkCategoryModel newCat = new DrinkCategoryModel(categoryId, "");
            return newCat.getDrinkList();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if(setDrinkTab.TabPages.Count == 0) MessageBox.Show("Chưa có món được chọn");
            else
            {
                DataGridView gv = (DataGridView)setDrinkTab.SelectedTab.Controls[0];
                if (gv.Rows.Count == 1) MessageBox.Show("Chưa có món được chọn");
                else
                {
                    string message = "Bạn có chắc chắn muốn xóa món này?";
                    string title = "Xóa món";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {

                        foreach (DataGridViewRow selectedRow in gv.SelectedRows)
                        {
                            int thisTabIndex = setDrinkTab.SelectedIndex;
                            DrinkModel.Instance.removeDrink((int)selectedRow.Cells["productId"].Value);

                            MessageBox.Show("Xóa thành công");
                            //
                            BindingSource thisSource = (BindingSource)gv.DataSource;
                            BindingList<DrinkModel> thisList = (BindingList<DrinkModel>)thisSource.List;
                            DrinkModel item = (DrinkModel)thisList.FirstOrDefault(x => x.ProductId == (int)selectedRow.Cells["productId"].Value);
                            thisList.Remove(item);
                            
                        }


                    }
                }
            }
            
            
            
            //

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            addGroupBox.Visible = true;
            addGroupBox.Enabled = true;
            panel1.Enabled = false;
            panel2.Enabled = false;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            renameDrinkBox.Visible = true;
            renameDrinkBox.Enabled = true;
            panel1.Enabled = false;
            panel2.Enabled = false;




        }

        private void delGroupBtn_Click(object sender, EventArgs e)
        {
            if (setDrinkTab.TabCount == 0) MessageBox.Show("Không có tab được chọn");
            else
            {
                delGroupBox.Visible = true;
                delGroupBox.Enabled = true;
                panel1.Enabled = false;
                panel2.Enabled = false;
                label19.Text = setDrinkTab.SelectedTab.Text;
                

            }
            
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addDrinkBox.Visible = true;
            addDrinkBox.Enabled = true;
            panel1.Enabled = false;
            panel2.Enabled = false;
      
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {

        }

       

        private void modifyPriceBtn_Click(object sender, EventArgs e)
        {
            if(setDrinkTab.TabPages.Count == 0) MessageBox.Show("Chưa có món được chọn");
            else
            {
                DataGridView gv = (DataGridView)setDrinkTab.SelectedTab.Controls[0];
               
                if (gv.Rows.Count == 1) MessageBox.Show("Chưa có món được chọn");
                
                else
                {

                    if (gv.SelectedRows.Count != 0)
                    {
                        if (gv.SelectedRows.Count != 1)
                        {
                            MessageBox.Show("Vui lòng chỉ chọn một món");
                        }
                        else
                        {
                            label5.Text = gv.SelectedRows[0].Cells["drinkPrice"].Value.ToString();

                            changePriceBox.Visible = true;
                            changePriceBox.Enabled = true;
                            label1.Enabled = false;
                            label2.Enabled = false;

                        }
                    }
                    else if (gv.SelectedCells.Count != 0)
                    {
                        if (gv.SelectedCells.Count >= 3)
                        {
                            MessageBox.Show("Vui lòng chỉ chọn một món");
                        }
                        else if (gv.SelectedCells.Count == 2 && gv.SelectedCells[0].RowIndex != gv.SelectedCells[1].RowIndex)
                        {
                            MessageBox.Show("Vui lòng chỉ chọn một món");
                        }
                        else
                        {
                            label5.Text = gv.Rows[gv.SelectedCells[0].RowIndex].Cells["drinkPrice"].Value.ToString();
                            changePriceBox.Visible = true;
                            changePriceBox.Enabled = true;
                            label1.Enabled = false;
                            label2.Enabled = false;

                        }
                    }

                }
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newDrinkName.Text == "") MessageBox.Show("Vui lòng nhập tên món");
            else if (newDrinkPrice.Text == "") MessageBox.Show("Vui lòng nhập giá tiền");
            else
            {
                bool check = DrinkModel.Instance.addDrink(newDrinkName.Text, Convert.ToInt32(setDrinkTab.SelectedTab.Name), Convert.ToInt64(newDrinkPrice.Text));
                if (check)
                {
                    int thisTabIndex = setDrinkTab.SelectedIndex;
                    setDrinkTab_Load();
                    setDrinkTab.SelectTab(thisTabIndex);
                    addDrinkBox.Enabled = false;
                    addDrinkBox.Visible = false;
                    panel1.Enabled = true;
                    panel2.Enabled = true;
                }
                
                
                
            }
            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addDrinkBox.Enabled = false;
            addDrinkBox.Visible = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //
            try
            {
                if(newPriceTextBox.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập giá mới");
                }
                else
                {
                    long newPrice = Convert.ToInt64(newPriceTextBox.Text);
                    if(newPrice < 0) MessageBox.Show("Nhập giá không hợp lệ");
                    else
                    {
                        DataGridView gv = (DataGridView)setDrinkTab.SelectedTab.Controls[0];
                        DataGridViewRow selectedRow = gv.Rows[gv.SelectedCells[0].RowIndex];
                        DrinkModel.Instance.changePrice((int)selectedRow.Cells["productId"].Value, newPrice);
                        BindingSource thisSource = (BindingSource)gv.DataSource;
                        BindingList<DrinkModel> thisList = (BindingList<DrinkModel>)thisSource.List;
                        DrinkModel item = (DrinkModel)thisList.FirstOrDefault(x => x.ProductId == (int)selectedRow.Cells["productId"].Value);
                        int index = thisList.IndexOf(item);
                        item.DrinkPrice = newPrice;
                        MessageBox.Show("Đổi giá thành công");
                        thisList[index] = item;
                        changePriceBox.Visible = false;
                        changePriceBox.Enabled = false;
                        label1.Enabled = true;
                        label2.Enabled = true;
                    }
                } 
            }
            catch//(FormatException ex)
            {
                MessageBox.Show("Nhập giá không hợp lệ");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changePriceBox.Visible = false;
            changePriceBox.Enabled = false;
            label1.Enabled = true;
            label2.Enabled = true;
        }

        
        private void iconButton1_Click_2(object sender, EventArgs e)
        {
            renameDrinkBox.Visible = true;
            renameDrinkBox.Enabled = true;
            panel1.Enabled = false;
            panel2.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            renameDrinkBox.Visible = false;
            renameDrinkBox.Enabled = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            renameDrinkBox.Visible = false;
            renameDrinkBox.Enabled = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            renameDrinkBox.Visible = false;
            renameDrinkBox.Enabled = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CategoryListModel.Instance.removeCategory(Convert.ToInt32(setDrinkTab.SelectedTab.Name));
            setDrinkTab.TabPages.Remove(setDrinkTab.SelectedTab);
            catList = CategoryListModel.Instance.GetCategoryList();
            delGroupBox.Visible = false;
            delGroupBox.Enabled = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            delGroupBox.Visible = false;
            delGroupBox.Enabled = false;
            panel1.Enabled = true;
            panel2.Enabled = true;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (newGroupText.Text == "") MessageBox.Show("Vui lòng nhập tên nhóm");
            else
            {
                bool res = addGroupFromForm(newGroupText.Text);
                catList = CategoryListModel.Instance.GetCategoryList();
                addGroupBox.Visible = false;
                addGroupBox.Enabled = false;
                panel1.Enabled = true;
                panel2.Enabled = true;
                setDrinkTab_Load();


            }
           
        }

        bool addGroupFromForm(string groupName)
        {
            return CategoryListModel.Instance.addGroup(groupName);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            addGroupBox.Visible = false;
            addGroupBox.Enabled = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            delDrinkBox.Visible = false;
            delDrinkBox.Enabled = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            delDrinkBox.Visible = false;
            delDrinkBox.Enabled = false;
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            renameDrinkBox.Visible = false;
            renameDrinkBox.Enabled = false; 
            panel1.Enabled = true;
            panel2.Enabled = true;
        }

        private void addDrinkBox_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void addGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void setDrinkTab_SelectedIndexChanged(Object sender, EventArgs e)
        {
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
