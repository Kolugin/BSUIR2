using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> Project = new List<string>();
        List<string> Workers = new List<string>();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // ОК
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                try
                {
                    dbCon = new OleDbConnection(ConS);
                    dbCon.Open();
                    using (dbCon)
                    {
                        string Query = "INSERT INTO Jobs (ID_Project, Name_Job, Time_Job, Cost_Job, ID_Worker) VALUES (@ID_Project, @Name_Job, @Time_Job, @Cost_Job, @ID_Worker)";
                        OleDbCommand com = new OleDbCommand(Query, dbCon);
                        com.Parameters.AddWithValue("@ID_Project", Convert.ToString(comboBox1.Text));
                        com.Parameters.AddWithValue("@Name_Job", Convert.ToString(textBox1.Text));
                        com.Parameters.AddWithValue("@Time_Job", Convert.ToDouble(textBox2.Text));
                        com.Parameters.AddWithValue("@Cost_Job", Convert.ToDouble(textBox3.Text));
                        com.Parameters.AddWithValue("@ID_Worker", Convert.ToString(comboBox2.Text));
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
                    MessageBox.Show("Введите Название Работы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите Количество часов на работу!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Введите Стоимость 1 часа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите ID Проекта!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Выберите ID Рабочего!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Form4_Load(object sender, EventArgs e) // Загрузка
        {
            try
            {
                dbCon = new OleDbConnection(ConS);
                dbCon.Open();
                using (dbCon)
                {
                    // чтение типов
                    OleDbCommand cmd = new OleDbCommand("SELECT ID_Project FROM Projects", dbCon);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Project.Add(reader.GetString(0));
                    }
                    reader.Close();

                    OleDbCommand cmd2 = new OleDbCommand("SELECT ID_Worker FROM Worker", dbCon);
                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        Workers.Add(reader2.GetString(0));
                    }
                    reader2.Close();
                }
                dbCon.Close();
            }
            catch (Exception g)
            {
                MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(g), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            comboBox1.DataSource = Project;
            comboBox2.DataSource = Workers;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
