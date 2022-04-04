
namespace AutoFB.View.ChildForm
{
    partial class ucThongBao
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
            this.txtLogContent = new System.Windows.Forms.TextBox();
            this.btnXoahetthongbao = new System.Windows.Forms.Button();
            this.ckThongbao = new System.Windows.Forms.CheckBox();
            this.tbListThongbao = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.txtLogContent);
            this.panel1.Controls.Add(this.btnXoahetthongbao);
            this.panel1.Controls.Add(this.ckThongbao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 29);
            this.panel1.TabIndex = 1;
            // 
            // txtLogContent
            // 
            this.txtLogContent.Location = new System.Drawing.Point(409, 4);
            this.txtLogContent.Name = "txtLogContent";
            this.txtLogContent.Size = new System.Drawing.Size(464, 20);
            this.txtLogContent.TabIndex = 2;
            // 
            // btnXoahetthongbao
            // 
            this.btnXoahetthongbao.Location = new System.Drawing.Point(255, 3);
            this.btnXoahetthongbao.Name = "btnXoahetthongbao";
            this.btnXoahetthongbao.Size = new System.Drawing.Size(137, 23);
            this.btnXoahetthongbao.TabIndex = 1;
            this.btnXoahetthongbao.Text = "Xóa thông báo";
            this.btnXoahetthongbao.UseVisualStyleBackColor = true;
            this.btnXoahetthongbao.Click += new System.EventHandler(this.btnXoahetthongbao_Click);
            // 
            // ckThongbao
            // 
            this.ckThongbao.AutoSize = true;
            this.ckThongbao.Checked = true;
            this.ckThongbao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckThongbao.Location = new System.Drawing.Point(4, 6);
            this.ckThongbao.Name = "ckThongbao";
            this.ckThongbao.Size = new System.Drawing.Size(123, 17);
            this.ckThongbao.TabIndex = 0;
            this.ckThongbao.Text = "Cho phép thông báo";
            this.ckThongbao.UseVisualStyleBackColor = true;
            // 
            // tbListThongbao
            // 
            this.tbListThongbao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbListThongbao.Location = new System.Drawing.Point(0, 29);
            this.tbListThongbao.Name = "tbListThongbao";
            this.tbListThongbao.SelectedIndex = 0;
            this.tbListThongbao.Size = new System.Drawing.Size(876, 426);
            this.tbListThongbao.TabIndex = 2;
            // 
            // ucThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.tbListThongbao);
            this.Controls.Add(this.panel1);
            this.Name = "ucThongBao";
            this.Size = new System.Drawing.Size(876, 455);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLogContent;
        private System.Windows.Forms.Button btnXoahetthongbao;
        private System.Windows.Forms.CheckBox ckThongbao;
        private System.Windows.Forms.TabControl tbListThongbao;
    }
}
