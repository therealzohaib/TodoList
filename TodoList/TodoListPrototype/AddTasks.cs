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
    public partial class AddTasks : Form
    {
        public AddTasks()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                using (SqlConnection conn = new SqlConnection("Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=TodoListDatabase;Integrated Security=True"))
                {
                    conn.Open();
                    SqlCommand add = conn.CreateCommand();
                    add.CommandType = CommandType.Text;
                    add.CommandText = "INSERT INTO TASKS (Student_ID, Task_Name, Deadline) VALUES ('" + Form1.settext + "', '" + textBox1.Text + "', '" + dateTimePicker1.Value + "')";
                    add.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show(string.Format("{0} has been added", textBox1.Text));
                    MainAppWindow maw = new MainAppWindow();
                    maw.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter correct values");
            }
        }

        private void AddTasks_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainAppWindow maw = new MainAppWindow();
            maw.Show();
            this.Close();
        }
    }
}
