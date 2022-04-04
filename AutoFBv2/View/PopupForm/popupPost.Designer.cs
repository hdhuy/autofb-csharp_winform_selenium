
namespace AutoFB.View.PopupForm
{
    partial class popupPost
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnMothumucanh = new System.Windows.Forms.Button();
            this.btnChonthumucanh = new System.Windows.Forms.Button();
            this.txtThumucanh = new System.Windows.Forms.TextBox();
            this.lblThumucluuanh = new System.Windows.Forms.Label();
            this.btnCapnhatNoiDung = new System.Windows.Forms.Button();
            this.btnThemanh = new System.Windows.Forms.Button();
            this.btnThempost = new System.Windows.Forms.Button();
            this.txtNoidung = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgHinhanh = new System.Windows.Forms.DataGridView();
            this.ROWNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SRC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXTENSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MO = new System.Windows.Forms.DataGridViewButtonColumn();
            this.XOA = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHinhanh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnMothumucanh);
            this.panel1.Controls.Add(this.btnChonthumucanh);
            this.panel1.Controls.Add(this.txtThumucanh);
            this.panel1.Controls.Add(this.lblThumucluuanh);
            this.panel1.Controls.Add(this.btnCapnhatNoiDung);
            this.panel1.Controls.Add(this.btnThemanh);
            this.panel1.Controls.Add(this.btnThempost);
            this.panel1.Controls.Add(this.txtNoidung);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 117);
            this.panel1.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(490, 91);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnMothumucanh
            // 
            this.btnMothumucanh.Location = new System.Drawing.Point(435, 91);
            this.btnMothumucanh.Name = "btnMothumucanh";
            this.btnMothumucanh.Size = new System.Drawing.Size(49, 23);
            this.btnMothumucanh.TabIndex = 11;
            this.btnMothumucanh.Text = "Mở";
            this.btnMothumucanh.UseVisualStyleBackColor = true;
            this.btnMothumucanh.Click += new System.EventHandler(this.btnMothumucanh_Click);
            // 
            // btnChonthumucanh
            // 
            this.btnChonthumucanh.Location = new System.Drawing.Point(401, 91);
            this.btnChonthumucanh.Name = "btnChonthumucanh";
            this.btnChonthumucanh.Size = new System.Drawing.Size(28, 23);
            this.btnChonthumucanh.TabIndex = 10;
            this.btnChonthumucanh.Text = "...";
            this.btnChonthumucanh.UseVisualStyleBackColor = true;
            this.btnChonthumucanh.Click += new System.EventHandler(this.btnChonthumucanh_Click);
            // 
            // txtThumucanh
            // 
            this.txtThumucanh.Location = new System.Drawing.Point(99, 93);
            this.txtThumucanh.Name = "txtThumucanh";
            this.txtThumucanh.Size = new System.Drawing.Size(297, 20);
            this.txtThumucanh.TabIndex = 9;
            // 
            // lblThumucluuanh
            // 
            this.lblThumucluuanh.AutoSize = true;
            this.lblThumucluuanh.Location = new System.Drawing.Point(6, 96);
            this.lblThumucluuanh.Name = "lblThumucluuanh";
            this.lblThumucluuanh.Size = new System.Drawing.Size(87, 13);
            this.lblThumucluuanh.TabIndex = 8;
            this.lblThumucluuanh.Text = "Thư mục lưu ảnh";
            // 
            // btnCapnhatNoiDung
            // 
            this.btnCapnhatNoiDung.Location = new System.Drawing.Point(341, 4);
            this.btnCapnhatNoiDung.Name = "btnCapnhatNoiDung";
            this.btnCapnhatNoiDung.Size = new System.Drawing.Size(107, 23);
            this.btnCapnhatNoiDung.TabIndex = 6;
            this.btnCapnhatNoiDung.Text = "Cập nhật";
            this.btnCapnhatNoiDung.UseVisualStyleBackColor = true;
            this.btnCapnhatNoiDung.Click += new System.EventHandler(this.btnCapnhatNoiDungPost_Click);
            // 
            // btnThemanh
            // 
            this.btnThemanh.Location = new System.Drawing.Point(454, 4);
            this.btnThemanh.Name = "btnThemanh";
            this.btnThemanh.Size = new System.Drawing.Size(107, 23);
            this.btnThemanh.TabIndex = 5;
            this.btnThemanh.Text = "Thêm ảnh";
            this.btnThemanh.UseVisualStyleBackColor = true;
            this.btnThemanh.Click += new System.EventHandler(this.btnThemanh_Click);
            // 
            // btnThempost
            // 
            this.btnThempost.Location = new System.Drawing.Point(567, 4);
            this.btnThempost.Name = "btnThempost";
            this.btnThempost.Size = new System.Drawing.Size(107, 23);
            this.btnThempost.TabIndex = 3;
            this.btnThempost.Text = "Thêm post";
            this.btnThempost.UseVisualStyleBackColor = true;
            this.btnThempost.Click += new System.EventHandler(this.btnThempost_Click);
            // 
            // txtNoidung
            // 
            this.txtNoidung.Location = new System.Drawing.Point(6, 33);
            this.txtNoidung.Multiline = true;
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.Size = new System.Drawing.Size(668, 57);
            this.txtNoidung.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nội dung";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgHinhanh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 260);
            this.panel2.TabIndex = 1;
            // 
            // dtgHinhanh
            // 
            this.dtgHinhanh.AllowUserToAddRows = false;
            this.dtgHinhanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHinhanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROWNUMBER,
            this.ID,
            this.SRC,
            this.PATH,
            this.EXTENSION,
            this.MO,
            this.XOA});
            this.dtgHinhanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgHinhanh.Location = new System.Drawing.Point(0, 0);
            this.dtgHinhanh.Name = "dtgHinhanh";
            this.dtgHinhanh.RowHeadersVisible = false;
            this.dtgHinhanh.Size = new System.Drawing.Size(677, 260);
            this.dtgHinhanh.TabIndex = 0;
            this.dtgHinhanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHinhanh_CellClick);
            // 
            // ROWNUMBER
            // 
            this.ROWNUMBER.HeaderText = "STT";
            this.ROWNUMBER.Name = "ROWNUMBER";
            this.ROWNUMBER.ReadOnly = true;
            this.ROWNUMBER.Width = 40;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 40;
            // 
            // SRC
            // 
            this.SRC.HeaderText = "Link";
            this.SRC.Name = "SRC";
            this.SRC.ReadOnly = true;
            this.SRC.Width = 200;
            // 
            // PATH
            // 
            this.PATH.HeaderText = "Path";
            this.PATH.Name = "PATH";
            this.PATH.ReadOnly = true;
            this.PATH.Width = 200;
            // 
            // EXTENSION
            // 
            this.EXTENSION.HeaderText = "Extension";
            this.EXTENSION.Name = "EXTENSION";
            this.EXTENSION.ReadOnly = true;
            // 
            // MO
            // 
            this.MO.HeaderText = "Mở";
            this.MO.Name = "MO";
            this.MO.ReadOnly = true;
            this.MO.Text = "Mở";
            this.MO.Width = 40;
            // 
            // XOA
            // 
            this.XOA.HeaderText = "Xóa";
            this.XOA.Name = "XOA";
            this.XOA.ReadOnly = true;
            this.XOA.Text = "Xóa";
            this.XOA.Width = 40;
            // 
            // popupPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 377);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "popupPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết Post";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHinhanh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCapnhatNoiDung;
        private System.Windows.Forms.Button btnThemanh;
        private System.Windows.Forms.Button btnThempost;
        private System.Windows.Forms.TextBox txtNoidung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgHinhanh;
        private System.Windows.Forms.Label lblThumucluuanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROWNUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SRC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATH;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXTENSION;
        private System.Windows.Forms.DataGridViewButtonColumn MO;
        private System.Windows.Forms.DataGridViewButtonColumn XOA;
        private System.Windows.Forms.Button btnMothumucanh;
        private System.Windows.Forms.Button btnChonthumucanh;
        private System.Windows.Forms.TextBox txtThumucanh;
        private System.Windows.Forms.Button btnReset;
    }
}