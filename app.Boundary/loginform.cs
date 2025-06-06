using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.control;

namespace app.Boundary
{
    public partial class LoginForm : Form
    {
        private AuthControl authControl;

        public LoginForm()
        {
            InitializeComponent();
            authControl = new AuthControl();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Admin Login";
            this.Size = new System.Drawing.Size(300, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label và TextBox cho Username
            Label usernameLabel = new Label
            {
                Text = "Username:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(80, 20)
            };
            TextBox usernameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(100, 20),
                Size = new System.Drawing.Size(150, 20)
            };
            this.Controls.Add(usernameLabel);
            this.Controls.Add(usernameTextBox);

            // Label và TextBox cho Password
            Label passwordLabel = new Label
            {
                Text = "Password:",
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(80, 20)
            };
            TextBox passwordTextBox = new TextBox
            {
                Location = new System.Drawing.Point(100, 50),
                Size = new System.Drawing.Size(150, 20),
                UseSystemPasswordChar = true
            };
            this.Controls.Add(passwordLabel);
            this.Controls.Add(passwordTextBox);

            // Nút đăng nhập
            Button loginButton = new Button
            {
                Text = "Login",
                Location = new System.Drawing.Point(100, 90),
                Size = new System.Drawing.Size(80, 30)
            };
            loginButton.Click += (s, e) =>
            {
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                if (authControl.AuthenticateAdmin(username, password))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials!");
                }
            };
            this.Controls.Add(loginButton);
        }
    }
}
