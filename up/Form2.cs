using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace up
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            new Form1().Close();
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
                        favoritesString = result.ToString();
                    }
                }
                dbConnection.Close();
            }
        }
        public static string? titleOfTrening = "Выбранные упражнения";
        public static string? IdCategory;
        public static string? favoritesString = "";
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button5.Text + "\0";
            IdCategory = "гантели_бицепстрицепс";
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button2.Text + "\0";
            IdCategory = "гантели_ноги";
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button7.Text + "\0";
            IdCategory = "гантели_спинабицепс";
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button6.Text + "\0";
            IdCategory = "гантели_грудьтрицепс";
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button3.Text + "\0";
            IdCategory = "гантели_плечи";
            new Form3().Show();
            this.Hide();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button1.Text + "\0";
            IdCategory = "дома_пресс";
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button4.Text + "\0";
            IdCategory = "дома_грудь";
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button8.Text + "\0";
            IdCategory = "дома_ноги";
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button9.Text + "\0";
            IdCategory = "дома_руки";
            new Form3().Show();
            this.Hide();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            titleOfTrening = guna2Button10.Text + "\0";
            IdCategory = "дома_спина";
            //bool favorite = favoritesString.Contains(IdCategory);
            new Form3().Show();
            this.Hide();
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = true;
            guna2Button2.Visible = true;
            guna2Button3.Visible = true;
            guna2Button4.Visible = true;
            guna2Button5.Visible = true;
            guna2Button6.Visible = true;
            guna2Button7.Visible = true;
            guna2Button8.Visible = true;
            guna2Button9.Visible = true;
            guna2Button10.Visible = true;
        }

        private void избранныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!favoritesString.Contains("гантели_спинабицепс"))
            {
                guna2Button7.Visible = false;
            }
            if (!favoritesString.Contains("гантели_бицепстрицепс"))
            {
                guna2Button5.Visible = false;
            }
            if (!favoritesString.Contains("гантели_плечи"))
            {
                guna2Button3.Visible = false;
            }
            if (!favoritesString.Contains("гантели_грудьтрицепс"))
            {
                guna2Button6.Visible = false;
            }
            if (!favoritesString.Contains("гантели_ноги"))
            {
                guna2Button2.Visible = false;
            }
            if (!favoritesString.Contains("дома_пресс"))
            {
                guna2Button1.Visible = false;
            }
            if (!favoritesString.Contains("дома_руки"))
            {
                guna2Button9.Visible = false;
            }
            if (!favoritesString.Contains("дома_спина"))
            {
                guna2Button10.Visible = false;
            }
            if (!favoritesString.Contains("дома_грудь"))
            {
                guna2Button4.Visible = false;
            }
            if (!favoritesString.Contains("дома_ноги"))
            {
                guna2Button8.Visible = false;
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
