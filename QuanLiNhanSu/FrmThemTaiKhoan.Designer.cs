namespace QuanLiNhanSu
{
    partial class FrmThemTaiKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtXacNhan = new System.Windows.Forms.TextBox();
            this.btnTaoTK = new System.Windows.Forms.Button();
            this.chHienMatKhau = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên tài khoản";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(160, 42);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(188, 20);
            this.txtTaiKhoan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(160, 86);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(188, 20);
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Xác nhận mật khẩu";
            // 
            // txtXacNhan
            // 
            this.txtXacNhan.Location = new System.Drawing.Point(160, 139);
            this.txtXacNhan.Name = "txtXacNhan";
            this.txtXacNhan.Size = new System.Drawing.Size(188, 20);
            this.txtXacNhan.TabIndex = 5;
            this.txtXacNhan.UseSystemPasswordChar = true;
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.Location = new System.Drawing.Point(160, 190);
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.Size = new System.Drawing.Size(87, 23);
            this.btnTaoTK.TabIndex = 6;
            this.btnTaoTK.Text = "Tạo tài khoản";
            this.btnTaoTK.UseVisualStyleBackColor = true;
            this.btnTaoTK.Click += new System.EventHandler(this.btnTaoTK_Click);
            // 
            // chHienMatKhau
            // 
            this.chHienMatKhau.AutoSize = true;
            this.chHienMatKhau.Location = new System.Drawing.Point(253, 194);
            this.chHienMatKhau.Name = "chHienMatKhau";
            this.chHienMatKhau.Size = new System.Drawing.Size(95, 17);
            this.chHienMatKhau.TabIndex = 7;
            this.chHienMatKhau.Text = "Hiện mật khẩu";
            this.chHienMatKhau.UseVisualStyleBackColor = true;
            this.chHienMatKhau.CheckedChanged += new System.EventHandler(this.chHienMatKhau_CheckedChanged);
            // 
            // FrmThemTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 280);
            this.Controls.Add(this.chHienMatKhau);
            this.Controls.Add(this.btnTaoTK);
            this.Controls.Add(this.txtXacNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.label1);
            this.Name = "FrmThemTaiKhoan";
            this.Text = "Thêm tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXacNhan;
        private System.Windows.Forms.Button btnTaoTK;
        private System.Windows.Forms.CheckBox chHienMatKhau;
    }
}