using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        // изменить данные к БД!
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> User = new List<string>();
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // ОК
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    dbCon = new OleDbConnection(ConS);
                    dbCon.Open();
                    using (dbCon)
                    {
                        string Query = "INSERT INTO Users (Log, Pass, Type_Access) VALUES (@Log, @Pass, @Type_Access)";
                        OleDbCommand com = new OleDbCommand(Query, dbCon);
                        com.Parameters.AddWithValue("@Log", Convert.ToString(textBox1.Text));
                        com.Parameters.AddWithValue("@Pass", Convert.ToString(textBox2.Text));
                        com.Parameters.AddWithValue("@Type_Access", Convert.ToString(comboBox1.Text));
                        com.ExecuteNonQuery();
                    }
                    dbCon.Close();
                    MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                catch (Exception g)
                {
                    MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(g), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Введите Логин!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите Пароль!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите Тип авторизации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Отмена
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form5_Load(object sender, EventArgs e) // Загрузка
        {
            try
            {
                dbCon = new OleDbConnection(ConS);
                dbCon.Open();
                using (dbCon)
                {
                    // чтение типов
                    OleDbCommand cmd = new OleDbCommand("SELECT Type_Access FROM Users", dbCon);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
                dbCon.Close();
            }
            catch (Exception g)
            {
                MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(g), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            comboBox1.DataSource = User;
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
