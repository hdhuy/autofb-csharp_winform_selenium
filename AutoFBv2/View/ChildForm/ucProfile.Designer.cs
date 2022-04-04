
namespace AutoFB.View.ChildForm
{
    partial class ucProfile
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
            this.pnlTOP = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.nbThoiGianNghi = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnXoaNhieuProfileDaChon = new System.Windows.Forms.Button();
            this.ckTichBo = new System.Windows.Forms.CheckBox();
            this.btnLoadLaiDuLieu = new System.Windows.Forms.Button();
            this.ckHienmatkhau = new System.Windows.Forms.CheckBox();
            this.btntuDongDangNhap = new System.Windows.Forms.Button();
            this.btnMoProfile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXoaProfile = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThemProfile = new System.Windows.Forms.Button();
            this.txtUidPage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUidProfile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenProfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCONTENT = new System.Windows.Forms.Panel();
            this.dgvContent = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ROWNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHON = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UID_PAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATKHAU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANGTHAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTOP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbThoiGianNghi)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlCONTENT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTOP
            // 
            this.pnlTOP.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlTOP.Controls.Add(this.label7);
            this.pnlTOP.Controls.Add(this.nbThoiGianNghi);
            this.pnlTOP.Controls.Add(this.label6);
            this.pnlTOP.Controls.Add(this.button2);
            this.pnlTOP.Controls.Add(this.btnXoaNhieuProfileDaChon);
            this.pnlTOP.Controls.Add(this.ckTichBo);
            this.pnlTOP.Controls.Add(this.btnLoadLaiDuLieu);
            this.pnlTOP.Controls.Add(this.ckHienmatkhau);
            this.pnlTOP.Controls.Add(this.btntuDongDangNhap);
            this.pnlTOP.Controls.Add(this.btnMoProfile);
            this.pnlTOP.Controls.Add(this.panel1);
            this.pnlTOP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTOP.Location = new System.Drawing.Point(0, 0);
            this.pnlTOP.Name = "pnlTOP";
            this.pnlTOP.Size = new System.Drawing.Size(876, 88);
            this.pnlTOP.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(819, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "giây";
            // 
            // nbThoiGianNghi
            // 
            this.nbThoiGianNghi.Location = new System.Drawing.Point(755, 57);
            this.nbThoiGianNghi.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbThoiGianNghi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbThoiGianNghi.Name = "nbThoiGianNghi";
            this.nbThoiGianNghi.Size = new System.Drawing.Size(61, 20);
            this.nbThoiGianNghi.TabIndex = 15;
            this.nbThoiGianNghi.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Thời gian nghỉ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(807, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Lưu ý !";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnXoaNhieuProfileDaChon
            // 
            this.btnXoaNhieuProfileDaChon.Location = new System.Drawing.Point(635, 28);
            this.btnXoaNhieuProfileDaChon.Name = "btnXoaNhieuProfileDaChon";
            this.btnXoaNhieuProfileDaChon.Size = new System.Drawing.Size(166, 23);
            this.btnXoaNhieuProfileDaChon.TabIndex = 12;
            this.btnXoaNhieuProfileDaChon.Text = "XÓA nhiều Profile đã chọn";
            this.btnXoaNhieuProfileDaChon.UseVisualStyleBackColor = true;
            this.btnXoaNhieuProfileDaChon.Click += new System.EventHandler(this.btnXoaNhieuProfileDaChon_Click);
            // 
            // ckTichBo
            // 
            this.ckTichBo.AutoSize = true;
            this.ckTichBo.Location = new System.Drawing.Point(582, 60);
            this.ckTichBo.Name = "ckTichBo";
            this.ckTichBo.Size = new System.Drawing.Size(66, 17);
            this.ckTichBo.TabIndex = 11;
            this.ckTichBo.Text = "Tích/bỏ";
            this.ckTichBo.UseVisualStyleBackColor = true;
            this.ckTichBo.CheckedChanged += new System.EventHandler(this.ckTichBo_CheckedChanged);
            // 
            // btnLoadLaiDuLieu
            // 
            this.btnLoadLaiDuLieu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLoadLaiDuLieu.FlatAppearance.BorderSize = 0;
            this.btnLoadLaiDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoadLaiDuLieu.Location = new System.Drawing.Point(635, 4);
            this.btnLoadLaiDuLieu.Name = "btnLoadLaiDuLieu";
            this.btnLoadLaiDuLieu.Size = new System.Drawing.Size(166, 23);
            this.btnLoadLaiDuLieu.TabIndex = 4;
            this.btnLoadLaiDuLieu.Text = "Load lại dữ liệu";
            this.btnLoadLaiDuLieu.UseVisualStyleBackColor = false;
            this.btnLoadLaiDuLieu.Click += new System.EventHandler(this.btnLoadLaiDuLieu_Click);
            // 
            // ckHienmatkhau
            // 
            this.ckHienmatkhau.AutoSize = true;
            this.ckHienmatkhau.Location = new System.Drawing.Point(463, 60);
            this.ckHienmatkhau.Name = "ckHienmatkhau";
            this.ckHienmatkhau.Size = new System.Drawing.Size(95, 17);
            this.ckHienmatkhau.TabIndex = 3;
            this.ckHienmatkhau.Text = "Hiện mật khẩu";
            this.ckHienmatkhau.UseVisualStyleBackColor = true;
            this.ckHienmatkhau.CheckedChanged += new System.EventHandler(this.ckHienmatkhau_CheckedChanged);
            // 
            // btntuDongDangNhap
            // 
            this.btntuDongDangNhap.Location = new System.Drawing.Point(463, 4);
            this.btntuDongDangNhap.Name = "btntuDongDangNhap";
            this.btntuDongDangNhap.Size = new System.Drawing.Size(166, 23);
            this.btntuDongDangNhap.TabIndex = 2;
            this.btntuDongDangNhap.Text = "Tự động đăng nhập cho Profile";
            this.btntuDongDangNhap.UseVisualStyleBackColor = true;
            this.btntuDongDangNhap.Click += new System.EventHandler(this.btntuDongDangNhap_Click);
            // 
            // btnMoProfile
            // 
            this.btnMoProfile.Location = new System.Drawing.Point(463, 28);
            this.btnMoProfile.Name = "btnMoProfile";
            this.btnMoProfile.Size = new System.Drawing.Size(166, 23);
            this.btnMoProfile.TabIndex = 1;
            this.btnMoProfile.Text = "MỞ các Profile đã chọn";
            this.btnMoProfile.UseVisualStyleBackColor = true;
            this.btnMoProfile.Click += new System.EventHandler(this.btnMoProfile_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMatKhau);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnXoaProfile);
            this.panel1.Controls.Add(this.btnCapNhat);
            this.panel1.Controls.Add(this.btnThemProfile);
            this.panel1.Controls.Add(this.txtUidPage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtUidProfile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTenProfile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 88);
            this.panel1.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(69, 30);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(142, 20);
            this.txtMatKhau.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mật khẩu";
            // 
            // btnXoaProfile
            // 
            this.btnXoaProfile.Location = new System.Drawing.Point(237, 54);
            this.btnXoaProfile.Name = "btnXoaProfile";
            this.btnXoaProfile.Size = new System.Drawing.Size(57, 23);
            this.btnXoaProfile.TabIndex = 10;
            this.btnXoaProfile.Text = "Xóa";
            this.btnXoaProfile.UseVisualStyleBackColor = true;
            this.btnXoaProfile.Click += new System.EventHandler(this.btnXoaProfile_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(300, 54);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(74, 23);
            this.btnCapNhat.TabIndex = 9;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThemProfile
            // 
            this.btnThemProfile.Location = new System.Drawing.Point(380, 54);
            this.btnThemProfile.Name = "btnThemProfile";
            this.btnThemProfile.Size = new System.Drawing.Size(72, 23);
            this.btnThemProfile.TabIndex = 8;
            this.btnThemProfile.Text = "Thêm mới";
            this.btnThemProfile.UseVisualStyleBackColor = true;
            this.btnThemProfile.Click += new System.EventHandler(this.btnThemProfile_Click);
            // 
            // txtUidPage
            // 
            this.txtUidPage.Location = new System.Drawing.Point(300, 30);
            this.txtUidPage.Name = "txtUidPage";
            this.txtUidPage.Size = new System.Drawing.Size(152, 20);
            this.txtUidPage.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Uid Comment";
            // 
            // txtUidProfile
            // 
            this.txtUidProfile.Location = new System.Drawing.Point(300, 4);
            this.txtUidProfile.Name = "txtUidProfile";
            this.txtUidProfile.Size = new System.Drawing.Size(152, 20);
            this.txtUidProfile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Uid Đăng nhập";
            // 
            // txtTenProfile
            // 
            this.txtTenProfile.Location = new System.Drawing.Point(69, 4);
            this.txtTenProfile.Name = "txtTenProfile";
            this.txtTenProfile.Size = new System.Drawing.Size(142, 20);
            this.txtTenProfile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Profile";
            // 
            // pnlCONTENT
            // 
            this.pnlCONTENT.Controls.Add(this.dgvContent);
            this.pnlCONTENT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCONTENT.Location = new System.Drawing.Point(0, 88);
            this.pnlCONTENT.Name = "pnlCONTENT";
            this.pnlCONTENT.Size = new System.Drawing.Size(876, 367);
            this.pnlCONTENT.TabIndex = 1;
            // 
            // dgvContent
            // 
            this.dgvContent.AllowUserToAddRows = false;
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROWNUMBER,
            this.CHON,
            this.ID,
            this.TEN,
            this.UID,
            this.UID_PAGE,
            this.MATKHAU,
            this.TRANGTHAI});
            this.dgvContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContent.Location = new System.Drawing.Point(0, 0);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.RowHeadersVisible = false;
            this.dgvContent.Size = new System.Drawing.Size(876, 367);
            this.dgvContent.TabIndex = 0;
            this.dgvContent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContent_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(3, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Lưu ý: Uid Comment có thể là uid đăng nhập";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(3, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Hoặc Uid trang mà user sở hữu";
            // 
            // ROWNUMBER
            // 
            this.ROWNUMBER.HeaderText = "STT";
            this.ROWNUMBER.Name = "ROWNUMBER";
            this.ROWNUMBER.ReadOnly = true;
            this.ROWNUMBER.Width = 50;
            // 
            // CHON
            // 
            this.CHON.HeaderText = "Chọn";
            this.CHON.Name = "CHON";
            this.CHON.Width = 50;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 20;
            // 
            // TEN
            // 
            this.TEN.HeaderText = "Tên Chrome Profile";
            this.TEN.Name = "TEN";
            this.TEN.ReadOnly = true;
            this.TEN.Width = 130;
            // 
            // UID
            // 
            this.UID.HeaderText = "Uid Đăng nhập";
            this.UID.Name = "UID";
            this.UID.ReadOnly = true;
            this.UID.Width = 130;
            // 
            // UID_PAGE
            // 
            this.UID_PAGE.HeaderText = "UId Comment";
            this.UID_PAGE.Name = "UID_PAGE";
            this.UID_PAGE.ReadOnly = true;
            this.UID_PAGE.Width = 130;
            // 
            // MATKHAU
            // 
            this.MATKHAU.HeaderText = "Mật khẩu";
            this.MATKHAU.Name = "MATKHAU";
            this.MATKHAU.ReadOnly = true;
            this.MATKHAU.Visible = false;
            // 
            // TRANGTHAI
            // 
            this.TRANGTHAI.HeaderText = "Trạng thái";
            this.TRANGTHAI.Name = "TRANGTHAI";
            this.TRANGTHAI.ReadOnly = true;
            this.TRANGTHAI.Width = 170;
            // 
            // ucProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCONTENT);
            this.Controls.Add(this.pnlTOP);
            this.Name = "ucProfile";
            this.Size = new System.Drawing.Size(876, 455);
            this.Load += new System.EventHandler(this.ucProfile_Load);
            this.pnlTOP.ResumeLayout(false);
            this.pnlTOP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbThoiGianNghi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlCONTENT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTOP;
        private System.Windows.Forms.Panel pnlCONTENT;
        private System.Windows.Forms.DataGridView dgvContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckTichBo;
        private System.Windows.Forms.Button btnXoaProfile;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThemProfile;
        private System.Windows.Forms.TextBox txtUidPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUidProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btntuDongDangNhap;
        private System.Windows.Forms.Button btnMoProfile;
        private System.Windows.Forms.CheckBox ckHienmatkhau;
        private System.Windows.Forms.Button btnLoadLaiDuLieu;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnXoaNhieuProfileDaChon;
        private System.Windows.Forms.NumericUpDown nbThoiGianNghi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROWNUMBER;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHON;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn UID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UID_PAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MATKHAU;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANGTHAI;
    }
}
