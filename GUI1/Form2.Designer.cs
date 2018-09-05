namespace GUI1
{
    partial class loginForm
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
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.usernameLoginTxt = new System.Windows.Forms.TextBox();
            this.passwordLoginTxt = new System.Windows.Forms.TextBox();
            this.logInBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(213, 141);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Username";
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(213, 206);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(53, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Password";
            // 
            // usernameLoginTxt
            // 
            this.usernameLoginTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usernameLoginTxt.Location = new System.Drawing.Point(318, 141);
            this.usernameLoginTxt.Name = "usernameLoginTxt";
            this.usernameLoginTxt.Size = new System.Drawing.Size(180, 20);
            this.usernameLoginTxt.TabIndex = 2;
            // 
            // passwordLoginTxt
            // 
            this.passwordLoginTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordLoginTxt.Location = new System.Drawing.Point(318, 199);
            this.passwordLoginTxt.Name = "passwordLoginTxt";
            this.passwordLoginTxt.PasswordChar = '*';
            this.passwordLoginTxt.Size = new System.Drawing.Size(180, 20);
            this.passwordLoginTxt.TabIndex = 3;
            // 
            // logInBtn
            // 
            this.logInBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logInBtn.Location = new System.Drawing.Point(347, 371);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(75, 23);
            this.logInBtn.TabIndex = 4;
            this.logInBtn.Text = "LogIn";
            this.logInBtn.UseVisualStyleBackColor = true;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(676, 416);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 5;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(676, 460);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 6;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(764, 495);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.passwordLoginTxt);
            this.Controls.Add(this.usernameLoginTxt);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "loginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox usernameLoginTxt;
        private System.Windows.Forms.TextBox passwordLoginTxt;
        private System.Windows.Forms.Button logInBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}