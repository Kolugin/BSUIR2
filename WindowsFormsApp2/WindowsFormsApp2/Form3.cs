using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> Worker = new List<string>();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // ок
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    dbCon = new OleDbConnection(ConS);
                    dbCon.Open();
                    using (dbCon)
                    {
                        string Query = "INSERT INTO Worker (ID_Worker, FIO_Worker, Prof_Worker) VALUES (@ID_Worker, @FIO_Worker, @Prof_Worker)";
                        OleDbCommand com = new OleDbCommand(Query, dbCon);
                        com.Parameters.AddWithValue("@ID_Worker", Convert.ToString(textBox1.Text));
                        com.Parameters.AddWithValue("@FIO_Worker", Convert.ToString(textBox2.Text));
                        com.Parameters.AddWithValue("@Prof_Worker", Convert.ToString(comboBox1.Text));
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
                    MessageBox.Show("Введите ID Рабочего!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите ФИО Рабочего!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите Профессию Рабочего!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Form3_Load(object sender, EventArgs e) // загрузка
        {
            try
            {
                dbCon = new OleDbConnection(ConS);
                dbCon.Open();
                using (dbCon)
                {
                    // чтение типов
                    OleDbCommand cmd = new OleDbCommand("SELECT Prof_Worker FROM Worker", dbCon);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Worker.Add(reader.GetString(0));
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
            comboBox1.DataSource = Worker;
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
