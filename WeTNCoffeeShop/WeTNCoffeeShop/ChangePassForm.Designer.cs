namespace WeTNCoffeeShop
{
    partial class ChangePassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oldTypeTb = new System.Windows.Forms.MaskedTextBox();
            this.newTypeTb = new System.Windows.Forms.MaskedTextBox();
            this.newRetypeTb = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập mật khẩu cũ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 36);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhập mật khẩu mới:";
            // 
            // oldTypeTb
            // 
            this.oldTypeTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldTypeTb.Location = new System.Drawing.Point(472, 262);
            this.oldTypeTb.Name = "oldTypeTb";
            this.oldTypeTb.Size = new System.Drawing.Size(345, 39);
            this.oldTypeTb.TabIndex = 5;
            this.oldTypeTb.UseSystemPasswordChar = true;
            // 
            // newTypeTb
            // 
            this.newTypeTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTypeTb.Location = new System.Drawing.Point(474, 342);
            this.newTypeTb.Name = "newTypeTb";
            this.newTypeTb.Size = new System.Drawing.Size(345, 39);
            this.newTypeTb.TabIndex = 6;
            this.newTypeTb.UseSystemPasswordChar = true;
            // 
            // newRetypeTb
            // 
            this.newRetypeTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRetypeTb.Location = new System.Drawing.Point(474, 411);
            this.newRetypeTb.Name = "newRetypeTb";
            this.newRetypeTb.Size = new System.Drawing.Size(345, 39);
            this.newRetypeTb.TabIndex = 8;
            this.newRetypeTb.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nhập lại mật khẩu:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(638, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 53);
            this.button1.TabIndex = 9;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(464, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(329, 45);
            this.label8.TabIndex = 10;
            this.label8.Text = "ĐỔI MẬT KHẨU";
            // 
            // ChangePassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newRetypeTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newTypeTb);
            this.Controls.Add(this.oldTypeTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePassForm";
            this.Text = "changPassForm";
            this.Load += new System.EventHandler(this.ChangPassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox oldTypeTb;
        private System.Windows.Forms.MaskedTextBox newTypeTb;
        private System.Windows.Forms.MaskedTextBox newRetypeTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
    }
}