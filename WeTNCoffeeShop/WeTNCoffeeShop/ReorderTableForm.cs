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
using WeTNCoffeShop.tdo;
using System.Globalization;
using static System.Net.WebRequestMethods;
using System.Windows.Documents;

namespace WeTNCoffeeShop
{
    public partial class ReorderTableForm : Form
    {
        static List<AreaModel> areaList = new List<AreaModel>();
        static BindingSource bindingSource = new BindingSource();
        static List<int> allTableList = new List<int>();
        public static ReorderTableForm orderTable;
        public TabControl tableTab;
        public ReorderTableForm()
        {
            InitializeComponent();
            orderTable = this;
            tableTab = this.tabSettingTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LoadTable()
        {
            tabSettingTable.Controls.Clear();
            areaList = AreaListModel.Instance.getListArea();
            foreach (AreaModel area in areaList)
            {
                TabPage tp = new TabPage();
                tp.Name = area.AreaId.ToString();
                tp.Text = area.Name.ToString();
                //tp.TabIndex = dc.CategoryId;
                tabSettingTable.Controls.Add(tp);
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.BackColor = Color.Firebrick;
                tp.Controls.Add(flp);
                List<TableModel> tableList = getTableListOfArea(area.AreaId);
                
                //Add table
                foreach(TableModel table in tableList)
                {
                    Button tableBtn = new Button();
                    tableBtn.Name = "table" + table.TableId.ToString();
                    tableBtn.Text = "Bàn " + table.TableId.ToString();
                    tableBtn.Size = new Size(100, 70);
                    tableBtn.BackColor = Color.Khaki;
                    flp.Controls.Add(tableBtn);
                    allTableList.Add(table.TableId);
                }
            }
            BindingList<AreaModel> list = new BindingList<AreaModel>(areaList);
            bindingSource.DataSource = list;
            areaLb.DataSource = list;
            areaLb.DisplayMember = "Name";
        }

        List<TableModel> getTableListOfArea(int areaId)
        {
            AreaModel area = new AreaModel(areaId, "");
            return area.getTableList();
        } 
        private void ReorderTableForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 900);
            LoadTable();
            

        
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delAreaBtn_Click(object sender, EventArgs e)
        {
            if (tabSettingTable.TabPages.Count == 0) MessageBox.Show("Chưa có khu vực được chọn");
            else
            {
                string message = "Bạn có chắc chắn muốn xóa khu vực này?";
                string title = "Xóa khu vực";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    AreaListModel.Instance.removeArea(Convert.ToInt32(tabSettingTable.SelectedTab.Name));
                    BindingList<AreaModel> thisList = (BindingList<AreaModel>)bindingSource.List;
                    AreaModel item = (AreaModel)thisList.FirstOrDefault(x => x.AreaId == Convert.ToInt32(tabSettingTable.SelectedTab.Name));
                    thisList.Remove(item);
                    tabSettingTable.Controls.Remove(tabSettingTable.SelectedTab);
                    

                }
            }
        }
        
        private void iconButton1_Click(object sender, EventArgs e)
        {
            AddRemoveTableForm newPage = new AddRemoveTableForm();
            this.Hide();
            newPage.ShowDialog();
        }

        private void addAreaBtn_Click(object sender, EventArgs e)
        {
            addAreaBox.Visible = true;
            addAreaBox.Enabled = true;
            panel14.Enabled = false;
            panel15.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (newAreaName.Text == "") MessageBox.Show("Vui lòng nhập tên khu vực");
            else
            {
                bool check = AreaListModel.Instance.addArea(newAreaName.Text);
                if (check)
                {
                    MessageBox.Show("Thêm khu vực thành công");
                    addAreaBox.Enabled = false;
                    addAreaBox.Visible = false;

                    panel14.Enabled = true;
                    panel15.Enabled = true;
                    LoadTable();

                }
            }
            
            //add

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addAreaBox.Enabled = false;
            addAreaBox.Visible = false;
            panel14.Enabled = true;
            panel15.Enabled = true;

        }


        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveAreaBox.Enabled = false;
            moveAreaBox.Visible = false;
            panel14.Enabled = true;
            panel15.Enabled = true;
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            if (tabSettingTable.TabPages.Count == 0) MessageBox.Show("Khu vực trống");
            else
            {
                moveAreaBox.Enabled = true;
                moveAreaBox.Visible = true;
                panel14.Enabled = false;
                panel15.Enabled = false;
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (moveTableTb.Text == "") MessageBox.Show("Chưa có bàn được chọn");
            else
            {
                try
                {
                    int tableId = Convert.ToInt32(moveTableTb.Text);
                    if (tableId <= 0) MessageBox.Show("Lỗi nhập bàn");
                    else
                    {
                        if (!allTableList.Contains(tableId))
                        {
                            MessageBox.Show("Không có bàn trong hệ thống");
                        }
                        else
                        {
                            int currentArea = TableModel.Instance.getAreaId(tableId);
                            AreaModel area = (AreaModel)areaLb.SelectedItem;
                            TableModel.Instance.moveToArea(tableId, area.AreaId);
                            MessageBox.Show("Chuyển bàn thành công");
                            var CurrentPanel = tabSettingTable.TabPages[currentArea.ToString()].Controls[0];
                            CurrentPanel.Controls.Remove(CurrentPanel.Controls["table" + tableId.ToString()]);
                            var toPanel = tabSettingTable.TabPages[area.AreaId.ToString()].Controls[0];
                            Button tableBtn = new Button();
                            tableBtn.Name = "table" + tableId.ToString();
                            tableBtn.Text = "Bàn " + tableId.ToString();
                            tableBtn.Size = new Size(100, 70);
                            tableBtn.BackColor = Color.Khaki;
                            toPanel.Controls.Add(tableBtn);
                            moveAreaBox.Enabled = false;
                            moveAreaBox.Visible = false;
                            panel14.Enabled = true;
                            panel15.Enabled = true;
                        }
                    }

                }
                catch//(FormatException Ex)
                {
                    MessageBox.Show("Lỗi nhập bàn");
                }
            }    
       
            
        }

        private void moveTableTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
