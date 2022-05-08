using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EmployeeApp.Model;

namespace EmployeeApp
{
    public partial class ShowEmployee : Form
    {
        private TextBox[] textBoxes = new TextBox[10];
        List<Employee> employee = new List<Employee>();
        private static List<Appointment> allPositions { get; set; }
        private static List<Subdivision> allSubdivisions { get; set; }
        public ShowEmployee(IEnumerable<Employee> selectedEmployee)
        {
            InitializeComponent();

            kpiCB.DropDownStyle = ComboBoxStyle.DropDownList;
            PositionCB.DropDownStyle = ComboBoxStyle.DropDownList;

            MaximizeBox = false;

            textBoxes = new TextBox[] { idTB, firstNameTB, lastNameTB, 
                                        middleNameTb, phoneNumberTB, addressTB, 
                                        departmentTB, positionTB, salaryTB, kpiTB };

            idTB.Text = selectedEmployee.First().id.ToString();
            firstNameTB.Text = selectedEmployee.First().firstName;
            lastNameTB.Text = selectedEmployee.First().secondName;
            middleNameTb.Text = selectedEmployee.First().middleName;
            phoneNumberTB.Text = selectedEmployee.First().phoneNumber;
            addressTB.Text = selectedEmployee.First().address;
            departmentTB.Text = selectedEmployee.First().department;
            positionTB.Text = selectedEmployee.First().position;
            salaryTB.Text = selectedEmployee.First().salary.ToString();
            kpiTB.Text = selectedEmployee.First().kpi.ToString();

            employee.Add(selectedEmployee.First());

            foreach (var el in textBoxes)
            {
                el.ReadOnly = true;
            }
            saveBtn.Enabled = false;
            PositionCB.Enabled = false;

            Filter.LoadFromDBPositions(out List<Appointment> positions, out List<Subdivision> subdivisions);

            allPositions = positions;
            allSubdivisions = subdivisions;
        }
        public ShowEmployee()
        {
            allPositions = new List<Appointment>();
            allSubdivisions = new List<Subdivision>();

            InitializeComponent();
            kpiCB.DropDownStyle = ComboBoxStyle.DropDownList;
            PositionCB.DropDownStyle = ComboBoxStyle.DropDownList;
            MaximizeBox = false;

            manipulationTSMI.Visible = false;
            Text = "Форма добавления нового сотрудника";

            PositionCB.Visible = true;
            positionTB.Visible = false;
            
            Filter.LoadFromDBPositions(out List<Appointment> positions, out List<Subdivision> subdivisions);

            allPositions = positions;
            allSubdivisions = subdivisions;

            PositionCB.DataSource = positions.Select(p => p.position).ToList();
            
            departmentTB.ReadOnly = true;
            idTB.Visible = false;
            label1.Visible = false;

            phoneNumberTB.Text = "+380671110055";

            kpiCB.DataSource = new char[] { 'a', 'b', 'c' };
            kpiCB.Visible = true;
            kpiTB.Visible = false;
        }
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter.isEditToolStripMenuItemClick = true;
            Filter.positions.Clear();
            foreach (var el in textBoxes)
            {
                if(el == firstNameTB || el == lastNameTB || el == middleNameTb 
                    || el == phoneNumberTB || el == addressTB || el == salaryTB || el == kpiTB)
                    el.ReadOnly = false;
            }
            saveBtn.Enabled = true;
            Filter.LoadFromDBPositions();

            PositionCB.Enabled = true;
            positionTB.Visible = false;
            PositionCB.DataSource = Filter.positions;
            PositionCB.SelectedItem = employee.Select(p => p.position).First();

            kpiTB.Visible = false;
            kpiCB.DataSource = new char[] { 'a', 'b', 'c' };
            kpiCB.Text = kpiTB.Text;
            kpiCB.Visible = true;

            phoneNumberTB.Click -= OnFocusPhoneNumber;
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!Filter.isAddEmployee)
            {
                phoneNumberTB.Click += OnFocusPhoneNumber;
                double salary;
                char kpi;
                Employee dataEmployeeUpdated = new Employee(firstNameTB.Text, middleNameTb.Text, lastNameTB.Text
                                            , phoneNumberTB.Text, addressTB.Text, PositionCB.Text
                                            , double.TryParse(salaryTB.Text, out salary) ? salary : 0.0
                                            , char.TryParse(kpiCB.Text, out kpi) ? kpi : '\0');

                Filter.UpdateDBEmp(employee.Select(p => p.id).First(), dataEmployeeUpdated);
            }
            else
            {
                if (phoneNumberTB.Text.Length != 13)
                {
                    MessageBox.Show("Номер телефона не соответствует формату: '+380660001122'", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(firstNameTB.Text.Length == 0 || lastNameTB.Text.Length == 0 || middleNameTb.Text.Length == 0
                    || addressTB.Text.Length == 0 || PositionCB.Text.Length == 0)
                {
                    MessageBox.Show("Не все поля заполнены", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                char kpi;
                try
                {
                    Filter.InsertDBEmp(firstNameTB.Text, middleNameTb.Text, lastNameTB.Text
                                     , phoneNumberTB.Text, addressTB.Text, PositionCB.Text
                                     , Convert.ToDouble(salaryTB.Text)
                                     , char.TryParse(kpiCB.Text, out kpi) ? kpi : '\0');
                }
                catch
                {
                    if (salaryTB.Text.Length > 0)
                    {
                        MessageBox.Show("Поле зарплаты не может содержать буквы"
                                      , "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        salaryTB.Focus();
                        return;
                    }
                    else
                    {
                        Filter.InsertDBEmp(firstNameTB.Text, middleNameTb.Text, lastNameTB.Text
                                         , phoneNumberTB.Text, addressTB.Text, PositionCB.Text
                                         , 0
                                         , char.TryParse(kpiCB.Text, out kpi) ? kpi : '\0');
                    }
                }
            }

            Filter.isAddEmployee = false;
            kpiCB.Visible = false;
            kpiTB.Visible = true;

            Close();
        }
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter.DeleteEmpFromDB(employee.Select(p => p.id).First());
            Close();
        }
        private void PositionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manipulationTSMI.Visible == false || Filter.isEditToolStripMenuItemClick)
            {
                var selectedPosition = allPositions.Where(p => p.position == PositionCB.Text);
                int idPosition = selectedPosition.Select(p => p.idSubdivision).First();

                int idDepartment = allSubdivisions.Where(p => p.id == idPosition).Select(p => p.id).First();

                Filter.isSearchByIdDepartment = true;
                Filter.LoadFromDBDepartments(out List<string> department, idDepartment);
                Filter.isSearchByIdDepartment = false;
                departmentTB.Text = department.First();
            }
        }
        private void OnFocusPhoneNumber(object sender, EventArgs e)
        {
            phoneNumberTB.Text = "";
        }
    }
}
