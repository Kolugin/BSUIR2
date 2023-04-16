using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> Types = new List<string>();
        public Form2()
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
                        string Query = "INSERT INTO Projects (ID_Project, Name_Project, Type_Project, Date_Start, Date_End, Desc_Project) VALUES (@ID_Project, @Name_Project, @Type_Project, @Date_Start, @Date_End, @Desc_Project)";
                        OleDbCommand com = new OleDbCommand(Query, dbCon);
                        com.Parameters.AddWithValue("@ID_Project", Convert.ToString(textBox1.Text));
                        com.Parameters.AddWithValue("@Name_Project", Convert.ToString(textBox2.Text));
                        com.Parameters.AddWithValue("@Type_Project", Convert.ToString(comboBox1.Text));
                        com.Parameters.AddWithValue("@Date_Start", Convert.ToString(dateTimePicker1.Text));
                        com.Parameters.AddWithValue("@Date_End", Convert.ToString(dateTimePicker2.Text));
                        com.Parameters.AddWithValue("@Desc_Project", Convert.ToString(textBox3.Text));
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
                    MessageBox.Show("Введите ID Проекта", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите Название Проекта", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите Тип Проекта", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void Form2_Load(object sender, EventArgs e) // Загрузка
        {
            try
            {
                dbCon = new OleDbConnection(ConS);
                dbCon.Open();
                using (dbCon)
                {
                    // чтение типов
                    OleDbCommand cmd = new OleDbCommand("SELECT Type_Project FROM Projects", dbCon);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Types.Add(reader.GetString(0));
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
            comboBox1.DataSource = Types;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }
    }
}
