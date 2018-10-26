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
    public partial class MarkTasksCompleted : Form
    {
        public MarkTasksCompleted()
        {
            InitializeComponent();
            DisplayTasks();
        }

        private void MarkTasksCompleted_Load(object sender, EventArgs e)
        {
            

        }
        public void DisplayTasks()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=TodoListDatabase;Integrated Security=True"))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Task_ID, Task_Name, Deadline FROM Tasks " +
                    "WHERE Student_ID = '" + Convert.ToInt32(Form1.settext) +"' " +
                    "ORDER BY Deadline ASC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach(DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[1].Value = item["Task_ID"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["Task_Name"];
                    dataGridView1.Rows[n].Cells[3].Value = item["Deadline"].ToString();
                }
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mark();
            dataGridView1.Rows.Clear();
            DisplayTasks();
        }
        public void Mark()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=TodoListDatabase;Integrated Security=True"))
            {
                conn.Open();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    var cell = item.Cells[0].Value;
                    if (cell != null)
                    {
                        var value = cell;
                        if (value != null && (bool)value == true)
                        {
                            SqlCommand cmd1 = new SqlCommand("INSERT INTO Accomplished_Tasks(Task_Name, Student_ID, Deadline) " +
                                "VALUES ('"+ item.Cells[2].Value + "','"+ Form1.settext + "','"+ item.Cells[3].Value + "')", conn);
                            cmd1.ExecuteNonQuery();
                            SqlCommand cmd2 = new SqlCommand("DELETE FROM Tasks " +
                                "WHERE Task_ID = '" + item.Cells[1].Value + "'", conn);
                            cmd2.ExecuteNonQuery();
                            dataGridView1.Rows.Clear();
                        }
                    }
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainAppWindow maw = new MainAppWindow();
            maw.Show();
            this.Close();
        }
    }
}
