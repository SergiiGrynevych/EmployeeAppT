using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeApp.Model;

namespace EmployeeApp
{
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
            Filter.LoadPayments(out double sumPayment, "");
            SumLB.Text = $"{sumPayment} UAH";

            Filter.LoadFromDBDepartments(out List<string> departments, 0);

            searchCB.DataSource = departments;

            searchCB.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void SearchCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter.LoadPayments(out double sumPayment, searchCB.Text);
            SumLB.Text = $"{sumPayment} UAH";
            
            if(searchCB.Text == "Все отделы")
            {
                PaymentsLB.Text = $"Выплаты по всем отделам:";
            }
            else
            {
                PaymentsLB.Text = $"Выплаты по отделу '{searchCB.Text}'";
            }
        }
    }
}
