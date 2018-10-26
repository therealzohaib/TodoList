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
    public partial class Form1 : Form
    {
        public static int settext = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup su = new Signup();
            su.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter correct details");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                try {
                    using (SqlConnection conn = new SqlConnection("Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=TodoListDatabase;Integrated Security=True"))
                    {
                        conn.Open();
                        string cmd = "SELECT STUDENT_ID FROM USERS WHERE STUDENT_ID = '" + Convert.ToInt32(textBox1.Text) + "' AND PASSWORD = '" + textBox2.Text + "'";
                        SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        conn.Close();
                        if (dt.Rows.Count >= 1)
                        {
                            settext = Convert.ToInt32(textBox1.Text);
                            MainAppWindow maw = new MainAppWindow();
                            maw.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong username/pass combination");
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid username/password");
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
