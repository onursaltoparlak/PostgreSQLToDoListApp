using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project10_PostgreSQLToDoListApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;port=5432;Database=DbProject10ToDoApp;user ID=postgres;Password=your_password";

        void ToDoList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM ToDoLists";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);

            DataTable dataSet = new DataTable();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            connection.Close();
        }

        void CategoryList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Categories";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = dataTable;
            connection.Close();
        }




        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
        }

        private void btnAllList_Click(object sender, EventArgs e)
        {
            ToDoList(); var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "Select todolistid, title, description, status, priority, categoryname from todolists\r\ninner join categories\r\non todolists.categoryid=categories.categoryid";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);

            DataTable dataSet = new DataTable();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            connection.Close();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            ToDoList();
            CategoryList();
        }

        

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            string title = txtTitle.Text;
            string priority = txtPriority.Text;
            string description = txtDescription.Text;

            bool status = false;

            if (rdbCompleted.Checked)
            {
                status = true;
            }
            if (rdbContinue.Checked)
            {
                status = false;
            }

            BitArray statusBit = new BitArray(1);
            statusBit[0] = status;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO ToDoLists (title, description, status, priority, categoryid) VALUES (@title, @description, @status, @priority, @categoryId)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@status", statusBit);
                    command.Parameters.AddWithValue("@priority", priority);
                    command.Parameters.AddWithValue("@categoryId", categoryId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Yapılacak İşlem Eklendi");
                    ToDoList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "DELETE From ToDoLists Where ToDoListId=@toDoListId";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@toDoListId", id);
                command.ExecuteNonQuery();
                MessageBox.Show("Veri Başarıyla Silindi!");
                CategoryList();

            }
            connection.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ToDoList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            int categoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            string title = txtTitle.Text;
            string priority = txtPriority.Text;
            string description = txtDescription.Text;


            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE ToDoLists SET Title=@title, Description=@description,priority=@priority,categoryid=@categoryid where todolistid=@todolistid";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@todolistid", id);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@priority", priority);
                command.Parameters.AddWithValue("@categoryId", categoryId);
                command.ExecuteNonQuery();
                MessageBox.Show("İşlem Başarıyla Güncellendi");
                CategoryList();
            }
        }

        private void btnCheckedList_Click(object sender, EventArgs e)
        {
            bool status = false;
            BitArray statusBit = new BitArray(1);
            statusBit[0] = status;

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM ToDoLists Where Status='1'";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);

            DataTable dataSet = new DataTable();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            connection.Close();
        }

        private void btnContinueList_Click(object sender, EventArgs e)
        {
            bool status = false;
            BitArray statusBit = new BitArray(1);
            statusBit[0] = status;

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM ToDoLists WHERE Status = '0'";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);

            DataTable dataSet = new DataTable();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            connection.Close();
        }
    }
}
