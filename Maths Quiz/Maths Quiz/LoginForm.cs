using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace Maths_Quiz
{
    public partial class Login_Form : Form
    {
        bool login;
        int bestScore;
        TextBox usernameBox;
        TextBox passwordBox;
        Button loginSignupSwitch;

        public Login_Form()
        {
            login = true;

            CreateLoginForm();
        }
        void CreateLoginForm()
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
            passwordBox.UseSystemPasswordChar = true;
            passwordBox.Location = new Point(250, 175);
            passwordBox.Width = 300;

            loginSignupSwitch = new Button();
            loginSignupSwitch.Text = "Switch to Sign Up";
            loginSignupSwitch.Font = new Font("Segoe UI", 12);
            loginSignupSwitch.Location = new Point(50, 0);
            loginSignupSwitch.Size = new Size(150, 50);
            loginSignupSwitch.Click += loginSignupSwitch_Click;

            Button showPasswordButton = new Button();
            showPasswordButton.Text = "👁";
            showPasswordButton.Font = new Font("Segoe UI", 12);
            showPasswordButton.Location = new Point(550, 175);
            showPasswordButton.Size = new Size(50, 50);
            showPasswordButton.Click += ShowPasswordButton_Click;

            Button enterButton = new Button();
            enterButton.Text = "Enter";
            enterButton.Font = new Font("Segoe UI", 12);
            enterButton.Location = new Point(475, 225);
            enterButton.Size = new Size(75, 25);
            enterButton.Click += EnterButton_Click;

            this.Controls.Add(usernameLabel);
            this.Controls.Add(usernameBox);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(passwordBox);
            this.Controls.Add(loginSignupSwitch);
            this.Controls.Add(enterButton);
            this.Controls.Add(showPasswordButton);
        }
        void EnterButton_Click(object sender, EventArgs e)
        {
            string file = $"{usernameBox.Text}.txt";

            if (login)
            {
                if (!File.Exists(file))
                {
                    MessageBox.Show("User not found");
                    return;
                }
                string[] lines = File.ReadAllLines(file);
                bestScore = int.Parse(lines[1]);

                if (lines[0] != Encode(passwordBox.Text))
                {
                    MessageBox.Show("Password Incorrect");
                    return;
                }
                QuizForm quizForm = new QuizForm(bestScore);
                this.Hide();
                quizForm.Show();
                return;
            }
            if (!IsValidInput(usernameBox.Text))
            {
                MessageBox.Show("Username invalid");
                return;
            }
            if (!IsValidInput(passwordBox.Text))
            {
                MessageBox.Show("Password invalid");
                return;
            }
            if (File.Exists(file))
            {
                MessageBox.Show("This username is already taken");
                return;
            }

            File.WriteAllText(file, Encode(passwordBox.Text) + "\n0");

            usernameBox.Clear();
            passwordBox.Clear();
        }
        void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            passwordBox.UseSystemPasswordChar = !passwordBox.UseSystemPasswordChar;
        }
        void loginSignupSwitch_Click(object sender, EventArgs e)
        {
            if (login) loginSignupSwitch.Text = "Switch to Log In";
            else loginSignupSwitch.Text = "Switch to Sign Up";
            login = !login;
        }
        static bool IsValidInput(string str)
        {
            if (str.Length > 16) return false;
            return str.All(c => char.IsLetterOrDigit(c) || c == '_');
        }
        static string Encode(string str)
        {
            const int key = 10;
            string encStr = "";

            foreach (char c in str)
                encStr += (char)(32 + (c - 32 + key) % 95);
            return encStr;
        }
    }
}
