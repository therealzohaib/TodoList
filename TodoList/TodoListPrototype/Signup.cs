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

namespace TodoListPrototype
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Enter valid information");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection("Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=TodoListDatabase;Integrated Security=True"))
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO USERS VALUES ('" + Convert.ToInt32(textBox1.Text) + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        this.Close();
                    }
                }
            }

            catch {
                MessageBox.Show("Enter valid information");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
