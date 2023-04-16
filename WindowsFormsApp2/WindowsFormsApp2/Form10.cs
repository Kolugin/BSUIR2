using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form10 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        List<string> ProjectID = new List<string>();
        List<double> Budjet = new List<double>();
        List<double> TimeJ = new List<double>();
        List<double> CostJ = new List<double>();
        List<double> ResJ = new List<double>();
        string a = "";
        int i = 0;
        int j;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)// загрузка
        {
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

        private void button1_Click(object sender, EventArgs e)// расчет
        {
            a = comboBox1.Text.ToString();
            dbCon = new OleDbConnection(ConS);
            dbCon.Open();
            using (dbCon)
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT Budjet FROM Budjet WHERE Budjet.ID_Project='" + a + "'", dbCon);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Budjet.Add(reader.GetDouble(0));
                    }
                    reader.Close();
                }
                catch (Exception g)
                {
                    MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(g), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            dbCon.Close();
            MessageBox.Show("Остаток бюджета по выбранному проекту равен " +Budjet.Sum().ToString()+" бел.руб.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Budjet.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a = comboBox1.Text.ToString();
            dbCon = new OleDbConnection(ConS);
            dbCon.Open();
            using (dbCon)
            {
                try
                {
                    OleDbCommand cmd2 = new OleDbCommand("SELECT Time_Job FROM Jobs WHERE Jobs.ID_Project='" + a + "'", dbCon);
                    OleDbDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        TimeJ.Add(reader2.GetDouble(0));
                    }
                    reader2.Close();

                    OleDbCommand cmd3 = new OleDbCommand("SELECT Cost_Job FROM Jobs WHERE Jobs.ID_Project='" + a + "'", dbCon);
                    OleDbDataReader reader3 = cmd3.ExecuteReader();
                    while (reader3.Read())
                    {
                        CostJ.Add(reader3.GetDouble(0));
                    }
                    reader3.Close();
                }
                catch (Exception g)
                {
                    MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(g), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            dbCon.Close();
            for(i = 0; i<= TimeJ.Count-1; i++)
            {
                //MessageBox.Show()
                ResJ.Add(TimeJ[i] * CostJ[i]);
            }
            MessageBox.Show("Общие затраты на работы по проекту равны " + ResJ.Sum().ToString() + " бел.руб.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResJ.Clear();
            TimeJ.Clear();
            CostJ.Clear();
        }
    }
}
