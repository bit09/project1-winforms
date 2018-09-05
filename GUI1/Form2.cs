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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = MSI\SQLEXPRESS; Initial Catalog = UserRegistrationDB; Integrated Security=True");
            string query = "Select * from tblUser Where Username = '" + usernameLoginTxt.Text.Trim() + "' and Password = '" + passwordLoginTxt.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlCon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count == 1)
            {
                Form3 objForm3 = new Form3();
                this.Hide();
                objForm3.Show();
            }
            else
            {
                MessageBox.Show("Check your username and password!");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
