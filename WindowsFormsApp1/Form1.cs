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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection connection = new SqlConnection(@"Server=[YOUR-SERVER-NAME]\SQLEXPRESS;Database = [YOUR-DB]; Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string strpassword = richTextBox2.Text;
                PasswordHasher hasher = new PasswordHasher();
                string hashedpassword = hasher.HashPassword(strpassword);
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [YOUR-TABLE-NAME] (Username,Password) VALUES (@username,@password)", connection);
                cmd.Parameters.AddWithValue("@username", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@password", hashedpassword);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your informations successfully saved!","Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                Form2 loginForm = new Form2();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
            
            
            
            private void button2_Click(object sender, EventArgs e)
            {
                

            }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
