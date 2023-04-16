using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form7 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> Data = new List<string>();
        List<string> Data2 = new List<string>();
        string a = "";
        int s = 0;
        public Form7()
        {
            InitializeComponent();
        }

        public void LOAD_DB()// загрузка
        {
            label1.Show();
            comboBox1.Show();
            button7.Show();
            Data.Clear();
            dbCon = new OleDbConnection(ConS);
            dbCon.Open();
            using (dbCon)
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand(a, dbCon);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Data.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(e), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            dbCon.Close();
            comboBox1.DataSource = Data2;
            comboBox1.DataSource = Data;
        }

        private void Form7_Load(object sender, EventArgs e) // Загрузка формы
        {
            label1.Hide();
            comboBox1.Hide();
            button7.Hide();
        }

        private void button1_Click(object sender, EventArgs e) // Удаление пользователя
        {
            label1.Text = "Выберите Пользователя";
            a = "SELECT Log FROM Users";
            LOAD_DB();
            s = 1;
        }

        private void button2_Click(object sender, EventArgs e) // Удаление рабочего
        {
            label1.Text = "Выберите Рабочего";
            a = "SELECT ID_Worker FROM Worker";
            LOAD_DB();
            s = 2;
        }

        private void button3_Click(object sender, EventArgs e) // Удалить статью
        {
            label1.Text = "Выберите Статью";
            a = "SELECT N_Doc_Budjet FROM Budjet";
            LOAD_DB();
            s = 3;
        }
        private void button7_Click(object sender, EventArgs e)// Удаление
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить данную информацию?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                a = comboBox1.Text.ToString();
                dbCon = new OleDbConnection(ConS);
                dbCon.Open();
                using (dbCon)
                {
                    try
                    {
                        if (s == 1)
                        {
                            string Query = "DELETE FROM Users WHERE Log = @Log";
                            OleDbCommand com = new OleDbCommand(Query, dbCon);
                            com.Parameters.AddWithValue("@Log", a);
                            com.ExecuteNonQuery();
                        }
                        if (s == 2)
                        {
                            string Query = "DELETE FROM Worker WHERE ID_Worker = @ID_Worker";
                            OleDbCommand com = new OleDbCommand(Query, dbCon);
                            com.Parameters.AddWithValue("@ID_Worker", a);
                            com.ExecuteNonQuery();
                        }
                        if (s == 3)
                        {
                            string Query = "DELETE FROM Budjet WHERE N_Doc_Budjet = @N_Doc_Budjet";
                            OleDbCommand com = new OleDbCommand(Query, dbCon);
                            com.Parameters.AddWithValue("@N_Doc_Budjet", a);
                            com.ExecuteNonQuery();
                        }
                        MessageBox.Show("Информация успешно удалена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                    catch (Exception g)
                    {
                        MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(g), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                dbCon.Close();
            }
            else
            {
                return;
            }
        }
    }
}
