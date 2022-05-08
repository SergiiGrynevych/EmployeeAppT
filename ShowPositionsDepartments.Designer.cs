
namespace EmployeeApp
{
    partial class ShowPositionsDepartments
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EditPisitionBTN = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.EditTB = new System.Windows.Forms.TextBox();
            this.AddBTN = new System.Windows.Forms.Button();
            this.NewPositionLB = new System.Windows.Forms.Label();
            this.positionAddTB = new System.Windows.Forms.TextBox();
            this.departmentsCB = new System.Windows.Forms.ComboBox();
            this.SelectPositionLB = new System.Windows.Forms.Label();
            this.SelectDepartmentLB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DeletePositionLB = new System.Windows.Forms.Label();
            this.departmentsTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(269, 425);
            this.dataGridView1.TabIndex = 0;
            // 
            // EditPisitionBTN
            // 
            this.EditPisitionBTN.Location = new System.Drawing.Point(387, 283);
            this.EditPisitionBTN.Name = "EditPisitionBTN";
            this.EditPisitionBTN.Size = new System.Drawing.Size(128, 23);
            this.EditPisitionBTN.TabIndex = 2;
            this.EditPisitionBTN.Text = "Редактировать";
            this.EditPisitionBTN.UseVisualStyleBackColor = true;
            this.EditPisitionBTN.Click += new System.EventHandler(this.EditPisitionBTN_Click);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Location = new System.Drawing.Point(387, 415);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(128, 23);
            this.DeleteBTN.TabIndex = 3;
            this.DeleteBTN.Text = "Удалить";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // EditTB
            // 
            this.EditTB.Location = new System.Drawing.Point(304, 257);
            this.EditTB.Name = "EditTB";
            this.EditTB.Size = new System.Drawing.Size(211, 20);
            this.EditTB.TabIndex = 4;
            // 
            // AddBTN
            // 
            this.AddBTN.Location = new System.Drawing.Point(387, 143);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(128, 23);
            this.AddBTN.TabIndex = 5;
            this.AddBTN.Text = "Добавить";
            this.AddBTN.UseVisualStyleBackColor = true;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // NewPositionLB
            // 
            this.NewPositionLB.AutoSize = true;
            this.NewPositionLB.Location = new System.Drawing.Point(301, 228);
            this.NewPositionLB.Name = "NewPositionLB";
            this.NewPositionLB.Size = new System.Drawing.Size(172, 26);
            this.NewPositionLB.TabIndex = 6;
            this.NewPositionLB.Text = "Выберите из списка должность \r\nи введите новую должность";
            // 
            // positionAddTB
            // 
            this.positionAddTB.Location = new System.Drawing.Point(304, 117);
            this.positionAddTB.Name = "positionAddTB";
            this.positionAddTB.Size = new System.Drawing.Size(208, 20);
            this.positionAddTB.TabIndex = 8;
            // 
            // departmentsCB
            // 
            this.departmentsCB.FormattingEnabled = true;
            this.departmentsCB.Location = new System.Drawing.Point(304, 77);
            this.departmentsCB.Name = "departmentsCB";
            this.departmentsCB.Size = new System.Drawing.Size(208, 21);
            this.departmentsCB.TabIndex = 9;
            // 
            // SelectPositionLB
            // 
            this.SelectPositionLB.AutoSize = true;
            this.SelectPositionLB.Location = new System.Drawing.Point(301, 101);
            this.SelectPositionLB.Name = "SelectPositionLB";
            this.SelectPositionLB.Size = new System.Drawing.Size(107, 13);
            this.SelectPositionLB.TabIndex = 10;
            this.SelectPositionLB.Text = "Введите должность";
            // 
            // SelectDepartmentLB
            // 
            this.SelectDepartmentLB.AutoSize = true;
            this.SelectDepartmentLB.Location = new System.Drawing.Point(301, 61);
            this.SelectDepartmentLB.Name = "SelectDepartmentLB";
            this.SelectDepartmentLB.Size = new System.Drawing.Size(126, 13);
            this.SelectDepartmentLB.TabIndex = 11;
            this.SelectDepartmentLB.Text = "Выберите департамент";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.Location = new System.Drawing.Point(337, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "ДОБАВЛЕНИЕ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.Location = new System.Drawing.Point(323, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "РЕДАКТИРОВАНИЕ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label6.Location = new System.Drawing.Point(351, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "УДАЛЕНИЕ";
            // 
            // DeletePositionLB
            // 
            this.DeletePositionLB.AutoSize = true;
            this.DeletePositionLB.Location = new System.Drawing.Point(301, 381);
            this.DeletePositionLB.Name = "DeletePositionLB";
            this.DeletePositionLB.Size = new System.Drawing.Size(178, 26);
            this.DeletePositionLB.TabIndex = 15;
            this.DeletePositionLB.Text = "Выберите позицию, которую\r\nхотите удалить и нажмите кнопку";
            // 
            // departmentsTB
            // 
            this.departmentsTB.Location = new System.Drawing.Point(304, 77);
            this.departmentsTB.Name = "departmentsTB";
            this.departmentsTB.Size = new System.Drawing.Size(208, 20);
            this.departmentsTB.TabIndex = 16;
            // 
            // ShowPositionsDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 450);
            this.Controls.Add(this.departmentsTB);
            this.Controls.Add(this.DeletePositionLB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SelectDepartmentLB);
            this.Controls.Add(this.SelectPositionLB);
            this.Controls.Add(this.departmentsCB);
            this.Controls.Add(this.positionAddTB);
            this.Controls.Add(this.NewPositionLB);
            this.Controls.Add(this.AddBTN);
            this.Controls.Add(this.EditTB);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.EditPisitionBTN);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ShowPositionsDepartments";
            this.Text = "Редактирование должностей";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button EditPisitionBTN;
        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.TextBox EditTB;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Label NewPositionLB;
        private System.Windows.Forms.TextBox positionAddTB;
        private System.Windows.Forms.ComboBox departmentsCB;
        private System.Windows.Forms.Label SelectPositionLB;
        private System.Windows.Forms.Label SelectDepartmentLB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label DeletePositionLB;
        private System.Windows.Forms.TextBox departmentsTB;
    }
}