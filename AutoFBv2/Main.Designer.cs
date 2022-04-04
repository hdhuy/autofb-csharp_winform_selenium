
namespace AutoFB
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pnlTOP = new System.Windows.Forms.Panel();
            this.btnDonDriver = new System.Windows.Forms.Button();
            this.btnDungTatCaTienTrinh = new System.Windows.Forms.Button();
            this.btnXemtientrinh = new System.Windows.Forms.Button();
            this.pnlCONTENT = new System.Windows.Forms.Panel();
            this.myTabPage = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.tabCopyPost = new System.Windows.Forms.TabPage();
            this.tabAutoPost = new System.Windows.Forms.TabPage();
            this.tabAutoPostOnly = new System.Windows.Forms.TabPage();
            this.tabAutoComment = new System.Windows.Forms.TabPage();
            this.tabComment = new System.Windows.Forms.TabPage();
            this.tabThongbao = new System.Windows.Forms.TabPage();
            this.tabCaiDat = new System.Windows.Forms.TabPage();
            this.ProfileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTOP.SuspendLayout();
            this.pnlCONTENT.SuspendLayout();
            this.myTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTOP
            // 
            this.pnlTOP.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlTOP.Controls.Add(this.btnDonDriver);
            this.pnlTOP.Controls.Add(this.btnDungTatCaTienTrinh);
            this.pnlTOP.Controls.Add(this.btnXemtientrinh);
            this.pnlTOP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTOP.Location = new System.Drawing.Point(0, 0);
            this.pnlTOP.Name = "pnlTOP";
            this.pnlTOP.Size = new System.Drawing.Size(884, 30);
            this.pnlTOP.TabIndex = 0;
            // 
            // btnDonDriver
            // 
            this.btnDonDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDonDriver.Location = new System.Drawing.Point(479, 4);
            this.btnDonDriver.Name = "btnDonDriver";
            this.btnDonDriver.Size = new System.Drawing.Size(206, 23);
            this.btnDonDriver.TabIndex = 4;
            this.btnDonDriver.Text = "Dọn chromedriver.exe (Task Manager)";
            this.btnDonDriver.UseVisualStyleBackColor = true;
            this.btnDonDriver.Click += new System.EventHandler(this.btnDonDriver_Click);
            // 
            // btnDungTatCaTienTrinh
            // 
            this.btnDungTatCaTienTrinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDungTatCaTienTrinh.Location = new System.Drawing.Point(328, 4);
            this.btnDungTatCaTienTrinh.Name = "btnDungTatCaTienTrinh";
            this.btnDungTatCaTienTrinh.Size = new System.Drawing.Size(145, 23);
            this.btnDungTatCaTienTrinh.TabIndex = 3;
            this.btnDungTatCaTienTrinh.Text = "Dừng tất cả tiến trình";
            this.btnDungTatCaTienTrinh.UseVisualStyleBackColor = true;
            this.btnDungTatCaTienTrinh.Click += new System.EventHandler(this.btnDungTatCaTienTrinh_Click);
            // 
            // btnXemtientrinh
            // 
            this.btnXemtientrinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemtientrinh.Location = new System.Drawing.Point(691, 4);
            this.btnXemtientrinh.Name = "btnXemtientrinh";
            this.btnXemtientrinh.Size = new System.Drawing.Size(189, 23);
            this.btnXemtientrinh.TabIndex = 1;
            this.btnXemtientrinh.Text = "Theo dõi tiến trình/luồng đang chạy";
            this.btnXemtientrinh.UseVisualStyleBackColor = true;
            this.btnXemtientrinh.Click += new System.EventHandler(this.btnXemtientrinh_Click);
            // 
            // pnlCONTENT
            // 
            this.pnlCONTENT.Controls.Add(this.myTabPage);
            this.pnlCONTENT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCONTENT.Location = new System.Drawing.Point(0, 30);
            this.pnlCONTENT.Name = "pnlCONTENT";
            this.pnlCONTENT.Size = new System.Drawing.Size(884, 481);
            this.pnlCONTENT.TabIndex = 1;
            // 
            // myTabPage
            // 
            this.myTabPage.Controls.Add(this.tabProfile);
            this.myTabPage.Controls.Add(this.tabCopyPost);
            this.myTabPage.Controls.Add(this.tabAutoPost);
            this.myTabPage.Controls.Add(this.tabAutoPostOnly);
            this.myTabPage.Controls.Add(this.tabAutoComment);
            this.myTabPage.Controls.Add(this.tabComment);
            this.myTabPage.Controls.Add(this.tabThongbao);
            this.myTabPage.Controls.Add(this.tabCaiDat);
            this.myTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabPage.Location = new System.Drawing.Point(0, 0);
            this.myTabPage.Name = "myTabPage";
            this.myTabPage.SelectedIndex = 0;
            this.myTabPage.Size = new System.Drawing.Size(884, 481);
            this.myTabPage.TabIndex = 0;
            // 
            // tabProfile
            // 
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(876, 455);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Quản lý Chrome Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // tabCopyPost
            // 
            this.tabCopyPost.Location = new System.Drawing.Point(4, 22);
            this.tabCopyPost.Name = "tabCopyPost";
            this.tabCopyPost.Padding = new System.Windows.Forms.Padding(3);
            this.tabCopyPost.Size = new System.Drawing.Size(876, 455);
            this.tabCopyPost.TabIndex = 1;
            this.tabCopyPost.Text = "Sao chép bài viết";
            this.tabCopyPost.UseVisualStyleBackColor = true;
            // 
            // tabAutoPost
            // 
            this.tabAutoPost.Location = new System.Drawing.Point(4, 22);
            this.tabAutoPost.Name = "tabAutoPost";
            this.tabAutoPost.Size = new System.Drawing.Size(876, 455);
            this.tabAutoPost.TabIndex = 2;
            this.tabAutoPost.Text = "Tự động đăng bài";
            this.tabAutoPost.UseVisualStyleBackColor = true;
            // 
            // tabAutoPostOnly
            // 
            this.tabAutoPostOnly.Location = new System.Drawing.Point(4, 22);
            this.tabAutoPostOnly.Name = "tabAutoPostOnly";
            this.tabAutoPostOnly.Size = new System.Drawing.Size(876, 455);
            this.tabAutoPostOnly.TabIndex = 7;
            this.tabAutoPostOnly.Text = "Tự động đăng bài (chi tiết hơn)";
            this.tabAutoPostOnly.UseVisualStyleBackColor = true;
            // 
            // tabAutoComment
            // 
            this.tabAutoComment.Location = new System.Drawing.Point(4, 22);
            this.tabAutoComment.Name = "tabAutoComment";
            this.tabAutoComment.Size = new System.Drawing.Size(876, 455);
            this.tabAutoComment.TabIndex = 3;
            this.tabAutoComment.Text = "Tự động bình luận";
            this.tabAutoComment.UseVisualStyleBackColor = true;
            // 
            // tabComment
            // 
            this.tabComment.Location = new System.Drawing.Point(4, 22);
            this.tabComment.Name = "tabComment";
            this.tabComment.Size = new System.Drawing.Size(876, 455);
            this.tabComment.TabIndex = 4;
            this.tabComment.Text = "Lịch sử bình luận";
            this.tabComment.UseVisualStyleBackColor = true;
            // 
            // tabThongbao
            // 
            this.tabThongbao.Location = new System.Drawing.Point(4, 22);
            this.tabThongbao.Name = "tabThongbao";
            this.tabThongbao.Size = new System.Drawing.Size(876, 455);
            this.tabThongbao.TabIndex = 5;
            this.tabThongbao.Text = "Thông báo";
            this.tabThongbao.UseVisualStyleBackColor = true;
            // 
            // tabCaiDat
            // 
            this.tabCaiDat.Location = new System.Drawing.Point(4, 22);
            this.tabCaiDat.Name = "tabCaiDat";
            this.tabCaiDat.Size = new System.Drawing.Size(876, 455);
            this.tabCaiDat.TabIndex = 6;
            this.tabCaiDat.Text = "Cài đặt";
            this.tabCaiDat.UseVisualStyleBackColor = true;
            // 
            // ProfileBindingSource
            // 
            this.ProfileBindingSource.DataSource = typeof(AutoFB.Model.PROFILE);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.pnlCONTENT);
            this.Controls.Add(this.pnlTOP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm AutoFB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnlTOP.ResumeLayout(false);
            this.pnlCONTENT.ResumeLayout(false);
            this.myTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTOP;
        private System.Windows.Forms.Button btnXemtientrinh;
        private System.Windows.Forms.Button btnDungTatCaTienTrinh;
        private System.Windows.Forms.Panel pnlCONTENT;
        private System.Windows.Forms.TabControl myTabPage;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabCopyPost;
        private System.Windows.Forms.TabPage tabAutoPost;
        private System.Windows.Forms.TabPage tabAutoComment;
        private System.Windows.Forms.TabPage tabComment;
        private System.Windows.Forms.TabPage tabThongbao;
        private System.Windows.Forms.TabPage tabCaiDat;
        private System.Windows.Forms.Button btnDonDriver;
        private System.Windows.Forms.TabPage tabAutoPostOnly;
        public System.Windows.Forms.BindingSource ProfileBindingSource;
    }
}

