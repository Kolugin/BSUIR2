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
    public partial class Form1 : Form
    {
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\ProjectDB.mdb";
        int NPEnter = 0;
        string a = "";
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadDB()
        {
            dbCon = new OleDbConnection(ConS);
            dbCon.Open();
            using (dbCon)
            {
                try
                {
                    OleDbDataAdapter da1 = new OleDbDataAdapter(a, dbCon);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    dataGridView1.DataSource = dt1;
                }
                catch(Exception e)
                {
                    MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(e), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dbCon.Close();
        }
        private void Form1_Load(object sender, EventArgs e) // загрузка формы
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 60000;
            menuStrip1.Visible = false;
            dataGridView1.Visible = false;
            panel1.Visible = true;
            label1.Text = "Введите логин";
            label2.Text = "Введите пароль";
            button1.Text = "Вход";
            button2.Text = "Очистить";
            button3.Text = "Выход";
            textBox1.Text = "Введите ваш логин";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Введите ваш пароль";
            textBox2.ForeColor = Color.Gray;
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
            textBox2.UseSystemPasswordChar = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (NPEnter >= 5)
            {
                MessageBox.Show("Попыток входа было не менее 5! Попробуйте войти через 1 минуту!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NPEnter = 0;
                button1.Enabled = false;
                timer1.Start();
            }
           
            if ((textBox1.Text != "" && textBox2.Text !="")&&(textBox1.ForeColor == Color.Black && textBox2.ForeColor == Color.Black))
            {
                string s1 = textBox1.Text;
                string s2 = textBox2.Text;
                string q = "SELECT COUNT(*) FROM Users WHERE (Login = \"" + s1 + "\" AND Password = \"" + s2 + "\")";
                string q2 = "SELECT Type_Access FROM Users WHERE (Login = \"" + s1 + "\" AND Password = \"" + s2 + "\")";
                if (textBox1.Text != textBox2.Text && (textBox1.ForeColor == Color.Black && textBox2.ForeColor == Color.Black))
                {
                    try
                    {
                        dbCon = new OleDbConnection(ConS);
                        dbCon.Open();
                        using (dbCon)
                        {
                            OleDbCommand com = new OleDbCommand(q, dbCon);
                            string res = com.ExecuteScalar().ToString();
                            com.ExecuteNonQuery();
                            if (res != "0")
                            {
                                OleDbCommand com2 = new OleDbCommand(q2, dbCon);
                                string res2 = com2.ExecuteScalar().ToString();
                                com2.ExecuteNonQuery();
                                if (res2 == "ADMIN")
                                {
                                    MessageBox.Show("Добро пожаловать! ADMIN.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //MessageBox.Show(res2, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    panel1.Visible = false;
                                    panel1.Enabled = false;
                                    menuStrip1.Visible = true;
                                    dataGridView1.Visible = true;
                                    пользователиToolStripMenuItem.Visible = true;
                                    пользователиToolStripMenuItem.Enabled = true;
                                    новыйПользовательToolStripMenuItem.Visible = true;
                                    новыйПользовательToolStripMenuItem.Enabled = true;
                                    return;
                                }
                                if (res2 == "USER")
                                {
                                    MessageBox.Show("Добро пожаловать! USER.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    panel1.Visible = false;
                                    panel1.Enabled = false;
                                    menuStrip1.Visible = true;
                                    dataGridView1.Visible = true;
                                    пользователиToolStripMenuItem.Visible = false;
                                    пользователиToolStripMenuItem.Enabled = false;
                                    новыйПользовательToolStripMenuItem.Visible = false;
                                    новыйПользовательToolStripMenuItem.Enabled = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Логин и Пароль введены неверно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox1.Text = "";
                                textBox2.Text = "";
                                if (textBox1.Text == "")
                                {
                                    MessageBox.Show("Введите Логин", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                if (textBox2.Text == "")
                                {
                                    MessageBox.Show("Введите пароль", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                return;
                            }
                        }
                        dbCon.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка соединения с БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (textBox1.Text == textBox2.Text && (textBox1.ForeColor == Color.Black && textBox2.ForeColor == Color.Black))
                {
                    MessageBox.Show("Логин и пароль не могут совпадать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NPEnter++;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    return;
                }
            }
            if (textBox1.Text == textBox2.Text && (textBox1.ForeColor == Color.Black && textBox2.ForeColor == Color.Black))
            {
                MessageBox.Show("Логин и пароль не могут совпадать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NPEnter++;
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NPEnter = 0;
            timer1.Stop();
            button1.Enabled = true;
        }
        //---------------------------------------------------------------------------------------------------------------
        private void бюджетыToolStripMenuItem_Click(object sender, EventArgs e)//отобразить список бюджетов
        {
           a = @"SELECT * FROM Budjet";
           LoadDB();
        }

        private void проектыToolStripMenuItem_Click(object sender, EventArgs e)//отобразить список проектов
        {
            a = @"SELECT * FROM Projects";
            LoadDB();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)//отобразить список пользователей
        {
            a = @"SELECT * FROM Users";
            LoadDB();
        }

        private void рабочиеToolStripMenuItem_Click(object sender, EventArgs e)//отобразить список рабочих
        {
            a = @"SELECT * FROM Worker";
            LoadDB();
        }

        private void работыToolStripMenuItem_Click(object sender, EventArgs e) //отобразить список работ
        {
            a = @"SELECT * FROM Jobs";
            LoadDB();
        }
        //-----------------------------------------------------------------------------------------------------------
        private void новыйПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void новыйРабочийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void новаяРаботаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void новыйПользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }
        //------------------------------------------------------------------------------------------------------------
        private void связьМеждуРабочимИПроектомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void новуюСтатьюБюджетаПроектаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form7 form7 = new Form7();
            //form7.Show();
        }

        private void сменаПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
            menuStrip1.Visible = false;
            dataGridView1.Visible = false;
            label1.Text = "Введите логин";
            label2.Text = "Введите пароль";
            button1.Text = "Вход";
            button2.Text = "Очистить";
            button3.Text = "Выход";
            textBox1.Text = "Введите ваш логин";
            textBox1.ForeColor = Color.Gray;
            textBox2.Text = "Введите ваш пароль";
            textBox2.ForeColor = Color.Gray;
            textBox2.UseSystemPasswordChar = false;
        }

        private void посчитатьБюджетToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
