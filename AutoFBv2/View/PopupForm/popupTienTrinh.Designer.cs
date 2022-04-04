
namespace AutoFB.View.PopupForm
{
    partial class popupTienTrinh
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTientrinh = new System.Windows.Forms.TabPage();
            this.dgvTientrinh = new System.Windows.Forms.DataGridView();
            this.tabLuong = new System.Windows.Forms.TabPage();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.L_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L_TEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L_DANGCHAY = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.T_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_DUNG = new System.Windows.Forms.DataGridViewButtonColumn();
            this.T_TEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T_ISALLOW = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.T_LOAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T_THOIGIAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabTientrinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTientrinh)).BeginInit();
            this.tabLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTientrinh);
            this.tabControl1.Controls.Add(this.tabLuong);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(591, 349);
            this.tabControl1.TabIndex = 0;
            // 
            // tabTientrinh
            // 
            this.tabTientrinh.Controls.Add(this.dgvTientrinh);
            this.tabTientrinh.Location = new System.Drawing.Point(4, 22);
            this.tabTientrinh.Name = "tabTientrinh";
            this.tabTientrinh.Padding = new System.Windows.Forms.Padding(3);
            this.tabTientrinh.Size = new System.Drawing.Size(583, 323);
            this.tabTientrinh.TabIndex = 0;
            this.tabTientrinh.Text = "Tiến trình";
            this.tabTientrinh.UseVisualStyleBackColor = true;
            // 
            // dgvTientrinh
            // 
            this.dgvTientrinh.AllowUserToAddRows = false;
            this.dgvTientrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTientrinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.T_STT,
            this.BTN_DUNG,
            this.T_TEN,
            this.T_ISALLOW,
            this.T_LOAI,
            this.GhiChu,
            this.T_THOIGIAN});
            this.dgvTientrinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTientrinh.Location = new System.Drawing.Point(3, 3);
            this.dgvTientrinh.Name = "dgvTientrinh";
            this.dgvTientrinh.RowHeadersVisible = false;
            this.dgvTientrinh.Size = new System.Drawing.Size(577, 317);
            this.dgvTientrinh.TabIndex = 0;
            this.dgvTientrinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTientrinh_CellClick);
            // 
            // tabLuong
            // 
            this.tabLuong.Controls.Add(this.dgvLuong);
            this.tabLuong.Location = new System.Drawing.Point(4, 22);
            this.tabLuong.Name = "tabLuong";
            this.tabLuong.Padding = new System.Windows.Forms.Padding(3);
            this.tabLuong.Size = new System.Drawing.Size(583, 323);
            this.tabLuong.TabIndex = 1;
            this.tabLuong.Text = "Luồng";
            this.tabLuong.UseVisualStyleBackColor = true;
            // 
            // dgvLuong
            // 
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.L_STT,
            this.L_TEN,
            this.L_DANGCHAY});
            this.dgvLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLuong.Location = new System.Drawing.Point(3, 3);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.RowHeadersVisible = false;
            this.dgvLuong.Size = new System.Drawing.Size(577, 317);
            this.dgvLuong.TabIndex = 1;
            // 
            // L_STT
            // 
            this.L_STT.HeaderText = "STT";
            this.L_STT.Name = "L_STT";
            this.L_STT.ReadOnly = true;
            this.L_STT.Width = 50;
            // 
            // L_TEN
            // 
            this.L_TEN.HeaderText = "Tên";
            this.L_TEN.Name = "L_TEN";
            this.L_TEN.ReadOnly = true;
            this.L_TEN.Width = 150;
            // 
            // L_DANGCHAY
            // 
            this.L_DANGCHAY.HeaderText = "Đang chạy";
            this.L_DANGCHAY.Name = "L_DANGCHAY";
            this.L_DANGCHAY.ReadOnly = true;
            this.L_DANGCHAY.Width = 80;
            // 
            // T_STT
            // 
            this.T_STT.HeaderText = "STT";
            this.T_STT.Name = "T_STT";
            this.T_STT.ReadOnly = true;
            this.T_STT.Width = 40;
            // 
            // BTN_DUNG
            // 
            this.BTN_DUNG.HeaderText = "Dừng";
            this.BTN_DUNG.Name = "BTN_DUNG";
            this.BTN_DUNG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BTN_DUNG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BTN_DUNG.Text = "Dừng";
            this.BTN_DUNG.Width = 40;
            // 
            // T_TEN
            // 
            this.T_TEN.HeaderText = "Profile";
            this.T_TEN.Name = "T_TEN";
            this.T_TEN.ReadOnly = true;
            this.T_TEN.Width = 150;
            // 
            // T_ISALLOW
            // 
            this.T_ISALLOW.HeaderText = "Đang chạy";
            this.T_ISALLOW.Name = "T_ISALLOW";
            this.T_ISALLOW.ReadOnly = true;
            this.T_ISALLOW.Width = 80;
            // 
            // T_LOAI
            // 
            this.T_LOAI.HeaderText = "Loại tiến trình";
            this.T_LOAI.Name = "T_LOAI";
            this.T_LOAI.ReadOnly = true;
            this.T_LOAI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.T_LOAI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.T_LOAI.Width = 80;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 200;
            // 
            // T_THOIGIAN
            // 
            this.T_THOIGIAN.HeaderText = "Đã tạo";
            this.T_THOIGIAN.Name = "T_THOIGIAN";
            this.T_THOIGIAN.ReadOnly = true;
            this.T_THOIGIAN.Width = 130;
            // 
            // popupTienTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(591, 349);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "popupTienTrinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tiến trình/Luồng";
            this.Load += new System.EventHandler(this.popupTienTrinh_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabTientrinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTientrinh)).EndInit();
            this.tabLuong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTientrinh;
        private System.Windows.Forms.DataGridView dgvTientrinh;
        private System.Windows.Forms.TabPage tabLuong;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn L_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn L_TEN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn L_DANGCHAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn T_STT;
        private System.Windows.Forms.DataGridViewButtonColumn BTN_DUNG;
        private System.Windows.Forms.DataGridViewTextBoxColumn T_TEN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn T_ISALLOW;
        private System.Windows.Forms.DataGridViewTextBoxColumn T_LOAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn T_THOIGIAN;
    }
}