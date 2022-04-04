
namespace AutoFB.View.PopupForm
{
    partial class popupLicenseKey
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnLicenseKey = new System.Windows.Forms.Button();
            this.ckHienLicenseKey = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập LicenseKey";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(109, 8);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(333, 20);
            this.txtKey.TabIndex = 1;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // btnLicenseKey
            // 
            this.btnLicenseKey.Location = new System.Drawing.Point(332, 34);
            this.btnLicenseKey.Name = "btnLicenseKey";
            this.btnLicenseKey.Size = new System.Drawing.Size(110, 23);
            this.btnLicenseKey.TabIndex = 2;
            this.btnLicenseKey.Text = "Xác nhận";
            this.btnLicenseKey.UseVisualStyleBackColor = true;
            this.btnLicenseKey.Click += new System.EventHandler(this.btnLicenseKey_Click);
            // 
            // ckHienLicenseKey
            // 
            this.ckHienLicenseKey.AutoSize = true;
            this.ckHienLicenseKey.Location = new System.Drawing.Point(109, 38);
            this.ckHienLicenseKey.Name = "ckHienLicenseKey";
            this.ckHienLicenseKey.Size = new System.Drawing.Size(106, 17);
            this.ckHienLicenseKey.TabIndex = 3;
            this.ckHienLicenseKey.Text = "Hiện LicenseKey";
            this.ckHienLicenseKey.UseVisualStyleBackColor = true;
            this.ckHienLicenseKey.CheckedChanged += new System.EventHandler(this.ckHienLicenseKey_CheckedChanged);
            // 
            // popupLicenseKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(454, 70);
            this.Controls.Add(this.ckHienLicenseKey);
            this.Controls.Add(this.btnLicenseKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "popupLicenseKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LicenseKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnLicenseKey;
        private System.Windows.Forms.CheckBox ckHienLicenseKey;
    }
}