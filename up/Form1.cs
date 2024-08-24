using System;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Management;

namespace up
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.mdb;";
        public OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
        }
        bool vhod = true;
        public static bool role;
        public static string? password;
        public static string? login;
        static bool ChechCharLogin(string s)
        {
            foreach (char c in s)
            {
                if (!(c >= 'A' && c <= 'Z') && !(c >= 'a' && c <= 'z'))
                {
                    return false;
                }
            }
            return true;

        }
        static bool ChechCharPassword(string s)
        {
            foreach (char c in s)
            {
                if (!(c >= 'A' && c <= 'Z') && !(c >= 'a' && c <= 'z') && !(c >= '0' && c <= '9'))
                {
                    return false;
                }
            }
            return true;
        }
        public void InsertPerson(string login, string password)
        {
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                string query = "INSERT INTO Persons (Login, [Password]) VALUES (@Login, @Password)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    command.ExecuteNonQuery();

                }
            }
        }
        public bool IsLoginExists(string login)
        {
            bool loginExists = false;

            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Persons WHERE Login = @Login";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        loginExists = true;
                    }
                }
            }

            return loginExists;
        }
        public bool IsLoginPasswordMatch(string login, string password)
        {
            bool match = false;

            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Persons WHERE Login = @Login AND [Password] = @Password";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        match = true;
                    }
                }
            }

            return match;
        }
        public bool AdminRole(string login)
        {
            bool role = false;
            string selectQuery = "SELECT Role FROM Persons WHERE Login = @Login";
            using (OleDbConnection dbConnection = new OleDbConnection(Form3.connectString))
            {
                dbConnection.Open();
                using (OleDbCommand command = new OleDbCommand(selectQuery, dbConnection))
                {
                    command.Parameters.AddWithValue("@Login", login);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = reader.GetBoolean(0);
                            // Используйте значение роли (role) по своему усмотрению
                            // Например, выведите его в консоль или сохраните в переменную для дальнейшего использования
                            //MessageBox.Show(role?"Админ":"Пользователь");
                        }
                        //else
                        //{
                        //    MessageBox.Show("Пользователь с логином {0} не найден.", login);
                        //}
                    }
                }
                dbConnection.Close();
            }
            return role;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            if (vhod)
            {
                label1.Text = "регистрация";
                button1.Text = "вход";
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox3.Visible = true;
                vhod = false;
            }
            else
            {
                label1.Text = "вход";
                button1.Text = "регистрация";
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox3.Visible = false;
                vhod = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vhod == false)
            {

                //if (textBox2.Text.Length >8) { MessageBox.Show("Слишком большой пароль, длина должна быть от 5 до 8 символов"); }
                if (textBox1.Text.Length < 3 || textBox1.Text.Length > 16) { MessageBox.Show("Логин не подходит по требованиям, длина должна быть от 3 до 16 символов"); }
                //проверка на символы
                else if (ChechCharLogin(textBox1.Text) == false)
                {
                    MessageBox.Show("Логин состоит не только из английских символов");
                }
                else
                {//*
                    login = textBox1.Text;
                    //}
                    if (textBox2.Text.Length < 5 || textBox2.Text.Length > 16) { MessageBox.Show("Пароль не подходит требованиям, длина должна быть от 5 до 16 символов"); }
                    //проверка на символы
                    else if (!ChechCharPassword(textBox2.Text))
                    {
                        MessageBox.Show("пароль состоит не только из английских символов");
                    }
                    else
                    {
                        password = textBox2.Text;
                        if (password != textBox3.Text)
                        {
                            MessageBox.Show("Неправильный повторный ввод пароля");
                        }
                        else
                        {
                            //try
                            //{
                            //    InsertPerson(login, password);
                            //    new Form2().Show();
                            //    this.Hide();
                            //}
                            //catch
                            //{
                            //    MessageBox.Show("Такой логин уже существует");
                            //}
                            if (IsLoginExists(textBox1.Text))
                            {
                                MessageBox.Show("Такой логин уже существует");
                            }
                            else
                            {
                                InsertPerson(textBox1.Text, password);
                                new Form2().Show();
                                this.Hide();
                            }
                        }
                    }
                }//*
            }
            else
            {
                //проверка существования логина
                if (IsLoginExists(textBox1.Text))
                {
                    //проверка пароля
                    if (IsLoginPasswordMatch(textBox1.Text, textBox2.Text))
                    {
                        login = textBox1.Text;
                        role = AdminRole(login);//проверка на админа
                        new Form2().Show();
                        this.Hide();
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Несуществует такого логина");
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}