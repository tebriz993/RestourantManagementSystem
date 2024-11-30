using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.WinForms
{
    public partial class Login : Form
    {
        private List<User> users;
        private readonly string connectionString = "Server=.;Database=RestourantManagementSystemDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public Login()
        {
            InitializeComponent();
            InitializeUsers();
            checkShowPassword.CheckedChanged += ShowPassword;
            btnLogin.Click += button1_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void InitializeUsers()
        {
            users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Username, Password, Role FROM Users";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string username = reader.GetString(1);
                            string password = reader.GetString(2);
                            string role = reader.GetString(3);

                            users.Add(new User(id, username, password, role));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User authenticatedUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (authenticatedUser != null)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPassword(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = checkShowPassword.Checked ? '\0' : '*';
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            checkShowPassword.Checked = false;
            txtPassword.PasswordChar = '*';
        }
    }
}
