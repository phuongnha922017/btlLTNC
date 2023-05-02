namespace WeTNCoffeeShop
{
    partial class StaticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaticForm));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.byRevenueBtn = new System.Windows.Forms.RadioButton();
            this.byDrinkBtn = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(131, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(241, 29);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(553, 29);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đến:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "Từ:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Right;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(470, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(237, 45);
            this.label20.TabIndex = 11;
            this.label20.Text = "THỐNG KÊ";
            // 
            // chart
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.LabelAngle = 90;
            series1.LabelForeColor = System.Drawing.Color.IndianRed;
            series1.Legend = "Legend1";
            series1.Name = "revenue";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "quantity";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(1332, 390);
            this.chart.TabIndex = 0;
            this.chart.Text = "Thống kê doanh thu";
            title1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "byRevenue";
            title1.Text = "Thống kê theo doanh thu";
            this.chart.Titles.Add(title1);
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.LineChart;
            this.iconButton1.IconColor = System.Drawing.Color.Brown;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(1067, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(265, 84);
            this.iconButton1.TabIndex = 14;
            this.iconButton1.Text = "Thống kê";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // byRevenueBtn
            // 
            this.byRevenueBtn.AutoSize = true;
            this.byRevenueBtn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byRevenueBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.byRevenueBtn.Location = new System.Drawing.Point(156, 70);
            this.byRevenueBtn.Name = "byRevenueBtn";
            this.byRevenueBtn.Size = new System.Drawing.Size(271, 49);
            this.byRevenueBtn.TabIndex = 15;
            this.byRevenueBtn.TabStop = true;
            this.byRevenueBtn.Text = "Theo doanh thu";
            this.byRevenueBtn.UseVisualStyleBackColor = true;
            // 
            // byDrinkBtn
            // 
            this.byDrinkBtn.AutoSize = true;
            this.byDrinkBtn.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byDrinkBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.byDrinkBtn.Location = new System.Drawing.Point(695, 70);
            this.byDrinkBtn.Name = "byDrinkBtn";
            this.byDrinkBtn.Size = new System.Drawing.Size(252, 49);
            this.byDrinkBtn.TabIndex = 17;
            this.byDrinkBtn.TabStop = true;
            this.byDrinkBtn.Text = "Theo từng loại";
            this.byDrinkBtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1478, 51);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 813);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1478, 31);
            this.panel3.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1478, 85);
            this.panel1.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label20);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(707, 85);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 136);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(67, 677);
            this.panel5.TabIndex = 12;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1399, 136);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(79, 677);
            this.panel6.TabIndex = 21;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(67, 136);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1332, 144);
            this.panel7.TabIndex = 22;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.byRevenueBtn);
            this.panel8.Controls.Add(this.byDrinkBtn);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(67, 670);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1332, 143);
            this.panel8.TabIndex = 23;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.chart);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(67, 280);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1332, 390);
            this.panel9.TabIndex = 24;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.iconButton1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1332, 84);
            this.panel10.TabIndex = 15;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label2);
            this.panel11.Controls.Add(this.dateTimePicker2);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.dateTimePicker1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(773, 84);
            this.panel11.TabIndex = 15;
            // 
            // StaticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1478, 844);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StaticForm";
            this.Text = "StaticForm";
            this.Load += new System.EventHandler(this.StaticForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.RadioButton byRevenueBtn;
        private System.Windows.Forms.RadioButton byDrinkBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
    }
}