using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form6 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> Project = new List<string>();
        List<string> Workers = new List<string>();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // ОК
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                try
                {
                    dbCon = new OleDbConnection(ConS);
                    dbCon.Open();
                    using (dbCon)
                    {
                        string Query = "INSERT INTO ID_Work_Proj (ID_Worker, ID_Project) VALUES (@ID_Worker, @ID_Project)";
                        OleDbCommand com = new OleDbCommand(Query, dbCon);
                        com.Parameters.AddWithValue("@ID_Worker", Convert.ToString(comboBox1.Text));
                        com.Parameters.AddWithValue("@ID_Project", Convert.ToString(comboBox2.Text));
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
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите ID_Рабочего!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Выберите ID_Проекта", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void Form6_Load(object sender, EventArgs e) // Загрузка
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
            comboBox1.DataSource = Workers;
            comboBox2.DataSource = Project;
        }
    }
}
