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
using System.Net;
using System.Net.Mail;
using System.Web;
using Tulpep.NotificationWindow;

namespace TodoListPrototype
{
    public partial class MainAppWindow : Form
    {
        string taskname = "";
        public MainAppWindow()
        {
            InitializeComponent();
            Notifications();
            DisplayTasks();
        }

        private void MainAppWindow_Load(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTasks at = new AddTasks();
            at.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MarkTasksCompleted mst = new MarkTasksCompleted();
            mst.Show();
            this.Close();
        }
        private void Notifications()
        {
            timer1.Interval = 1000; 
            timer1.Start();
        }
        public string GetEmail()
        {
            using (SqlConnection conn = new SqlConnection("Server=HAIER-PC\\SQLEXPRESS; Database=TodoListDatabase; Integrated Security = true"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [E-mail Address] FROM Users WHERE Student_ID = '" + Form1.settext + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                string email = "";
                while (dr.Read())
                {
                    email = dr.GetString(0);
                }
                dr.Close();
                conn.Close();
                return email;
            }
        }
        private void Timer_Tick(object s, EventArgs a)
        {
            using (SqlConnection conn = new SqlConnection("Server=HAIER-PC\\SQLEXPRESS; Database=TodoListDatabase; Integrated Security = true; MultipleActiveResultSets=true"))
            {
                conn.Open();
                //for 30 mins 
                SqlCommand cmd = new SqlCommand("SELECT Task_Name FROM Tasks WHERE Student_ID = '" + Form1.settext + "' AND Deadline = '" + DateTime.Now.AddMinutes(30) + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    while (dr.Read())
                    {
                        taskname = dr.GetValue(0).ToString();
                        Popup($"30 mins left to complete {taskname}");
                        SendEmail(GetEmail(), taskname, 30);
                    }
                    dr.Close();
                }
                //for 15mins 
                SqlCommand cmd2 = new SqlCommand("SELECT Task_Name FROM Tasks WHERE Student_ID = '" + Form1.settext + "' AND Deadline = '" + DateTime.Now.AddMinutes(15) + "'", conn);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.HasRows == true) 
                {
                    while (dr2.Read())
                    {
                        taskname = dr2.GetValue(0).ToString();
                        Popup($"15 mins left to complete {taskname}");
                        SendEmail(GetEmail(), taskname, 15);
                    }
                }
                //for failed tasks
                SqlCommand cmd3 = new SqlCommand("INSERT INTO Failed_Tasks(Student_ID, Task_Name, Deadline) SELECT Student_ID, Task_Name, Deadline FROM Tasks WHERE Student_ID = '" + Form1.settext + "' AND Deadline <= '" + DateTime.Now + "'", conn);
                SqlCommand cmd4 = new SqlCommand("DELETE FROM Tasks WHERE Student_ID = '" + Form1.settext + "' AND Deadline <= '" + DateTime.Now + "'", conn);
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                DisplayTasks();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection("Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=TodoListDatabase;Integrated Security=True; MultipleActiveResultSets=true"))
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT Task_ID FROM Accomplished_Tasks WHERE Student_ID = '" + Form1.settext + "'", conn);
                SqlCommand cmd2 = new SqlCommand("SELECT Task_ID FROM Failed_Tasks WHERE Student_ID = '" + Form1.settext + "'", conn);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                double Number_of_at = 0;
                double Number_of_ft = 0;
                while (dr1.Read())
                {
                    Number_of_at++;
                }
                while (dr2.Read())
                {
                    Number_of_ft++;
                }
                MessageBox.Show(string.Format("Tasks Completed : {0} \nTasks Failed : {1}", Number_of_at, Number_of_ft));
                conn.Close();
            }
        }
        private void SendEmail(string receiver, string taskname, int time)
        {
            try
            {
                MailMessage msg = new MailMessage("todolistnotificationsystem@gmail.com", receiver, "Todo List - Notification", string.Format("{0} minutes remain for {1}", time, taskname));
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential("todolistnotificationsystem@gmail.com", "qwertyzxcc");
                client.Credentials = nc;
                client.Send(msg);
            }
            catch
            {
                MessageBox.Show("No internet connection/ Invalid E-mail Address");
            }
        }
        public void DisplayTasks()
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection conn = new SqlConnection("Data Source=HAIER-PC\\SQLEXPRESS;Initial Catalog=TodoListDatabase;Integrated Security=True"))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Task_Name, Deadline FROM Tasks " +
                    "WHERE Student_ID = '" + Convert.ToInt32(Form1.settext) + "' " +
                    "ORDER BY Deadline ASC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["Task_Name"];
                    dataGridView1.Rows[n].Cells[1].Value = item["Deadline"].ToString();
                }
                conn.Close();
            }
        }
        public void Popup(string text)
        {
            PopupNotifier pop = new PopupNotifier();
            pop.TitleColor = Color.White;
            pop.TitleText = "Notification";
            pop.ContentColor = Color.White;
            pop.ContentText = text;
            pop.BodyColor = System.Drawing.Color.FromArgb(5, 25, 30);
            pop.Popup();
        }
    }
}
