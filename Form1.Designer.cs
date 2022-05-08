
namespace EmployeeApp
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchLabel = new System.Windows.Forms.Label();
            this.searchLab = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеОтделовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеДолжностейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСотрудникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выплатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.Size = new System.Drawing.Size(776, 366);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.DoubleClick);
            // 
            // searchLabel
            // 
            this.searchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(461, 9);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(91, 13);
            this.searchLabel.TabIndex = 1;
            this.searchLabel.Text = "Поиск по отделу";
            // 
            // searchLab
            // 
            this.searchLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLab.Location = new System.Drawing.Point(558, 6);
            this.searchLab.Name = "searchLab";
            this.searchLab.Size = new System.Drawing.Size(155, 20);
            this.searchLab.TabIndex = 2;
            this.searchLab.TextChanged += new System.EventHandler(this.Search_Click);
            // 
            // Search
            // 
            this.Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Search.Location = new System.Drawing.Point(719, 4);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(69, 23);
            this.Search.TabIndex = 3;
            this.Search.Text = "поиск";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактированиеОтделовToolStripMenuItem,
            this.редактированиеДолжностейToolStripMenuItem,
            this.добавитьСотрудникаToolStripMenuItem,
            this.выплатыToolStripMenuItem,
            this.отчетToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // редактированиеОтделовToolStripMenuItem
            // 
            this.редактированиеОтделовToolStripMenuItem.Name = "редактированиеОтделовToolStripMenuItem";
            this.редактированиеОтделовToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.редактированиеОтделовToolStripMenuItem.Text = "Редактировать отделы";
            this.редактированиеОтделовToolStripMenuItem.Click += new System.EventHandler(this.EditDepartmentsToolStripMenuItem_Click);
            // 
            // редактированиеДолжностейToolStripMenuItem
            // 
            this.редактированиеДолжностейToolStripMenuItem.Name = "редактированиеДолжностейToolStripMenuItem";
            this.редактированиеДолжностейToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.редактированиеДолжностейToolStripMenuItem.Text = "Редактировать должности";
            this.редактированиеДолжностейToolStripMenuItem.Click += new System.EventHandler(this.EditPositionsToolStripMenuItem_Click);
            // 
            // добавитьСотрудникаToolStripMenuItem
            // 
            this.добавитьСотрудникаToolStripMenuItem.Name = "добавитьСотрудникаToolStripMenuItem";
            this.добавитьСотрудникаToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.добавитьСотрудникаToolStripMenuItem.Text = "Добавить сотрудника";
            this.добавитьСотрудникаToolStripMenuItem.Click += new System.EventHandler(this.AddEmployeeToolStripMenuItem_Click);
            // 
            // выплатыToolStripMenuItem
            // 
            this.выплатыToolStripMenuItem.Name = "выплатыToolStripMenuItem";
            this.выплатыToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.выплатыToolStripMenuItem.Text = "Выплаты";
            this.выплатыToolStripMenuItem.Click += new System.EventHandler(this.PaymentsToolStripMenuItem_Click);
            // 
            // отчетToolStripMenuItem
            // 
            this.отчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelДокументToolStripMenuItem,
            this.txtДокументToolStripMenuItem});
            this.отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            this.отчетToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.отчетToolStripMenuItem.Text = "Отчет";
            // 
            // excelДокументToolStripMenuItem
            // 
            this.excelДокументToolStripMenuItem.Name = "excelДокументToolStripMenuItem";
            this.excelДокументToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.excelДокументToolStripMenuItem.Text = "excel документ";
            this.excelДокументToolStripMenuItem.Click += new System.EventHandler(this.ExcelDocumentToolStripMenuItem_Click);
            // 
            // txtДокументToolStripMenuItem
            // 
            this.txtДокументToolStripMenuItem.Name = "txtДокументToolStripMenuItem";
            this.txtДокументToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.txtДокументToolStripMenuItem.Text = "txt документ";
            this.txtДокументToolStripMenuItem.Click += new System.EventHandler(this.TxtDocumentToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.searchLab);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Список сотрудников";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.TextBox searchLab;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеОтделовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеДолжностейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСотрудникаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выплатыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtДокументToolStripMenuItem;
    }
}

