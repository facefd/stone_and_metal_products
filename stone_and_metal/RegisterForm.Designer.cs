// RegisterForm.Designer.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace stone_and_metal
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelNewLogin = new System.Windows.Forms.Label();
            this.textBoxNewLogin = new System.Windows.Forms.TextBox();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.labelNewLogin.AutoSize = true;
            this.labelNewLogin.Location = new System.Drawing.Point(20, 30);
            this.labelNewLogin.Text = "Логин:";

            this.textBoxNewLogin.Location = new System.Drawing.Point(110, 27);
            this.textBoxNewLogin.Size = new System.Drawing.Size(180, 20);

            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(20, 60);
            this.labelNewPassword.Text = "Пароль:";

            this.textBoxNewPassword.Location = new System.Drawing.Point(110, 57);
            this.textBoxNewPassword.Size = new System.Drawing.Size(180, 20);
            this.textBoxNewPassword.PasswordChar = '*';

            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(20, 90);
            this.labelConfirmPassword.Text = "Подтвердите:";

            this.textBoxConfirmPassword.Location = new System.Drawing.Point(110, 87);
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(180, 20);
            this.textBoxConfirmPassword.PasswordChar = '*';

            this.buttonRegister.Location = new System.Drawing.Point(20, 130);
            this.buttonRegister.Size = new System.Drawing.Size(270, 30);
            this.buttonRegister.Text = "Зарегистрироваться";
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.labelNewLogin);
            this.Controls.Add(this.textBoxNewLogin);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.textBoxNewPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.buttonRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelNewLogin;
        private System.Windows.Forms.TextBox textBoxNewLogin;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Button buttonRegister;
    }
}