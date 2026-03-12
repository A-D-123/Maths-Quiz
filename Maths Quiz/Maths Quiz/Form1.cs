using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maths_Quiz
{
    public partial class Login_Form : Form
    {
        TextBox usernameBox;
        TextBox passwordBox;

        public Login_Form()
        {
            createLoginForm();
        }
        void createLoginForm()
        {
            this.Name = "Login_Form";
            this.Text = "Login";
            this.Size = new Size(750, 500);
            this.Font = new Font("Segoe UI", 24);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label usernameLabel = new Label();
            usernameLabel.Text = "Username: ";
            usernameLabel.Location = new Point(50, 100);
            usernameLabel.AutoSize = true;

            usernameBox = new TextBox();
            usernameBox.Location = new Point(250, 100);
            usernameBox.Width = 300;

            Label passwordLabel = new Label();
            passwordLabel.Text = "Password: ";
            passwordLabel.Location = new Point(50, 175);
            passwordLabel.AutoSize = true;

            passwordBox = new TextBox();
            passwordBox.PasswordChar = '*';
            passwordBox.Location = new Point(250, 175);
            passwordBox.Width = 300;

            Button showPasswordButton = new Button();
            showPasswordButton.Text = "👁";
            showPasswordButton.Font = new Font("Segoe UI", 12);
            showPasswordButton.Location = new Point(550, 175);
            showPasswordButton.Size = new Size(50, 50);
            
            Button enterButton = new Button();
            enterButton.Text = "Enter";
            enterButton.Font = new Font("Segoe UI", 12);
            enterButton.Location = new Point(475, 225);
            enterButton.Size = new Size(75, 25);
            enterButton.Click += LoginButton_Click;

            this.Controls.Add(usernameLabel);
            this.Controls.Add(usernameBox);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(passwordBox);
            this.Controls.Add(enterButton);
            this.Controls.Add(showPasswordButton);
        }
        void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;
        }
    }
}
