using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form8 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> IDProject = new List<string>();
        List<string> Type = new List<string>();
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e) // загрузка
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
                        IDProject.Add(reader.GetString(0));
                    }
                    reader.Close();

                    OleDbCommand cmd2 = new OleDbCommand("SELECT Type_Budjet FROM Budjet", dbCon);
                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        Type.Add(reader2.GetString(0));
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
            comboBox1.DataSource = IDProject;
            comboBox2.DataSource = Type;
        }

        private void button1_Click(object sender, EventArgs e) // ОК
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                try
                {
                    dbCon = new OleDbConnection(ConS);
                    dbCon.Open();
                    using (dbCon)
                    {
                        string Query = "INSERT INTO Budjet (ID_Project, Budjet, Type_Budjet, Data_Budjet, N_Doc_Budjet, Desc_Budjet) VALUES (@ID_Project, @Budjet, @Type_Budjet, @Data_Budjet, @N_Doc_Budjet, @Desc_Budjet)";
                        OleDbCommand com = new OleDbCommand(Query, dbCon);
                        com.Parameters.AddWithValue("@ID_Project", Convert.ToString(comboBox1.Text));
                        com.Parameters.AddWithValue("@Budjet", Convert.ToDouble(textBox1.Text));
                        com.Parameters.AddWithValue("@Type_Budjet", Convert.ToString(comboBox2.Text));
                        com.Parameters.AddWithValue("@Data_Budjet", Convert.ToString(dateTimePicker1.Text));
                        com.Parameters.AddWithValue("@N_Doc_Budjet", Convert.ToString(textBox2.Text));
                        com.Parameters.AddWithValue("@Desc_Budjet", Convert.ToString(textBox3.Text));
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
                    MessageBox.Show("Введите число суммы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Введите № документа", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите ID Проекта!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Выберите Тип Бюджета", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
