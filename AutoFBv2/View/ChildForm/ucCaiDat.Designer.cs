
namespace AutoFB.View.ChildForm
{
    partial class ucCaiDat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabChrome = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ckDungChromeMacDinh = new System.Windows.Forms.CheckBox();
            this.btnChonThuMuc = new System.Windows.Forms.Button();
            this.txtChromeProfile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChonFileChrome = new System.Windows.Forms.Button();
            this.txtChromePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCauHinh = new System.Windows.Forms.TabPage();
            this.btnTatchedoluuthongsomacdinh = new System.Windows.Forms.Button();
            this.btnLuuthongso = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabSql = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblShow = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTruyVan = new System.Windows.Forms.Button();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.txtNhaplaimatkhau = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMatkhaumoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ckHienthi = new System.Windows.Forms.CheckBox();
            this.txtMatKhaucu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabLicenseKey = new System.Windows.Forms.TabPage();
            this.ckHienLicenseKey = new System.Windows.Forms.CheckBox();
            this.btnLicenseKey = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabChrome.SuspendLayout();
            this.tabCauHinh.SuspendLayout();
            this.tabSql.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblShow)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabLicenseKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChrome);
            this.tabControl1.Controls.Add(this.tabCauHinh);
            this.tabControl1.Controls.Add(this.tabSql);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabLicenseKey);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // tabChrome
            // 
            this.tabChrome.Controls.Add(this.label11);
            this.tabChrome.Controls.Add(this.label10);
            this.tabChrome.Controls.Add(this.label9);
            this.tabChrome.Controls.Add(this.label8);
            this.tabChrome.Controls.Add(this.ckDungChromeMacDinh);
            this.tabChrome.Controls.Add(this.btnChonThuMuc);
            this.tabChrome.Controls.Add(this.txtChromeProfile);
            this.tabChrome.Controls.Add(this.label2);
            this.tabChrome.Controls.Add(this.btnChonFileChrome);
            this.tabChrome.Controls.Add(this.txtChromePath);
            this.tabChrome.Controls.Add(this.label1);
            this.tabChrome.Location = new System.Drawing.Point(4, 22);
            this.tabChrome.Name = "tabChrome";
            this.tabChrome.Padding = new System.Windows.Forms.Padding(3);
            this.tabChrome.Size = new System.Drawing.Size(868, 429);
            this.tabChrome.TabIndex = 0;
            this.tabChrome.Text = "Chrome";
            this.tabChrome.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(522, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "- Thư mục Profile để chứa dữ liệu cho các Profile ( thông tin đăng nhập, lịch sử," +
    "...). Hãy tạo một thư mục rỗng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(562, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "- Nếu dùng chrome mặc định hãy kiểm tra phiên bản chrome tại chrome://version/ so" +
    " với phiên bản chromedriver.exe";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(418, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "- Bạn có thể dùng chromium để ổn định hơn, bằng cách download về và chọn file .ex" +
    "e";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Lưu ý:";
            // 
            // ckDungChromeMacDinh
            // 
            this.ckDungChromeMacDinh.AutoSize = true;
            this.ckDungChromeMacDinh.Checked = true;
            this.ckDungChromeMacDinh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDungChromeMacDinh.Location = new System.Drawing.Point(511, 33);
            this.ckDungChromeMacDinh.Name = "ckDungChromeMacDinh";
            this.ckDungChromeMacDinh.Size = new System.Drawing.Size(151, 17);
            this.ckDungChromeMacDinh.TabIndex = 6;
            this.ckDungChromeMacDinh.Text = "Sử dụng chrome mặc định";
            this.ckDungChromeMacDinh.UseVisualStyleBackColor = true;
            this.ckDungChromeMacDinh.CheckedChanged += new System.EventHandler(this.ckDungChromeMacDinh_CheckedChanged);
            // 
            // btnChonThuMuc
            // 
            this.btnChonThuMuc.Location = new System.Drawing.Point(403, 80);
            this.btnChonThuMuc.Name = "btnChonThuMuc";
            this.btnChonThuMuc.Size = new System.Drawing.Size(102, 23);
            this.btnChonThuMuc.TabIndex = 5;
            this.btnChonThuMuc.Text = "Chọn thư mục";
            this.btnChonThuMuc.UseVisualStyleBackColor = true;
            this.btnChonThuMuc.Click += new System.EventHandler(this.btnChonThuMuc_Click);
            // 
            // txtChromeProfile
            // 
            this.txtChromeProfile.Location = new System.Drawing.Point(18, 81);
            this.txtChromeProfile.Name = "txtChromeProfile";
            this.txtChromeProfile.Size = new System.Drawing.Size(379, 20);
            this.txtChromeProfile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đường dẫn tới thư mục chứa Profile";
            // 
            // btnChonFileChrome
            // 
            this.btnChonFileChrome.Location = new System.Drawing.Point(403, 30);
            this.btnChonFileChrome.Name = "btnChonFileChrome";
            this.btnChonFileChrome.Size = new System.Drawing.Size(102, 23);
            this.btnChonFileChrome.TabIndex = 2;
            this.btnChonFileChrome.Text = "Chọn file .exe";
            this.btnChonFileChrome.UseVisualStyleBackColor = true;
            this.btnChonFileChrome.Click += new System.EventHandler(this.btnChonFileChrome_Click);
            // 
            // txtChromePath
            // 
            this.txtChromePath.Location = new System.Drawing.Point(18, 31);
            this.txtChromePath.Name = "txtChromePath";
            this.txtChromePath.Size = new System.Drawing.Size(379, 20);
            this.txtChromePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn tới chrome.exe";
            // 
            // tabCauHinh
            // 
            this.tabCauHinh.Controls.Add(this.btnTatchedoluuthongsomacdinh);
            this.tabCauHinh.Controls.Add(this.btnLuuthongso);
            this.tabCauHinh.Controls.Add(this.label3);
            this.tabCauHinh.Location = new System.Drawing.Point(4, 22);
            this.tabCauHinh.Name = "tabCauHinh";
            this.tabCauHinh.Size = new System.Drawing.Size(868, 429);
            this.tabCauHinh.TabIndex = 1;
            this.tabCauHinh.Text = "Cấu hình mặc định";
            this.tabCauHinh.UseVisualStyleBackColor = true;
            // 
            // btnTatchedoluuthongsomacdinh
            // 
            this.btnTatchedoluuthongsomacdinh.Location = new System.Drawing.Point(8, 61);
            this.btnTatchedoluuthongsomacdinh.Name = "btnTatchedoluuthongsomacdinh";
            this.btnTatchedoluuthongsomacdinh.Size = new System.Drawing.Size(351, 23);
            this.btnTatchedoluuthongsomacdinh.TabIndex = 5;
            this.btnTatchedoluuthongsomacdinh.Text = "Tắt chế độ lưu thông số cũ";
            this.btnTatchedoluuthongsomacdinh.UseVisualStyleBackColor = true;
            this.btnTatchedoluuthongsomacdinh.Click += new System.EventHandler(this.btnTatchedoluuthongsomacdinh_Click);
            // 
            // btnLuuthongso
            // 
            this.btnLuuthongso.Location = new System.Drawing.Point(8, 31);
            this.btnLuuthongso.Name = "btnLuuthongso";
            this.btnLuuthongso.Size = new System.Drawing.Size(351, 23);
            this.btnLuuthongso.TabIndex = 4;
            this.btnLuuthongso.Text = "Bật chế độ lưu thông số cũ sau khi tắt";
            this.btnLuuthongso.UseVisualStyleBackColor = true;
            this.btnLuuthongso.Click += new System.EventHandler(this.btnLuuthongso_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nếu phần mềm chưa lưu các thông số cũ sau khi tắt, bấm nút dưới";
            // 
            // tabSql
            // 
            this.tabSql.Controls.Add(this.panel2);
            this.tabSql.Controls.Add(this.panel1);
            this.tabSql.Location = new System.Drawing.Point(4, 22);
            this.tabSql.Name = "tabSql";
            this.tabSql.Size = new System.Drawing.Size(868, 429);
            this.tabSql.TabIndex = 2;
            this.tabSql.Text = "Truy vấn dữ liệu";
            this.tabSql.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tblShow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 355);
            this.panel2.TabIndex = 1;
            // 
            // tblShow
            // 
            this.tblShow.AllowUserToAddRows = false;
            this.tblShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblShow.Location = new System.Drawing.Point(0, 0);
            this.tblShow.Name = "tblShow";
            this.tblShow.RowHeadersVisible = false;
            this.tblShow.Size = new System.Drawing.Size(868, 355);
            this.tblShow.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTruyVan);
            this.panel1.Controls.Add(this.txtSql);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnTruyVan
            // 
            this.btnTruyVan.Location = new System.Drawing.Point(618, 4);
            this.btnTruyVan.Name = "btnTruyVan";
            this.btnTruyVan.Size = new System.Drawing.Size(139, 23);
            this.btnTruyVan.TabIndex = 1;
            this.btnTruyVan.Text = "Truy vấn";
            this.btnTruyVan.UseVisualStyleBackColor = true;
            this.btnTruyVan.Click += new System.EventHandler(this.btnTruyVan_Click);
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(4, 4);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(599, 65);
            this.txtSql.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDoiMatKhau);
            this.tabPage1.Controls.Add(this.txtNhaplaimatkhau);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtMatkhaumoi);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.ckHienthi);
            this.tabPage1.Controls.Add(this.txtMatKhaucu);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(868, 429);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Đổi mật khẩu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Location = new System.Drawing.Point(18, 180);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(292, 34);
            this.btnDoiMatKhau.TabIndex = 10;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // txtNhaplaimatkhau
            // 
            this.txtNhaplaimatkhau.Location = new System.Drawing.Point(18, 129);
            this.txtNhaplaimatkhau.Name = "txtNhaplaimatkhau";
            this.txtNhaplaimatkhau.PasswordChar = '*';
            this.txtNhaplaimatkhau.Size = new System.Drawing.Size(292, 20);
            this.txtNhaplaimatkhau.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Nhập lại mật khẩu mới";
            // 
            // txtMatkhaumoi
            // 
            this.txtMatkhaumoi.Location = new System.Drawing.Point(18, 81);
            this.txtMatkhaumoi.Name = "txtMatkhaumoi";
            this.txtMatkhaumoi.PasswordChar = '*';
            this.txtMatkhaumoi.Size = new System.Drawing.Size(292, 20);
            this.txtMatkhaumoi.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nhập mật khẩu mới";
            // 
            // ckHienthi
            // 
            this.ckHienthi.AutoSize = true;
            this.ckHienthi.Location = new System.Drawing.Point(18, 155);
            this.ckHienthi.Name = "ckHienthi";
            this.ckHienthi.Size = new System.Drawing.Size(109, 17);
            this.ckHienthi.TabIndex = 5;
            this.ckHienthi.Text = "Hiển thị mật khẩu";
            this.ckHienthi.UseVisualStyleBackColor = true;
            this.ckHienthi.CheckedChanged += new System.EventHandler(this.ckHienthi_CheckedChanged);
            // 
            // txtMatKhaucu
            // 
            this.txtMatKhaucu.Location = new System.Drawing.Point(18, 35);
            this.txtMatKhaucu.Name = "txtMatKhaucu";
            this.txtMatKhaucu.PasswordChar = '*';
            this.txtMatKhaucu.Size = new System.Drawing.Size(292, 20);
            this.txtMatKhaucu.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nhập mật khẩu cũ";
            // 
            // tabLicenseKey
            // 
            this.tabLicenseKey.Controls.Add(this.ckHienLicenseKey);
            this.tabLicenseKey.Controls.Add(this.btnLicenseKey);
            this.tabLicenseKey.Controls.Add(this.txtKey);
            this.tabLicenseKey.Controls.Add(this.label7);
            this.tabLicenseKey.Location = new System.Drawing.Point(4, 22);
            this.tabLicenseKey.Name = "tabLicenseKey";
            this.tabLicenseKey.Size = new System.Drawing.Size(868, 429);
            this.tabLicenseKey.TabIndex = 4;
            this.tabLicenseKey.Text = "Đổi LicenseKey";
            this.tabLicenseKey.UseVisualStyleBackColor = true;
            // 
            // ckHienLicenseKey
            // 
            this.ckHienLicenseKey.AutoSize = true;
            this.ckHienLicenseKey.Location = new System.Drawing.Point(108, 44);
            this.ckHienLicenseKey.Name = "ckHienLicenseKey";
            this.ckHienLicenseKey.Size = new System.Drawing.Size(106, 17);
            this.ckHienLicenseKey.TabIndex = 6;
            this.ckHienLicenseKey.Text = "Hiện LicenseKey";
            this.ckHienLicenseKey.UseVisualStyleBackColor = true;
            this.ckHienLicenseKey.CheckedChanged += new System.EventHandler(this.ckHienLicenseKey_CheckedChanged);
            // 
            // btnLicenseKey
            // 
            this.btnLicenseKey.Location = new System.Drawing.Point(331, 40);
            this.btnLicenseKey.Name = "btnLicenseKey";
            this.btnLicenseKey.Size = new System.Drawing.Size(110, 23);
            this.btnLicenseKey.TabIndex = 5;
            this.btnLicenseKey.Text = "Xác nhận";
            this.btnLicenseKey.UseVisualStyleBackColor = true;
            this.btnLicenseKey.Click += new System.EventHandler(this.btnLicenseKey_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(108, 14);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(333, 20);
            this.txtKey.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Nhập LicenseKey";
            // 
            // ucCaiDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucCaiDat";
            this.Size = new System.Drawing.Size(876, 455);
            this.tabControl1.ResumeLayout(false);
            this.tabChrome.ResumeLayout(false);
            this.tabChrome.PerformLayout();
            this.tabCauHinh.ResumeLayout(false);
            this.tabCauHinh.PerformLayout();
            this.tabSql.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblShow)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabLicenseKey.ResumeLayout(false);
            this.tabLicenseKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChrome;
        private System.Windows.Forms.Button btnChonThuMuc;
        private System.Windows.Forms.TextBox txtChromeProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChonFileChrome;
        private System.Windows.Forms.TextBox txtChromePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabCauHinh;
        private System.Windows.Forms.Button btnTatchedoluuthongsomacdinh;
        private System.Windows.Forms.Button btnLuuthongso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabSql;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tblShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTruyVan;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox ckHienthi;
        private System.Windows.Forms.TextBox txtMatKhaucu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.TextBox txtNhaplaimatkhau;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMatkhaumoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckDungChromeMacDinh;
        private System.Windows.Forms.TabPage tabLicenseKey;
        private System.Windows.Forms.Button btnLicenseKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckHienLicenseKey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}
