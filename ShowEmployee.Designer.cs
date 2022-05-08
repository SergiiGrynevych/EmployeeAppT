
namespace EmployeeApp
{
    partial class ShowEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.idTB = new System.Windows.Forms.TextBox();
            this.firstNameTB = new System.Windows.Forms.TextBox();
            this.lastNameTB = new System.Windows.Forms.TextBox();
            this.middleNameTb = new System.Windows.Forms.TextBox();
            this.phoneNumberTB = new System.Windows.Forms.TextBox();
            this.addressTB = new System.Windows.Forms.TextBox();
            this.departmentTB = new System.Windows.Forms.TextBox();
            this.salaryTB = new System.Windows.Forms.TextBox();
            this.kpiTB = new System.Windows.Forms.TextBox();
            this.positionTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manipulationTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBtn = new System.Windows.Forms.Button();
            this.PositionCB = new System.Windows.Forms.ComboBox();
            this.kpiCB = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idTB
            // 
            this.idTB.Location = new System.Drawing.Point(13, 65);
            this.idTB.Name = "idTB";
            this.idTB.Size = new System.Drawing.Size(290, 20);
            this.idTB.TabIndex = 0;
            // 
            // firstNameTB
            // 
            this.firstNameTB.Location = new System.Drawing.Point(14, 104);
            this.firstNameTB.Name = "firstNameTB";
            this.firstNameTB.Size = new System.Drawing.Size(289, 20);
            this.firstNameTB.TabIndex = 1;
            // 
            // lastNameTB
            // 
            this.lastNameTB.Location = new System.Drawing.Point(14, 143);
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Size = new System.Drawing.Size(289, 20);
            this.lastNameTB.TabIndex = 2;
            // 
            // middleNameTb
            // 
            this.middleNameTb.Location = new System.Drawing.Point(14, 181);
            this.middleNameTb.Name = "middleNameTb";
            this.middleNameTb.Size = new System.Drawing.Size(289, 20);
            this.middleNameTb.TabIndex = 3;
            // 
            // phoneNumberTB
            // 
            this.phoneNumberTB.Location = new System.Drawing.Point(14, 220);
            this.phoneNumberTB.Name = "phoneNumberTB";
            this.phoneNumberTB.Size = new System.Drawing.Size(289, 20);
            this.phoneNumberTB.TabIndex = 4;
            this.phoneNumberTB.Click += new System.EventHandler(this.OnFocusPhoneNumber);
            // 
            // addressTB
            // 
            this.addressTB.Location = new System.Drawing.Point(332, 64);
            this.addressTB.Name = "addressTB";
            this.addressTB.Size = new System.Drawing.Size(289, 20);
            this.addressTB.TabIndex = 5;
            // 
            // departmentTB
            // 
            this.departmentTB.Location = new System.Drawing.Point(332, 103);
            this.departmentTB.Name = "departmentTB";
            this.departmentTB.Size = new System.Drawing.Size(289, 20);
            this.departmentTB.TabIndex = 6;
            // 
            // salaryTB
            // 
            this.salaryTB.Location = new System.Drawing.Point(332, 181);
            this.salaryTB.Name = "salaryTB";
            this.salaryTB.Size = new System.Drawing.Size(289, 20);
            this.salaryTB.TabIndex = 8;
            // 
            // kpiTB
            // 
            this.kpiTB.Location = new System.Drawing.Point(332, 220);
            this.kpiTB.Name = "kpiTB";
            this.kpiTB.Size = new System.Drawing.Size(289, 20);
            this.kpiTB.TabIndex = 9;
            // 
            // positionTB
            // 
            this.positionTB.Location = new System.Drawing.Point(332, 142);
            this.positionTB.Name = "positionTB";
            this.positionTB.ShortcutsEnabled = false;
            this.positionTB.Size = new System.Drawing.Size(289, 20);
            this.positionTB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Уникальный код";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Отчество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Телефон";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Адрес";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Отдел";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Должность";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(335, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Оклад";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "KPI";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manipulationTSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manipulationTSMI
            // 
            this.manipulationTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditTSMI,
            this.deleteTSMI});
            this.manipulationTSMI.Name = "manipulationTSMI";
            this.manipulationTSMI.Size = new System.Drawing.Size(96, 20);
            this.manipulationTSMI.Text = "Манипуляция";
            // 
            // EditTSMI
            // 
            this.EditTSMI.Name = "EditTSMI";
            this.EditTSMI.Size = new System.Drawing.Size(180, 22);
            this.EditTSMI.Text = "редактировать";
            this.EditTSMI.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // deleteTSMI
            // 
            this.deleteTSMI.Name = "deleteTSMI";
            this.deleteTSMI.Size = new System.Drawing.Size(180, 22);
            this.deleteTSMI.Text = "удалить";
            this.deleteTSMI.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(495, 291);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(126, 38);
            this.saveBtn.TabIndex = 21;
            this.saveBtn.Text = "сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // PositionCB
            // 
            this.PositionCB.FormattingEnabled = true;
            this.PositionCB.Location = new System.Drawing.Point(332, 142);
            this.PositionCB.Name = "PositionCB";
            this.PositionCB.Size = new System.Drawing.Size(289, 21);
            this.PositionCB.TabIndex = 22;
            this.PositionCB.SelectedIndexChanged += new System.EventHandler(this.PositionCB_SelectedIndexChanged);
            // 
            // kpiCB
            // 
            this.kpiCB.FormattingEnabled = true;
            this.kpiCB.Location = new System.Drawing.Point(332, 220);
            this.kpiCB.Name = "kpiCB";
            this.kpiCB.Size = new System.Drawing.Size(289, 21);
            this.kpiCB.TabIndex = 23;
            this.kpiCB.Visible = false;
            // 
            // ShowEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 341);
            this.Controls.Add(this.kpiCB);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kpiTB);
            this.Controls.Add(this.salaryTB);
            this.Controls.Add(this.positionTB);
            this.Controls.Add(this.departmentTB);
            this.Controls.Add(this.addressTB);
            this.Controls.Add(this.phoneNumberTB);
            this.Controls.Add(this.middleNameTb);
            this.Controls.Add(this.lastNameTB);
            this.Controls.Add(this.firstNameTB);
            this.Controls.Add(this.idTB);
            this.Controls.Add(this.PositionCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ShowEmployee";
            this.Text = "Полная информация об сотруднике";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idTB;
        private System.Windows.Forms.TextBox firstNameTB;
        private System.Windows.Forms.TextBox lastNameTB;
        private System.Windows.Forms.TextBox middleNameTb;
        private System.Windows.Forms.TextBox phoneNumberTB;
        private System.Windows.Forms.TextBox addressTB;
        private System.Windows.Forms.TextBox departmentTB;
        private System.Windows.Forms.TextBox salaryTB;
        private System.Windows.Forms.TextBox kpiTB;
        private System.Windows.Forms.TextBox positionTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manipulationTSMI;
        private System.Windows.Forms.ToolStripMenuItem EditTSMI;
        private System.Windows.Forms.ToolStripMenuItem deleteTSMI;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox PositionCB;
        private System.Windows.Forms.ComboBox kpiCB;
    }
}