using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Server=METEHANS-DESKTO\SQLEXPRESS;Database = Users; Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string enteredpassword = richTextBox4.Text;
            string hashfromdb = null;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Password FROM User_Table WHERE Username=@username", connection);
                cmd.Parameters.AddWithValue("@username", richTextBox3.Text);
                
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    hashfromdb = (string)result;
                }
                if (hashfromdb != null)
                {
                    PasswordHasher hasher = new PasswordHasher();
                    bool isPasswordValid = hasher.VerifyPassword(enteredpassword, hashfromdb);
                    if (isPasswordValid)
                    {
                        MessageBox.Show("You successfully logged in!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is wrong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Username or password is wrong!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", ex.Message, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                
            }
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 signupForm = new Form1();
            signupForm.Show();
            this.Hide();
        }
    }
}
