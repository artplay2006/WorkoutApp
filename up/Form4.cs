using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace up
{
    public partial class Form4 : Form
    {
        public Form4(DataTable dataForView)
        {
            InitializeComponent();
            guna2DataGridView1.DataSource = dataForView;
            foreach (DataColumn column in dataForView.Columns)
            {
                switch (column.ColumnName)
                {
                    case "title":
                        guna2DataGridView1.Columns[column.ColumnName].HeaderText = "Название";
                        break;
                    case "id category":
                        guna2DataGridView1.Columns[column.ColumnName].Visible = false;
                        break;
                    case "image":
                        guna2DataGridView1.Columns[column.ColumnName].HeaderText = "Картинка";
                        break;
                    case "description":
                        guna2DataGridView1.Columns[column.ColumnName].HeaderText = "Описание";
                        break;
                    case "id упражнения":
                        guna2DataGridView1.Columns[column.ColumnName].Visible = false;
                        break;
                }
            }
        }
        public bool CheckTitleSize(string title)
        {
            return title.Length <= 53 && title.Length > 0;
        }
        public bool CheckPictureType(string image)
        {
            return image.EndsWith(".jpg") || image.EndsWith(".png") || image.EndsWith(".gif");
        }
        public void LoadDataToDataGridView(DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            DataTable dataTable = new DataTable();
            using (OleDbConnection connection = new OleDbConnection(Form3.connectString))
            {
                connection.Open();
                //замена категории
                string query = $"SELECT * FROM Exercises WHERE [id category] = '{Form2.IdCategory}'";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        //DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        dataGridView.DataSource = dataTable;
                    }
                }
            }
            foreach (DataColumn column in dataTable.Columns)
            {
                switch (column.ColumnName)
                {
                    case "title":
                        dataGridView.Columns[column.ColumnName].HeaderText = "Название";
                        break;
                    case "id category":
                        dataGridView.Columns[column.ColumnName].Visible = false;
                        break;
                    case "image":
                        dataGridView.Columns[column.ColumnName].HeaderText = "Картинка";
                        break;
                    case "description":
                        dataGridView.Columns[column.ColumnName].HeaderText = "Описание";
                        break;
                    case "id упражнения":
                        dataGridView.Columns[column.ColumnName].Visible = false;
                        break;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)//измеенние
        {
            string idExercise = textBox1.Text;
            string newTitle = textBox2.Text;//42
            string newImage = textBox3.Text;//jpg png gif
            string newDescription = textBox4.Text;
            if (CheckTitleSize(newTitle) && CheckPictureType(newImage) && textBox1.Text.Length != 0)
            {
                string updateQuery = "UPDATE Exercises SET title = @title, [image] = @image, " +
                    "description = @description WHERE [id упражнения] = @idExercise";

                using (OleDbConnection dbConnection = new OleDbConnection(Form3.connectString))
                {
                    dbConnection.Open();
                    using (OleDbCommand command = new OleDbCommand(updateQuery, dbConnection))
                    {
                        command.Parameters.AddWithValue("@title", newTitle);
                        command.Parameters.AddWithValue("@image", newImage);
                        command.Parameters.AddWithValue("@description", newDescription);
                        command.Parameters.AddWithValue("@idExercise", idExercise);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.Close();
                }
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                pictureBox1.Image = null;
                LoadDataToDataGridView(guna2DataGridView1);
            }
            else if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Невыбрано упражнение");
            }
            else if (!CheckTitleSize(newTitle))
            {
                MessageBox.Show("Длинный размер названия, ограничение 43 символа или в поле ничего не записано");
            }
            else
            {
                MessageBox.Show("Не подходящий тип картинки, подходят .jpg, .png, .gif или не выбрана картинка вовсе");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)//добавление
        {
            string newTitle = textBox2.Text;
            string newImage = textBox3.Text;
            string newDescription = textBox4.Text;

            if (CheckTitleSize(newTitle) && CheckPictureType(newImage))
            {
                string insertQuery = "INSERT INTO Exercises ([id category], title, [image], description) " +
                "VALUES (@idCategory, @title, @image, @description)";

                using (OleDbConnection dbConnection = new OleDbConnection(Form3.connectString))
                {
                    dbConnection.Open();
                    using (OleDbCommand command = new OleDbCommand(insertQuery, dbConnection))
                    {
                        command.Parameters.AddWithValue("@idCategory", Form2.IdCategory);
                        command.Parameters.AddWithValue("@title", newTitle);
                        command.Parameters.AddWithValue("@image", newImage);
                        command.Parameters.AddWithValue("@description", newDescription);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.Close();
                }
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                pictureBox1.Image = null;
                LoadDataToDataGridView(guna2DataGridView1);
            }
            else if (!CheckTitleSize(newTitle))
            {
                MessageBox.Show("Длинный размер названия, ограничение 43 символа или в поле ничего не записано");
            }
            else
            {
                MessageBox.Show("Не подходящий тип картинки, подходят .jpg, .png, .gif или не выбрана картинка вовсе");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)//удаление
        {
            //проверка если упражнение выбрано
            if (textBox1.Text.Length != 0)
            {
                string idExercise = textBox1.Text;
                string deleteQuery = "DELETE FROM Exercises WHERE [id упражнения] = @idExercise";

                using (OleDbConnection dbConnection = new OleDbConnection(Form3.connectString))
                {
                    dbConnection.Open();
                    using (OleDbCommand command = new OleDbCommand(deleteQuery, dbConnection))
                    {
                        command.Parameters.AddWithValue("@idExercise", idExercise);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.Close();
                }
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                pictureBox1.Image = null;
                LoadDataToDataGridView(guna2DataGridView1);
            }
            else
            {
                MessageBox.Show("Не выбрано упражнение для удаления");
            }
        }

        private void guna2DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < guna2DataGridView1.RowCount - 1)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];
                string? idExercise = selectedRow.Cells["id упражнения"].Value.ToString();
                string? title = selectedRow.Cells["title"].Value.ToString();

                textBox1.Text = idExercise;
                textBox2.Text = title;
                textBox3.Text = selectedRow.Cells["image"].Value.ToString();
                pictureBox1.Image = System.Drawing.Image.FromFile(selectedRow.Cells["image"].Value.ToString());
                textBox4.Text = selectedRow.Cells["description"].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form3().Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                // название файла гкартинки
                //MessageBox.Show(selectedFilePath.Substring(selectedFilePath.LastIndexOf('\\')+1));
                textBox3.Text = selectedFilePath.Substring(selectedFilePath.LastIndexOf('\\') + 1);
                try
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(selectedFilePath.Substring(selectedFilePath.LastIndexOf('\\') + 1));
                }
                catch
                {
                    MessageBox.Show("Не подходящий тип картинки, подходят .jpg, .png, .gif или не выбрана картинка вовсе");
                }
            }
        }

        private void Form4_Click(object sender, EventArgs e)
        {

        }

        private void Form4_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            pictureBox1.Image = null;
        }
    }
}
