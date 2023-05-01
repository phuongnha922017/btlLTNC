using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using WeTNCoffeeShop.tdo;
using WeTNCoffeShop.tdo;

namespace WeTNCoffeeShop
{
    public partial class AddRemoveTableForm : Form
    {
        static List<TableModel> allTable = new List<TableModel>();
        static List<AreaModel> areaList = new List<AreaModel>();
        static BindingSource source1 = new BindingSource();
        static BindingSource source2 = new BindingSource();
        static List<int> tempIdList = new List<int>();
        static List<int> getRmList = new List<int>();
        public AddRemoveTableForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void noTableLabel_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void addTableUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (defaultAddTableButton.Checked)
            {
                
                panel20.Enabled = false;
                addTableLb.Items.Clear();
                int addQuantity = (int)addTableUpDown.Value;
                int maxId = allTable.Max(x => x.TableId);
                for (int i = maxId + 1; i <= maxId + addQuantity; i++)
                {
                    addTableLb.Items.Add(i);
                }

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void addTableList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ReorderTableForm.orderTable.Show();

        }

        private void AddRemoveTableForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1200, 900);
            allTable = TableListModel.Instance.getAllTable();
            label3.Text = "Số bàn hiện tại: " + allTable.Count.ToString();
            areaList = AreaListModel.Instance.getListArea();
            BindingList<AreaModel> list = new BindingList<AreaModel>(areaList);
            source1.DataSource = list;
            source2.DataSource = list;
            comboBox1.DataSource = source1;
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedIndex = 0;
            comboBox2.DataSource = source2;
            comboBox2.DisplayMember = "Name";
            comboBox2.SelectedIndex = 0;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void defaltAddTableButton_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultAddTableButton.Checked)
            {
                panel20.Enabled = false;
                addTableUpDown.Enabled = true;
                addTableLb.Items.Clear();
                int addQuantity = (int)addTableUpDown.Value;
                int maxId = allTable.Max(x => x.TableId);
                for (int i = maxId + 1; i <= maxId + addQuantity; i++)
                {
                    addTableLb.Items.Add(i);
                }
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (defaultAddTableButton.Checked)
            {

                panel20.Enabled = false;
                addTableLb.Items.Clear();
                int addQuantity = (int)addTableUpDown.Value;
                int maxId = allTable.Max(x => x.TableId);
                for (int i = maxId + 1; i <= maxId + addQuantity; i++)
                {
                    addTableLb.Items.Add(i);
                }

            }
        }

        private void setAddTableButton_CheckedChanged(object sender, EventArgs e)
        {
            if (setAddTableButton.Checked)
            {
                addTableUpDown.Enabled = false;
                addTableLb.Items.Clear();
                panel20.Enabled = true;
            }
            
        }

        private void setAdTableBtn_Click(object sender, EventArgs e)
        {
            if (addTableTb.Text == "") MessageBox.Show("Vui lòng nhập số bàn");
            else
            {
                try
                {
                    int addId = Convert.ToInt32(addTableTb.Text);
                    if (addId <= 0) MessageBox.Show("Lỗi nhập bàn");
                    else
                    {
                        if (tempIdList.Contains(addId)) MessageBox.Show("Bàn nhập trùng, vui lòng nhập lại");
                        else
                        {
                            int index = allTable.FindIndex(item => item.TableId == addId);
                            if (index >= 0) MessageBox.Show("Đã tồn tại bàn trong hệ thống, vui lòng nhập bàn khác");
                            else
                            {
                                tempIdList.Add(addId);
                                addTableLb.Items.Add(addId);
                            }
                        }
                    }
                }
                catch//(FormatException ex)
                {
                    MessageBox.Show("Lỗi nhập bàn");
                }
                addTableTb.Clear();
            }
        }

        private void addTableTb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void confirmAdTableBtn_Click(object sender, EventArgs e)
        {
            AreaModel area = (AreaModel)comboBox1.SelectedItem;
            for(int i = 0; i < addTableLb.Items.Count; i++)
            {
                TableModel.Instance.insertTable((int)addTableLb.Items[i], area.AreaId);
                allTable.Add(new TableModel((int)addTableLb.Items[i], area.AreaId));
                FlowLayoutPanel areaPanel = (FlowLayoutPanel)ReorderTableForm.orderTable.tableTab.TabPages[area.AreaId.ToString()].Controls[0];
                Button tableBtn = new Button();
                tableBtn.Name = "table" + addTableLb.Items[i].ToString();
                tableBtn.Text = "Bàn " + addTableLb.Items[i].ToString();
                tableBtn.Size = new Size(100, 70);
                tableBtn.BackColor = Color.Khaki;
                areaPanel.Controls.Add(tableBtn);
            }
            MessageBox.Show("Thêm bàn thành công");
            tempIdList.Clear();
            addTableLb.Items.Clear();
            addTableUpDown.Value = 0;
            label3.Text = "Số bàn hiện tại: " + allTable.Count.ToString();
        }

        private void defaultRmRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(defaultRmRadio.Checked)
            {
                panel36.Enabled = true;
                panel37.Enabled = false;
                rmTableLb.Items.Clear();
            }
        }

        private void setRmRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (setRmRadio.Checked)
            {
                panel36.Enabled = false;
                panel37.Enabled = true;
                rmTableLb.Items.Clear();
            }

            
        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void setRmTableBtn_Click(object sender, EventArgs e)
        {
            if (rmTableTb.Text == "") MessageBox.Show("Vui lòng nhập số bàn");
            else
            {
                try
                {
                    int rmId = Convert.ToInt32(rmTableTb.Text);
                    if (rmId <= 0) MessageBox.Show("Lỗi nhập bàn");
                    else
                    {
                        if (getRmList.Contains(rmId)) MessageBox.Show("Bàn nhập trùng, vui lòng nhập lại");
                        else
                        {
                            int index = allTable.FindIndex(item => item.TableId == rmId);
                            if (index == -1) MessageBox.Show("Không tồn tại bàn");
                            else
                            {
                                getRmList.Add(rmId);
                                rmTableLb.Items.Add(rmId);
                            }
                        }
                    }
                }
                catch// (FormatException ex)
                {
                    MessageBox.Show("Lỗi nhập bàn");
                }
                addTableTb.Clear();
            }
        }

        private void rmTableUpDown_ValueChanged(object sender, EventArgs e)
        {
            rmTableLb.Items.Clear();
            AreaModel thisArea = (AreaModel)comboBox2.SelectedItem;
            int rmQuantity = (int)rmTableUpDown.Value;
            List<TableModel> tableOfThisArea = thisArea.getTableList();
            for(int i = tableOfThisArea.Count - 1; i >= tableOfThisArea.Count - rmQuantity && i >= 0; i--)
            {
                getRmList.Add(tableOfThisArea[i].TableId);
                rmTableLb.Items.Add(tableOfThisArea[i].TableId);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rmTableLb.Items.Count; i++)
            {
                TableModel rmTable = allTable.FirstOrDefault(x => x.TableId == (int)rmTableLb.Items[i]);

                int areaId = rmTable.AreaId;
               
                FlowLayoutPanel rmArea = (FlowLayoutPanel)ReorderTableForm.orderTable.tableTab.TabPages[areaId.ToString()].Controls[0];
                rmArea.Controls.Remove(rmArea.Controls["table" + rmTable.TableId.ToString()]);
                allTable.Remove(rmTable);
                TableModel.Instance.removeTable((int)rmTableLb.Items[i]);
            }
            MessageBox.Show("Xóa bàn thành công");
            getRmList.Clear();
            rmTableLb.Items.Clear();
            rmTableUpDown.Value = 0;
            label3.Text = "Số bàn hiện tại: " + allTable.Count.ToString();
        }
            

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rmTableLb.Items.Clear();
            AreaModel thisArea = (AreaModel)comboBox2.SelectedItem;
            int rmQuantity = (int)rmTableUpDown.Value;
            List<TableModel> tableOfThisArea = thisArea.getTableList();
            for (int i = tableOfThisArea.Count - 1; i >= tableOfThisArea.Count - rmQuantity && i >= 0; i--)
            {
                getRmList.Add(tableOfThisArea[i].TableId);
                rmTableLb.Items.Add(tableOfThisArea[i].TableId);
            }
        }
    }
}
