using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.WinForms
{
    public partial class Login : Form // Class name changed to Login
    {
        private List<User> users;

        public Login() // Constructor name changed to Login to match the class name
        {
            InitializeComponent();
            InitializeUsers();
            checkShowPassword.CheckedChanged += new EventHandler(ShowPassword); // Attach ShowPassword event
            btnLogin.Click += new EventHandler(button1_Click); // Attach Login button click event
            btnCancel.Click += new EventHandler(btnCancel_Click); // Attach Cancel button click event
        }

        private void InitializeUsers()
        {
            users = new List<User>
            {
                new User("admin", "admin123", "Admin"),
                new User("user1", "password1"),
                new User("user2", "password2")
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim(); // Assuming txtUsername is the TextBox for username
            string password = txtPassword.Text;        // Assuming txtPassword is the TextBox for password

            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                User authenticatedUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (authenticatedUser != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Proceed to main application form
                    // Example: new MainForm().Show(); this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ShowPassword method to toggle password visibility
        private void ShowPassword(object sender, EventArgs e)
        {
            if (checkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Mask password again
            }
        }

        // Cancel button click event to clear username and password fields
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            checkShowPassword.Checked = false; // Uncheck Show Password if it's checked
            txtPassword.PasswordChar = '*'; // Reset the password mask
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Additional button functionality if needed
        }
    }
}
