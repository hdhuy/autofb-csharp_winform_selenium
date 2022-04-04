
namespace AutoFB.View.PopupForm
{
    partial class popupDangNhap
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
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.ckHienthi = new System.Windows.Forms.CheckBox();
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTendangnhap = new System.Windows.Forms.TextBox();
            this.ckHienthongtinthietbi = new System.Windows.Forms.CheckBox();
            this.pnlThietbi = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltitthietbi = new System.Windows.Forms.Label();
            this.lblDiachimac = new System.Windows.Forms.Label();
            this.lblTenthietbi = new System.Windows.Forms.Label();
            this.ckTudongluu = new System.Windows.Forms.CheckBox();
            this.pnlThietbi.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(16, 79);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(292, 20);
            this.txtMatKhau.TabIndex = 2;
            // 
            // ckHienthi
            // 
            this.ckHienthi.AutoSize = true;
            this.ckHienthi.Location = new System.Drawing.Point(16, 105);
            this.ckHienthi.Name = "ckHienthi";
            this.ckHienthi.Size = new System.Drawing.Size(109, 17);
            this.ckHienthi.TabIndex = 10;
            this.ckHienthi.Text = "Hiển thị mật khẩu";
            this.ckHienthi.UseVisualStyleBackColor = true;
            this.ckHienthi.CheckedChanged += new System.EventHandler(this.ckHienthi_CheckedChanged);
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.Location = new System.Drawing.Point(16, 141);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(292, 33);
            this.btnDangnhap.TabIndex = 3;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = true;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhập số điện thoại/email";
            // 
            // txtTendangnhap
            // 
            this.txtTendangnhap.Location = new System.Drawing.Point(16, 30);
            this.txtTendangnhap.Name = "txtTendangnhap";
            this.txtTendangnhap.Size = new System.Drawing.Size(292, 20);
            this.txtTendangnhap.TabIndex = 1;
            // 
            // ckHienthongtinthietbi
            // 
            this.ckHienthongtinthietbi.AutoSize = true;
            this.ckHienthongtinthietbi.Location = new System.Drawing.Point(16, 203);
            this.ckHienthongtinthietbi.Name = "ckHienthongtinthietbi";
            this.ckHienthongtinthietbi.Size = new System.Drawing.Size(140, 17);
            this.ckHienthongtinthietbi.TabIndex = 6;
            this.ckHienthongtinthietbi.Text = "Hiển thị thông tin thiết bị";
            this.ckHienthongtinthietbi.UseVisualStyleBackColor = true;
            this.ckHienthongtinthietbi.CheckedChanged += new System.EventHandler(this.ckHienthongtinthietbi_CheckedChanged);
            // 
            // pnlThietbi
            // 
            this.pnlThietbi.Controls.Add(this.label3);
            this.pnlThietbi.Controls.Add(this.lbltitthietbi);
            this.pnlThietbi.Controls.Add(this.lblDiachimac);
            this.pnlThietbi.Controls.Add(this.lblTenthietbi);
            this.pnlThietbi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThietbi.Location = new System.Drawing.Point(0, 224);
            this.pnlThietbi.Name = "pnlThietbi";
            this.pnlThietbi.Size = new System.Drawing.Size(323, 44);
            this.pnlThietbi.TabIndex = 9;
            this.pnlThietbi.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Địa chỉ mac";
            // 
            // lbltitthietbi
            // 
            this.lbltitthietbi.AutoSize = true;
            this.lbltitthietbi.Location = new System.Drawing.Point(13, 5);
            this.lbltitthietbi.Name = "lbltitthietbi";
            this.lbltitthietbi.Size = new System.Drawing.Size(60, 13);
            this.lbltitthietbi.TabIndex = 13;
            this.lbltitthietbi.Text = "Tên thiết bị";
            // 
            // lblDiachimac
            // 
            this.lblDiachimac.AutoSize = true;
            this.lblDiachimac.Location = new System.Drawing.Point(79, 24);
            this.lblDiachimac.Name = "lblDiachimac";
            this.lblDiachimac.Size = new System.Drawing.Size(63, 13);
            this.lblDiachimac.TabIndex = 12;
            this.lblDiachimac.Text = "Địa chỉ mac";
            // 
            // lblTenthietbi
            // 
            this.lblTenthietbi.AutoSize = true;
            this.lblTenthietbi.Location = new System.Drawing.Point(79, 5);
            this.lblTenthietbi.Name = "lblTenthietbi";
            this.lblTenthietbi.Size = new System.Drawing.Size(60, 13);
            this.lblTenthietbi.TabIndex = 11;
            this.lblTenthietbi.Text = "Tên thiết bị";
            // 
            // ckTudongluu
            // 
            this.ckTudongluu.AutoSize = true;
            this.ckTudongluu.Checked = true;
            this.ckTudongluu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTudongluu.Location = new System.Drawing.Point(16, 180);
            this.ckTudongluu.Name = "ckTudongluu";
            this.ckTudongluu.Size = new System.Drawing.Size(183, 17);
            this.ckTudongluu.TabIndex = 5;
            this.ckTudongluu.Text = "Tự động lưu thông tin đăng nhập";
            this.ckTudongluu.UseVisualStyleBackColor = true;
            // 
            // popupDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 268);
            this.Controls.Add(this.ckTudongluu);
            this.Controls.Add(this.pnlThietbi);
            this.Controls.Add(this.ckHienthongtinthietbi);
            this.Controls.Add(this.txtTendangnhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDangnhap);
            this.Controls.Add(this.ckHienthi);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "popupDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin đăng nhập";
            this.pnlThietbi.ResumeLayout(false);
            this.pnlThietbi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox ckHienthi;
        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTendangnhap;
        private System.Windows.Forms.CheckBox ckHienthongtinthietbi;
        private System.Windows.Forms.Panel pnlThietbi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbltitthietbi;
        private System.Windows.Forms.Label lblDiachimac;
        private System.Windows.Forms.Label lblTenthietbi;
        private System.Windows.Forms.CheckBox ckTudongluu;
    }
}