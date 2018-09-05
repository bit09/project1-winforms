using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUI1
{
    public partial class registrationForm : Form
    {
        string connectionString = @"Data Source = MSI\SQLEXPRESS; Initial Catalog = UserRegistrationDB; Integrated Security=True";
        public registrationForm()
        {
            InitializeComponent();
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxt.Text == "" || passwordTxt.Text == "")
            {
                MessageBox.Show("Please fill mandatory fields");
            }
            else if (passwordTxt.Text != confirmPasswordTxt.Text)
            {
                MessageBox.Show("Password do not match");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", nameTxt.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", lastNameTxt.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@EmailAddress", emailAddressTxt.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Username", usernameTxt.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", passwordTxt.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Registration is successfull");
                    Clear();
                }
            }
        }
        void Clear()
        {
            nameTxt.Text = lastNameTxt.Text = emailAddressTxt.Text = usernameTxt.Text = passwordTxt.Text = confirmPasswordTxt.Text = "";
        }
    }
}
