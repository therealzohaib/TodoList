namespace TodoListPrototype
{
    partial class MainAppWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Logout = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.todoListDatabaseDataSet = new TodoListPrototype.TodoListDatabaseDataSet();
            this.tasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tasksTableAdapter = new TodoListPrototype.TodoListDatabaseDataSetTableAdapters.TasksTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasksBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.todoListDatabaseDataSet1 = new TodoListPrototype.TodoListDatabaseDataSet1();
            this.tasksTableAdapter1 = new TodoListPrototype.TodoListDatabaseDataSet1TableAdapters.TasksTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.todoListDatabaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoListDatabaseDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(519, 25);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 55);
            this.Logout.TabIndex = 0;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(519, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 55);
            this.button2.TabIndex = 1;
            this.button2.Text = "Add Tasks";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(481, 182);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 55);
            this.button4.TabIndex = 3;
            this.button4.Text = "Mark Tasks As Completed";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(481, 259);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 55);
            this.button5.TabIndex = 4;
            this.button5.Text = "Tasks Completed/Failed Ratio";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // todoListDatabaseDataSet
            // 
            this.todoListDatabaseDataSet.DataSetName = "TodoListDatabaseDataSet";
            this.todoListDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tasksBindingSource
            // 
            this.tasksBindingSource.DataMember = "Tasks";
            this.tasksBindingSource.DataSource = this.todoListDatabaseDataSet;
            // 
            // tasksTableAdapter
            // 
            this.tasksTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(459, 290);
            this.dataGridView1.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Task Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 208;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Deadline";
            this.Column2.Name = "Column2";
            this.Column2.Width = 207;
            // 
            // tasksBindingSource1
            // 
            this.tasksBindingSource1.DataMember = "Tasks";
            this.tasksBindingSource1.DataSource = this.todoListDatabaseDataSet1;
            // 
            // todoListDatabaseDataSet1
            // 
            this.todoListDatabaseDataSet1.DataSetName = "TodoListDatabaseDataSet1";
            this.todoListDatabaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tasksTableAdapter1
            // 
            this.tasksTableAdapter1.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainAppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(643, 345);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Logout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainAppWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainAppWindow";
            this.Load += new System.EventHandler(this.MainAppWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.todoListDatabaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.todoListDatabaseDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private TodoListDatabaseDataSet todoListDatabaseDataSet;
        private System.Windows.Forms.BindingSource tasksBindingSource;
        private TodoListDatabaseDataSetTableAdapters.TasksTableAdapter tasksTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TodoListDatabaseDataSet1 todoListDatabaseDataSet1;
        private System.Windows.Forms.BindingSource tasksBindingSource1;
        private TodoListDatabaseDataSet1TableAdapters.TasksTableAdapter tasksTableAdapter1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}