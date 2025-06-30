using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project10_PostgreSQLToDoListApp
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        string connectionString = "Server=localhost;port=5432;Database=DbProject10ToDoApp;user ID=postgres;Password=your_password";

        void CategoryList()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Categories order by CategoryId";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);

            DataTable dataSet = new DataTable();
            adapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet;
            connection.Close();
        }




        private void FrmCategory_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Categories (CategoryName) VALUES (@CategoryName)";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CategoryName", txtName.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Kategori Eklendi");
                CategoryList();

            }
            connection.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "DELETE From Categories Where CategoryId=@categoryId";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryId", id);
                command.ExecuteNonQuery();
                MessageBox.Show("Kategori Silindi!");
                CategoryList();

            }
            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string categoryName = txtName.Text;
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            string query = "UPDATE Categories SET CategoryName=@categoryName WHERE CategoryId=@categoryId";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryName", txtName.Text);
                command.Parameters.AddWithValue("@categoryId", id);
                command.ExecuteNonQuery();
                MessageBox.Show("Kategori Güncellendi");
                CategoryList();
            }
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Categories WHERE CategoryId=@categoryId";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoryId", id);
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;

                    }
                }
            }
        }
    }
}
