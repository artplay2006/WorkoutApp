using Guna.UI2.WinForms;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace up
{
    public partial class Form3 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.mdb;";
        DataTable dataTable = new DataTable();
        struct ProblemImgs
        {
            public Guna2ImageButton img = new Guna2ImageButton();
            public static string loadpic = "monkey.png";
            public string text;
            public static int xProblm = 721;
            public static int yProblm = 114;
            public ProblemImgs(string text)
            {
                this.text = text;
                img.Image = Image.FromFile(loadpic);
                img.Location = new Point(xProblm, yProblm);
                img.Size = new Size(64, 64);
                img.Click += (sender, e) => guna2ImageButton_Click(text);
                yProblm += 120;
            }
            static private void guna2ImageButton_Click(string t)
            {
                MessageBox.Show(t);
            }
        }
        public Form3()
        {
            InitializeComponent();
            //проверка на админа
            guna2Button1.Visible = Form1.role;
            LoadDataToDataGridView(dataGridView1);
            if (dataTable.Rows.Count != 0)
            {
                pictureBox1.Image = Image.FromFile(dataTable.Rows[0]["image"].ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                label1.Text = dataTable.Rows[0]["title"].ToString();
                label1.Font = new Font("Impact", 18, FontStyle.Italic);//14
                int xImg = pictureBox1.Location.X, yImg = pictureBox1.Location.Y;//26 104
                int xLbl = label1.Location.X, yLbl = label1.Location.Y;//259 139
                int yLbl2 = label2.Location.Y;//140
                int yLbl3 = label3.Location.Y;//175
                int yPanel = panel1.Location.Y;
                //int xProblm = guna2ImageButton1.Location.X, yProblm = guna2ImageButton1.Location.Y;//695 104
                ProblemImgs.xProblm = guna2ImageButton1.Location.X; ProblemImgs.yProblm = guna2ImageButton1.Location.Y;//104cu
                PictureBox[] Imgs = new PictureBox[dataTable.Rows.Count];
                Imgs[0] = pictureBox1;
                Label[] Lbls = new Label[dataTable.Rows.Count];
                Lbls[0] = label1;
                ProblemImgs[] descriptions = new ProblemImgs[dataTable.Rows.Count];
                descriptions[0] = new ProblemImgs(dataTable.Rows[0]["description"].ToString()) { img = guna2ImageButton1 };
                for (int i = 1; i < dataTable.Rows.Count; i++)
                {
                    yImg += 120; yLbl += 120; yLbl2 += 120; yLbl3 += 120; yPanel += 120;
                    //названия
                    Lbls[i] = new Label();
                    Lbls[i].Text = dataTable.Rows[i]["title"].ToString();
                    Lbls[i].Location = new Point(xLbl, yLbl);
                    Lbls[i].AutoSize = true;
                    Lbls[i].Font = new Font("Impact", 18, FontStyle.Italic);//12
                    this.Controls.Add(Lbls[i]);

                    //кол-во раз и отдых
                    Label label = new Label();
                    label.Text = label2.Text;
                    label.Location = new Point(label2.Location.X, yLbl2);
                    label.AutoSize = true;
                    label.Font = /*new Font("Impact", 9.75f, FontStyle.Italic)*/label2.Font;
                    label.ForeColor = Color.DimGray;
                    Label label1 = new Label();
                    label1.Text = label3.Text;
                    label1.Location = new Point(label3.Location.X, yLbl3);
                    label1.AutoSize = true;
                    label1.Font = /*new Font("Impact", 9.75f, FontStyle.Italic)*/label3.Font;
                    label1.ForeColor = Color.DimGray;
                    this.Controls.Add(label);
                    this.Controls.Add(label1);

                    //картинки
                    Imgs[i] = new PictureBox();
                    Imgs[i].Image = Image.FromFile(dataTable.Rows[i]["image"].ToString());
                    Imgs[i].Location = new Point(xImg, yImg);
                    Imgs[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    Imgs[i].Size = /*new Size(173, 86)*/pictureBox1.Size;
                    Imgs[i].Visible = true;
                    Imgs[i].Enabled = true;
                    this.Controls.Add(Imgs[i]);

                    //разделительная полоса
                    Panel linePanel = new Panel();
                    linePanel.Width = panel1.Width; // Задайте ширину линии
                    linePanel.Height = panel1.Height; // Задайте высоту линии
                    linePanel.BackColor = panel1.BackColor; // Задайте цвет линии
                    linePanel.Location = new Point(panel1.Location.X, yPanel); // Задайте координаты X и Y
                    this.Controls.Add(linePanel);

                    //нужно создать класс с ProblemImgs и текстом
                    descriptions[i] = new ProblemImgs(dataTable.Rows[i]["description"].ToString());
                    this.Controls.Add(descriptions[i].img);
                }
                guna2HtmlLabel1.Text = $"Тренировка \u200B<br>{Form2.titleOfTrening}";
                if (Form2.favoritesString.Contains(Form2.IdCategory))
                {
                    guna2CirclePictureBox2.Image = Image.FromFile("newstar.png");
                }
                else
                {
                    guna2CirclePictureBox2.Image = Image.FromFile("oldstar.png");
                }
            }
            else
            {
                label1.Text = "Нет упражнений";
                guna2ImageButton1.Enabled = false;
                guna2CirclePictureBox2.Enabled = false;
            }
        }
        public void LoadDataToDataGridView(DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();
                //замена категории
                string query = $"SELECT * FROM Exercises WHERE [id category] = '{Form2.IdCategory}'";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(dataTable);

                        dataGridView.DataSource = dataTable;
                    }
                }
            }
            //using (OleDbConnection connection = new OleDbConnection(connectString))//неработает
            //{
            //    connection.Open();
            //    string query = $"SELECT * FROM Exercises WHERE [id category] = '{Form2.IdCategory}'";

            //    using (OleDbCommand command = new OleDbCommand(query, connection))
            //    {
            //        using (dataAdapter = new OleDbDataAdapter(command))
            //        {
            //            // Создаем объект OleDbCommandBuilder для автоматической генерации команд обновления данных
            //            commandBuilder = new OleDbCommandBuilder(dataAdapter);

            //            dataAdapter.Fill(dataTable);
            //            dataGridView.DataSource = dataTable;
            //        }
            //    }
            //}
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(dataTable.Rows[0]["description"].ToString());
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form2().Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)//неработает
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form4(dataTable).Show();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Form2.favoritesString == null ? "Это нул" : "это не нул");
            if (!Form2.favoritesString.Contains(Form2.IdCategory) && Form2.favoritesString != "")
            {
                string updateQuery = "UPDATE Persons SET Favorites = Favorites  + @NewFavorite + ' ' WHERE [Login] = @Login";

                using (OleDbConnection dbConnection = new OleDbConnection(Form3.connectString))
                {
                    dbConnection.Open();
                    using (OleDbCommand command = new OleDbCommand(updateQuery, dbConnection))
                    {
                        command.Parameters.AddWithValue("@NewFavorite", Form2.IdCategory);
                        command.Parameters.AddWithValue("@Login", Form1.login);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.Close();
                }
                guna2CirclePictureBox2.Image = Image.FromFile("newstar.png");
            }
            else if (Form2.favoritesString == "")
            {
                string updateQuery = "UPDATE Persons SET Favorites = @Favorites + ' ' WHERE [Login] = @Login";

                using (OleDbConnection dbConnection = new OleDbConnection(Form3.connectString))
                {
                    dbConnection.Open();
                    using (OleDbCommand command = new OleDbCommand(updateQuery, dbConnection))
                    {
                        command.Parameters.AddWithValue("@NewFavorite", Form2.IdCategory);
                        command.Parameters.AddWithValue("@Login", Form1.login);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.Close();
                }
                guna2CirclePictureBox2.Image = Image.FromFile("newstar.png");
            }
            else//fix
            {
                string updateQuery = "UPDATE Persons SET Favorites = REPLACE(Favorites, @CategoryToRemove, '') WHERE [Login] = @Login";

                using (OleDbConnection dbConnection = new OleDbConnection(Form3.connectString))
                {
                    dbConnection.Open();
                    using (OleDbCommand command = new OleDbCommand(updateQuery, dbConnection))
                    {
                        command.Parameters.AddWithValue("@CategoryToRemove", Form2.IdCategory + ' ');
                        command.Parameters.AddWithValue("@Login", Form1.login);
                        command.ExecuteNonQuery();
                    }
                    dbConnection.Close();
                }
                guna2CirclePictureBox2.Image = Image.FromFile("oldstar.png");
            }
            //заполнение favoritesString
            string selectQuery = "SELECT Favorites FROM Persons WHERE [Login] = @Login";
            using (OleDbConnection dbConnection = new OleDbConnection(Form3.connectString))
            {
                dbConnection.Open();
                using (OleDbCommand command = new OleDbCommand(selectQuery, dbConnection))
                {
                    command.Parameters.AddWithValue("@Login", Form1.login);
                    object? result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        Form2.favoritesString = result.ToString();
                    }
                }
                dbConnection.Close();
            }
        }
    }
}