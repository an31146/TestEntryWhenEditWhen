namespace TestEntryWhenEditWhen
{
    partial class Form1
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtLibName = new System.Windows.Forms.TextBox();
            this.lblLibName = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.chkTrustLogin = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtFolderID = new System.Windows.Forms.TextBox();
            this.lblPrjID = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(980, 512);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(175, 77);
            this.btnCreate.TabIndex = 23;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.Location = new System.Drawing.Point(32, 32);
            this.lblServerName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(177, 32);
            this.lblServerName.TabIndex = 24;
            this.lblServerName.Text = "Server Name";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(309, 22);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(847, 39);
            this.txtServerName.TabIndex = 25;
            this.txtServerName.Text = "win2012svr.beantown.ma.local";
            // 
            // txtLibName
            // 
            this.txtLibName.Location = new System.Drawing.Point(309, 84);
            this.txtLibName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtLibName.Name = "txtLibName";
            this.txtLibName.Size = new System.Drawing.Size(847, 39);
            this.txtLibName.TabIndex = 27;
            this.txtLibName.Text = "Cheapside";
            // 
            // lblLibName
            // 
            this.lblLibName.AutoSize = true;
            this.lblLibName.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibName.Location = new System.Drawing.Point(32, 94);
            this.lblLibName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblLibName.Name = "lblLibName";
            this.lblLibName.Size = new System.Drawing.Size(181, 32);
            this.lblLibName.TabIndex = 26;
            this.lblLibName.Text = "Library Name";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(309, 222);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(847, 39);
            this.txtUserId.TabIndex = 30;
            this.txtUserId.Text = "beantown\\wsadmin";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(32, 231);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(101, 32);
            this.lblUserId.TabIndex = 29;
            this.lblUserId.Text = "UserID";
            // 
            // chkTrustLogin
            // 
            this.chkTrustLogin.AutoSize = true;
            this.chkTrustLogin.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTrustLogin.Location = new System.Drawing.Point(40, 162);
            this.chkTrustLogin.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkTrustLogin.Name = "chkTrustLogin";
            this.chkTrustLogin.Size = new System.Drawing.Size(223, 36);
            this.chkTrustLogin.TabIndex = 28;
            this.chkTrustLogin.Text = "Trusted Login";
            this.chkTrustLogin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(309, 288);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(847, 39);
            this.txtPassword.TabIndex = 32;
            this.txtPassword.Text = "Spec!es8472";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(32, 298);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(136, 32);
            this.lblPassword.TabIndex = 31;
            this.lblPassword.Text = "Password";
            // 
            // txtFolderID
            // 
            this.txtFolderID.Location = new System.Drawing.Point(309, 350);
            this.txtFolderID.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtFolderID.Name = "txtFolderID";
            this.txtFolderID.Size = new System.Drawing.Size(847, 39);
            this.txtFolderID.TabIndex = 34;
            this.txtFolderID.Text = "12500";
            // 
            // lblPrjID
            // 
            this.lblPrjID.AutoSize = true;
            this.lblPrjID.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrjID.Location = new System.Drawing.Point(32, 359);
            this.lblPrjID.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPrjID.Name = "lblPrjID";
            this.lblPrjID.Size = new System.Drawing.Size(198, 32);
            this.lblPrjID.TabIndex = 33;
            this.lblPrjID.Text = "Folder PRJ_ID";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(32, 437);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(165, 32);
            this.lblFilePath.TabIndex = 35;
            this.lblFilePath.Text = "File full path";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(309, 434);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(649, 39);
            this.txtFilePath.TabIndex = 36;
            this.txtFilePath.Text = "\r\n";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(980, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 77);
            this.button1.TabIndex = 37;
            this.button1.Text = "&Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 606);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtFolderID);
            this.Controls.Add(this.lblPrjID);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.chkTrustLogin);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtLibName);
            this.Controls.Add(this.lblLibName);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.btnCreate);
            this.Font = new System.Drawing.Font("Arial", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtLibName;
        private System.Windows.Forms.Label lblLibName;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.CheckBox chkTrustLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtFolderID;
        private System.Windows.Forms.Label lblPrjID;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button button1;
    }
}

