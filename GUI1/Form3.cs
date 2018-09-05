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
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace GUI1
{
    public partial class Form3 : Form
    {
        static string connString = @"Data Source = MSI\SQLEXPRESS; Initial Catalog = UserRegistrationDB; Integrated Security=True";
        SqlConnection connection = new SqlConnection(connString);
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataTable dataTable = new DataTable();

        public Form3()
        {
            InitializeComponent();

            connection.Open();
            cmd = new SqlCommand("select ProductName from ProductsDB", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["ProductName"].ToString());
            }
            connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                listBox2.Items.Add(this.textBox1.Text);


                try
                {
                    connection.Open();
                    cmd = new SqlCommand("insert into ProductsDB(ProductName) values('" + textBox1.Text + "')", connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }

                retrieve();

                this.textBox1.Focus();
                this.textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Please enter the item to add", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Please, select an item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    while (listBox1.SelectedItems.Count != 0)
            //    {
            //        listBox2.Items.Add(listBox1.SelectedItems[0]);
            //        listBox1.Items.Remove(listBox1.SelectedItems[0]);
            //    }
            //}
            if (this.listBox1.SelectedItems != null)
            {
                foreach (object item in listBox1.SelectedItems)
                {
                    if (listBox2.Items.Contains(item))
                    {
                        MessageBox.Show("This item(s) is already on the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.listBox1.Focus();
                        break;
                    }
                    else
                    {
                        listBox2.Items.Add(item);
                        this.listBox1.Focus();
                    }
                }
            }
            if (this.listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select an item!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select an item to remove from the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.listBox2.Focus();
            }
            else
            {
                while (this.listBox2.SelectedItems.Count != 0)
                {
                    listBox2.Items.Remove(listBox2.SelectedItems[0]);
                    this.listBox2.Focus();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.SelectedItems.Clear();
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.Items[i].ToString().ToLower().Contains(textBox2.Text.ToLower()))
                {
                    listBox1.SetSelected(i, true);
                    listBox1.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //refreshing main list of products
        private void retrieve()
        {
            listBox1.Items.Clear();

            cmd = new SqlCommand("select * from ProductsDB", connection);
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    listBox1.Items.Add(row[1].ToString());
                }
                connection.Close();

                dataTable.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringBuilder prodStr = new StringBuilder();
            foreach (object o in listBox2.Items)
            {
                prodStr.Append(o);
                prodStr.Append(Environment.NewLine);
            }
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress("egidijus.kunigonis@gmail.com");
                message.To.Add("egidijus.kunigonis@gmail.com");
                message.Body = "Products to buy for today: \n\n" + prodStr.ToString();
                message.Subject = "Products For Today";
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("egidijus.kunigonis@gmail.com", "innovision1987");
                client.Send(message);
                message = null;
            }
            catch (Exception s)
            {
                MessageBox.Show("Failed to send a message!");
            }

            MessageBox.Show("Products to buy for today: \n\n" + prodStr.ToString());
            prodStr.Clear();

        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.barbora.lt/paieska?uzklausa=" + listBox2.SelectedItem);
        }
    }
}
