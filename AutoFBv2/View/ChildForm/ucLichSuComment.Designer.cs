
namespace AutoFB.View.ChildForm
{
    partial class ucLichSuComment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckTichBo = new System.Windows.Forms.CheckBox();
            this.btnXoalichsu = new System.Windows.Forms.Button();
            this.cboLoaiPost = new System.Windows.Forms.ComboBox();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvComment = new System.Windows.Forms.DataGridView();
            this.ROWNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHON = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FB_POST_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOIDUNG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HINHANH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN_PROFILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THOIGIAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIADIEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FB_COMMENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINKREP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckTichBo);
            this.panel1.Controls.Add(this.btnXoalichsu);
            this.panel1.Controls.Add(this.cboLoaiPost);
            this.panel1.Controls.Add(this.btnTimkiem);
            this.panel1.Controls.Add(this.txtTimkiem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 44);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ckTichBo
            // 
            this.ckTichBo.AutoSize = true;
            this.ckTichBo.Location = new System.Drawing.Point(617, 13);
            this.ckTichBo.Name = "ckTichBo";
            this.ckTichBo.Size = new System.Drawing.Size(66, 17);
            this.ckTichBo.TabIndex = 4;
            this.ckTichBo.Text = "Tích/bỏ";
            this.ckTichBo.UseVisualStyleBackColor = true;
            this.ckTichBo.CheckedChanged += new System.EventHandler(this.ckTichBo_CheckedChanged);
            // 
            // btnXoalichsu
            // 
            this.btnXoalichsu.Location = new System.Drawing.Point(703, 9);
            this.btnXoalichsu.Name = "btnXoalichsu";
            this.btnXoalichsu.Size = new System.Drawing.Size(170, 23);
            this.btnXoalichsu.TabIndex = 3;
            this.btnXoalichsu.Text = "Xóa lich sử comment";
            this.btnXoalichsu.UseVisualStyleBackColor = true;
            this.btnXoalichsu.Click += new System.EventHandler(this.btnXoalichsu_Click);
            // 
            // cboLoaiPost
            // 
            this.cboLoaiPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPost.FormattingEnabled = true;
            this.cboLoaiPost.Items.AddRange(new object[] {
            "Tất cả",
            "Ngẫu nhiên Newfeed",
            "Trang/Nhóm/Người",
            "Rep Comment"});
            this.cboLoaiPost.Location = new System.Drawing.Point(303, 11);
            this.cboLoaiPost.Name = "cboLoaiPost";
            this.cboLoaiPost.Size = new System.Drawing.Size(121, 21);
            this.cboLoaiPost.TabIndex = 2;
            this.cboLoaiPost.SelectedIndexChanged += new System.EventHandler(this.cboLoaiPost_SelectedIndexChanged);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Location = new System.Drawing.Point(430, 9);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimkiem.TabIndex = 1;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Location = new System.Drawing.Point(14, 11);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(282, 20);
            this.txtTimkiem.TabIndex = 0;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvComment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 411);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dgvComment
            // 
            this.dgvComment.AllowUserToAddRows = false;
            this.dgvComment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROWNUMBER,
            this.CHON,
            this.FB_POST_ID,
            this.NOIDUNG,
            this.HINHANH,
            this.TEN_PROFILE,
            this.THOIGIAN,
            this.DIADIEM,
            this.FB_COMMENT_ID,
            this.LOAI,
            this.LINKREP,
            this.ID});
            this.dgvComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComment.Location = new System.Drawing.Point(0, 0);
            this.dgvComment.Name = "dgvComment";
            this.dgvComment.RowHeadersVisible = false;
            this.dgvComment.Size = new System.Drawing.Size(876, 411);
            this.dgvComment.TabIndex = 0;
            this.dgvComment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComment_CellContentClick);
            // 
            // ROWNUMBER
            // 
            this.ROWNUMBER.HeaderText = "STT";
            this.ROWNUMBER.Name = "ROWNUMBER";
            this.ROWNUMBER.ReadOnly = true;
            this.ROWNUMBER.Width = 60;
            // 
            // CHON
            // 
            this.CHON.HeaderText = "Chọn";
            this.CHON.Name = "CHON";
            this.CHON.Width = 50;
            // 
            // FB_POST_ID
            // 
            this.FB_POST_ID.HeaderText = "Post ID";
            this.FB_POST_ID.Name = "FB_POST_ID";
            this.FB_POST_ID.ReadOnly = true;
            // 
            // NOIDUNG
            // 
            this.NOIDUNG.HeaderText = "Nội dung";
            this.NOIDUNG.Name = "NOIDUNG";
            this.NOIDUNG.ReadOnly = true;
            // 
            // HINHANH
            // 
            this.HINHANH.HeaderText = "Hình ảnh";
            this.HINHANH.Name = "HINHANH";
            this.HINHANH.ReadOnly = true;
            // 
            // TEN_PROFILE
            // 
            this.TEN_PROFILE.HeaderText = "Tên Profile";
            this.TEN_PROFILE.Name = "TEN_PROFILE";
            this.TEN_PROFILE.ReadOnly = true;
            // 
            // THOIGIAN
            // 
            this.THOIGIAN.HeaderText = "Thời gian";
            this.THOIGIAN.Name = "THOIGIAN";
            this.THOIGIAN.ReadOnly = true;
            // 
            // DIADIEM
            // 
            this.DIADIEM.HeaderText = "Địa điểm";
            this.DIADIEM.Name = "DIADIEM";
            this.DIADIEM.ReadOnly = true;
            // 
            // FB_COMMENT_ID
            // 
            this.FB_COMMENT_ID.HeaderText = "Comment ID";
            this.FB_COMMENT_ID.Name = "FB_COMMENT_ID";
            this.FB_COMMENT_ID.ReadOnly = true;
            // 
            // LOAI
            // 
            this.LOAI.HeaderText = "Loại";
            this.LOAI.Name = "LOAI";
            this.LOAI.ReadOnly = true;
            // 
            // LINKREP
            // 
            this.LINKREP.HeaderText = "Link Rep";
            this.LINKREP.Name = "LINKREP";
            this.LINKREP.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ucLichSuComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucLichSuComment";
            this.Size = new System.Drawing.Size(876, 455);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXoalichsu;
        private System.Windows.Forms.ComboBox cboLoaiPost;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvComment;
        private System.Windows.Forms.CheckBox ckTichBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROWNUMBER;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHON;
        private System.Windows.Forms.DataGridViewTextBoxColumn FB_POST_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOIDUNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HINHANH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEN_PROFILE;
        private System.Windows.Forms.DataGridViewTextBoxColumn THOIGIAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIADIEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn FB_COMMENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn LINKREP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}
