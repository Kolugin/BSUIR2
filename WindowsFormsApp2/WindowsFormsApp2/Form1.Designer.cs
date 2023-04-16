namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.отобразитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бюджетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рабочиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйПроектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйРабочийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяРаботаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйПользовательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.связьМеждуРабочимИПроектомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новуюСтатьюБюджетаПроектаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информациюПоПроектуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сменаПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отобразитьToolStripMenuItem,
            this.добавитьToolStripMenuItem,
            this.сформироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.расчетToolStripMenuItem,
            this.сменаПользователяToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отобразитьToolStripMenuItem
            // 
            this.отобразитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бюджетыToolStripMenuItem,
            this.проектыToolStripMenuItem,
            this.пользователиToolStripMenuItem,
            this.рабочиеToolStripMenuItem,
            this.работыToolStripMenuItem});
            this.отобразитьToolStripMenuItem.Name = "отобразитьToolStripMenuItem";
            this.отобразитьToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.отобразитьToolStripMenuItem.Text = "Отобразить";
            // 
            // бюджетыToolStripMenuItem
            // 
            this.бюджетыToolStripMenuItem.Name = "бюджетыToolStripMenuItem";
            this.бюджетыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.бюджетыToolStripMenuItem.Text = "Бюджеты";
            this.бюджетыToolStripMenuItem.Click += new System.EventHandler(this.бюджетыToolStripMenuItem_Click);
            // 
            // проектыToolStripMenuItem
            // 
            this.проектыToolStripMenuItem.Name = "проектыToolStripMenuItem";
            this.проектыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.проектыToolStripMenuItem.Text = "Проекты";
            this.проектыToolStripMenuItem.Click += new System.EventHandler(this.проектыToolStripMenuItem_Click);
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            this.пользователиToolStripMenuItem.Click += new System.EventHandler(this.пользователиToolStripMenuItem_Click);
            // 
            // рабочиеToolStripMenuItem
            // 
            this.рабочиеToolStripMenuItem.Name = "рабочиеToolStripMenuItem";
            this.рабочиеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.рабочиеToolStripMenuItem.Text = "Рабочие";
            this.рабочиеToolStripMenuItem.Click += new System.EventHandler(this.рабочиеToolStripMenuItem_Click);
            // 
            // работыToolStripMenuItem
            // 
            this.работыToolStripMenuItem.Name = "работыToolStripMenuItem";
            this.работыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.работыToolStripMenuItem.Text = "Работы";
            this.работыToolStripMenuItem.Click += new System.EventHandler(this.работыToolStripMenuItem_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйПроектToolStripMenuItem,
            this.новыйРабочийToolStripMenuItem,
            this.новаяРаботаToolStripMenuItem,
            this.новыйПользовательToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // новыйПроектToolStripMenuItem
            // 
            this.новыйПроектToolStripMenuItem.Name = "новыйПроектToolStripMenuItem";
            this.новыйПроектToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.новыйПроектToolStripMenuItem.Text = "Новый проект";
            this.новыйПроектToolStripMenuItem.Click += new System.EventHandler(this.новыйПроектToolStripMenuItem_Click);
            // 
            // новыйРабочийToolStripMenuItem
            // 
            this.новыйРабочийToolStripMenuItem.Name = "новыйРабочийToolStripMenuItem";
            this.новыйРабочийToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.новыйРабочийToolStripMenuItem.Text = "Новый рабочий";
            this.новыйРабочийToolStripMenuItem.Click += new System.EventHandler(this.новыйРабочийToolStripMenuItem_Click);
            // 
            // новаяРаботаToolStripMenuItem
            // 
            this.новаяРаботаToolStripMenuItem.Name = "новаяРаботаToolStripMenuItem";
            this.новаяРаботаToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.новаяРаботаToolStripMenuItem.Text = "Новая работа";
            this.новаяРаботаToolStripMenuItem.Click += new System.EventHandler(this.новаяРаботаToolStripMenuItem_Click);
            // 
            // новыйПользовательToolStripMenuItem
            // 
            this.новыйПользовательToolStripMenuItem.Name = "новыйПользовательToolStripMenuItem";
            this.новыйПользовательToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.новыйПользовательToolStripMenuItem.Text = "Новый Пользователь";
            this.новыйПользовательToolStripMenuItem.Click += new System.EventHandler(this.новыйПользовательToolStripMenuItem_Click);
            // 
            // сформироватьToolStripMenuItem
            // 
            this.сформироватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.связьМеждуРабочимИПроектомToolStripMenuItem,
            this.новуюСтатьюБюджетаПроектаToolStripMenuItem,
            this.информациюПоПроектуToolStripMenuItem});
            this.сформироватьToolStripMenuItem.Name = "сформироватьToolStripMenuItem";
            this.сформироватьToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.сформироватьToolStripMenuItem.Text = "Сформировать";
            // 
            // связьМеждуРабочимИПроектомToolStripMenuItem
            // 
            this.связьМеждуРабочимИПроектомToolStripMenuItem.Name = "связьМеждуРабочимИПроектомToolStripMenuItem";
            this.связьМеждуРабочимИПроектомToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.связьМеждуРабочимИПроектомToolStripMenuItem.Text = "Связь между рабочим и проектом";
            this.связьМеждуРабочимИПроектомToolStripMenuItem.Click += new System.EventHandler(this.связьМеждуРабочимИПроектомToolStripMenuItem_Click);
            // 
            // новуюСтатьюБюджетаПроектаToolStripMenuItem
            // 
            this.новуюСтатьюБюджетаПроектаToolStripMenuItem.Name = "новуюСтатьюБюджетаПроектаToolStripMenuItem";
            this.новуюСтатьюБюджетаПроектаToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.новуюСтатьюБюджетаПроектаToolStripMenuItem.Text = "Новую статью бюджета проекта";
            this.новуюСтатьюБюджетаПроектаToolStripMenuItem.Click += new System.EventHandler(this.новуюСтатьюБюджетаПроектаToolStripMenuItem_Click);
            // 
            // информациюПоПроектуToolStripMenuItem
            // 
            this.информациюПоПроектуToolStripMenuItem.Name = "информациюПоПроектуToolStripMenuItem";
            this.информациюПоПроектуToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.информациюПоПроектуToolStripMenuItem.Text = "Информацию по проекту";
            this.информациюПоПроектуToolStripMenuItem.Click += new System.EventHandler(this.информациюПоПроектуToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // расчетToolStripMenuItem
            // 
            this.расчетToolStripMenuItem.Name = "расчетToolStripMenuItem";
            this.расчетToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.расчетToolStripMenuItem.Text = "Расчет";
            this.расчетToolStripMenuItem.Click += new System.EventHandler(this.расчетToolStripMenuItem_Click);
            // 
            // сменаПользователяToolStripMenuItem
            // 
            this.сменаПользователяToolStripMenuItem.Name = "сменаПользователяToolStripMenuItem";
            this.сменаПользователяToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.сменаПользователяToolStripMenuItem.Text = "Смена пользователя";
            this.сменаПользователяToolStripMenuItem.Click += new System.EventHandler(this.сменаПользователяToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(501, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 626);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(537, 282);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(456, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(375, 247);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(237, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(375, 202);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1880, 973);
            this.dataGridView1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Проекты";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem отобразитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бюджетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рабочиеToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem работыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйПроектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйРабочийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяРаботаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem связьМеждуРабочимИПроектомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новуюСтатьюБюджетаПроектаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйПользовательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сменаПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информациюПоПроектуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расчетToolStripMenuItem;
    }
}

