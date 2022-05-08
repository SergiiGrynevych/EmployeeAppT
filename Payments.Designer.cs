
namespace EmployeeApp
{
    partial class Payments
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
            this.PaymentsLB = new System.Windows.Forms.Label();
            this.SumLB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // PaymentsLB
            // 
            this.PaymentsLB.AutoSize = true;
            this.PaymentsLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.PaymentsLB.Location = new System.Drawing.Point(98, 96);
            this.PaymentsLB.Name = "PaymentsLB";
            this.PaymentsLB.Size = new System.Drawing.Size(284, 25);
            this.PaymentsLB.TabIndex = 0;
            this.PaymentsLB.Text = "Выплаты по всем отделам:";
            this.PaymentsLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SumLB
            // 
            this.SumLB.AutoSize = true;
            this.SumLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.SumLB.Location = new System.Drawing.Point(164, 137);
            this.SumLB.Name = "SumLB";
            this.SumLB.Size = new System.Drawing.Size(129, 39);
            this.SumLB.TabIndex = 1;
            this.SumLB.Text = "SumLB";
            this.SumLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "поиск по отделам";
            // 
            // searchCB
            // 
            this.searchCB.FormattingEnabled = true;
            this.searchCB.Location = new System.Drawing.Point(176, 38);
            this.searchCB.Name = "searchCB";
            this.searchCB.Size = new System.Drawing.Size(203, 21);
            this.searchCB.TabIndex = 5;
            this.searchCB.SelectedIndexChanged += new System.EventHandler(this.SearchCB_SelectedIndexChanged);
            // 
            // Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 240);
            this.Controls.Add(this.searchCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SumLB);
            this.Controls.Add(this.PaymentsLB);
            this.Name = "Payments";
            this.Text = "Выплаты";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PaymentsLB;
        private System.Windows.Forms.Label SumLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox searchCB;
    }
}