namespace Dbsys
{
    partial class Frm_Login
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
            this.ckShowPass = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.errorProviderCustom = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkLabelRigester = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCustom)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ckShowPass
            // 
            this.ckShowPass.AutoSize = true;
            this.ckShowPass.BackColor = System.Drawing.Color.LightSlateGray;
            this.ckShowPass.ForeColor = System.Drawing.Color.Gold;
            this.ckShowPass.Location = new System.Drawing.Point(129, 224);
            this.ckShowPass.Name = "ckShowPass";
            this.ckShowPass.Size = new System.Drawing.Size(102, 17);
            this.ckShowPass.TabIndex = 12;
            this.ckShowPass.Text = "Show Password";
            this.ckShowPass.UseVisualStyleBackColor = false;
            this.ckShowPass.CheckedChanged += new System.EventHandler(this.ckShowPass_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(35, 194);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(196, 24);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightSlateGray;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(32, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(35, 138);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(196, 24);
            this.txtUsername.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(32, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Linen;
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLogin.Location = new System.Drawing.Point(62, 256);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(130, 29);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // errorProviderCustom
            // 
            this.errorProviderCustom.ContainerControl = this;
            // 
            // linkLabelRigester
            // 
            this.linkLabelRigester.ActiveLinkColor = System.Drawing.Color.Linen;
            this.linkLabelRigester.AutoSize = true;
            this.linkLabelRigester.BackColor = System.Drawing.Color.LightSlateGray;
            this.linkLabelRigester.LinkColor = System.Drawing.Color.Gold;
            this.linkLabelRigester.Location = new System.Drawing.Point(146, 288);
            this.linkLabelRigester.Name = "linkLabelRigester";
            this.linkLabelRigester.Size = new System.Drawing.Size(46, 13);
            this.linkLabelRigester.TabIndex = 14;
            this.linkLabelRigester.TabStop = true;
            this.linkLabelRigester.Text = "Register";
            this.linkLabelRigester.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRigester_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.linkLabelRigester);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.ckShowPass);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(36, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 379);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Dbsys.Properties.Resources.appointease_high_resolution_logo_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(35, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 145);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dbsys.Properties.Resources.front_view_beautiful_dog_with_copy_space_23_2148786561__2_;
            this.pictureBox1.Location = new System.Drawing.Point(-183, -53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(892, 547);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Frm_Login";
            this.Text = "Frm_Login";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCustom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ckShowPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ErrorProvider errorProviderCustom;
        private System.Windows.Forms.LinkLabel linkLabelRigester;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}