using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form9 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> ProjectID = new List<string>();
        string a = "";
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Отобразить
        {
            a = comboBox1.Text.ToString();
            dbCon = new OleDbConnection(ConS);
            dbCon.Open();
            using (dbCon)
            {
                try
                {
                    OleDbDataAdapter da1 = new OleDbDataAdapter(@"SELECT Projects.Name_Project, Projects.Type_Project, Projects.Date_Start, Projects.Date_End, Projects.Desc_Project FROM Projects WHERE Projects.ID_Project='" + a + "'", dbCon);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dataGridView1.DataSource = dt1;

                    OleDbDataAdapter da2 = new OleDbDataAdapter(@"SELECT Jobs.Name_Job, Jobs.Time_Job, Jobs.Cost_Job, Jobs.ID_Worker FROM Jobs WHERE Jobs.ID_Project='" + a + "'", dbCon);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    dataGridView2.DataSource = dt2;

                    OleDbDataAdapter da3 = new OleDbDataAdapter(@"SELECT Budjet.Budjet, Budjet.Type_Budjet, Budjet.Data_Budjet, Budjet.N_Doc_Budjet, Budjet.Desc_Budjet FROM Budjet WHERE Budjet.ID_Project='" + a + "'", dbCon);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    dataGridView3.DataSource = dt3;

                    dataGridView1.Columns[0].HeaderText = "Название Проекта";
                    dataGridView1.Columns[1].HeaderText = "Тип Проекта";
                    dataGridView1.Columns[2].HeaderText = "Дата начала";
                    dataGridView1.Columns[3].HeaderText = "Дата окончания";
                    dataGridView1.Columns[4].HeaderText = "Описание Проекта";

                    dataGridView2.Columns[0].HeaderText = "Имя Работы";
                    dataGridView2.Columns[1].HeaderText = "Время в часах";
                    dataGridView2.Columns[2].HeaderText = "Стоимость 1 часа";
                    dataGridView2.Columns[3].HeaderText = "ID Рабочего";

                    dataGridView3.Columns[0].HeaderText = "Сумма Бюджета";
                    dataGridView3.Columns[1].HeaderText = "Тип Бюджета";
                    dataGridView3.Columns[2].HeaderText = "Дата формирования";
                    dataGridView3.Columns[3].HeaderText = "№ Документа";
                    dataGridView3.Columns[4].HeaderText = "Описание Бюджета";

                }
                catch (Exception g)
                {
                    MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(g), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            dbCon.Close();

            MessageBox.Show("Информация найдена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            dataGridView1.Visible = true;
            dataGridView2.Visible = true;
            dataGridView3.Visible = true;
        }
        private void Form9_Load(object sender, EventArgs e)// Загрузка
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            try
            {
                dbCon = new OleDbConnection(ConS);
                dbCon.Open();
                using (dbCon)
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT ID_Project FROM Projects", dbCon);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProjectID.Add(reader.GetString(0));
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
            comboBox1.DataSource = ProjectID;
        }
    }
}
