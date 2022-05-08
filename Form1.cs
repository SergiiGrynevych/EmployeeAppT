using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EmployeeApp.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace EmployeeApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ' ';
            Filter.LoadFromDBEmp();

            dataGridView1.DataSource = Filter.employees.Select(p => new { p.fullName //p.firstName, p.middleName, p.secondName
                                                                        , p.department
                                                                        , p.position, p.salary
                                                                        , p.kpi, p.premium }).ToList();
        }
        private void DoubleClick(object sender, EventArgs e)
        {
            string[] fullName;

            string firstName = "";
            string middleName = "";
            string secondName = "";

            string department = "";
            string position = "";
            double salary = 0;

            Person person;

            for (int i = 0; i <= 4; i++)
            {
                switch (i)
                {
                    case 0:

                        try { fullName = dataGridView1.CurrentRow.Cells[i].Value.ToString().Split(' '); }
                        catch { return; }

                        secondName = fullName[0];
                        firstName = fullName[1];
                        middleName = fullName[2];
                        break;
                    case 1:
                        department = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                        break;
                    case 2:
                        position = dataGridView1.CurrentRow.Cells[i].Value.ToString();
                        break;
                    case 3:
                        salary = Convert.ToDouble(dataGridView1.CurrentRow.Cells[i].Value);
                        break;
                    default:
                        break;
                }
            }

            person = new Person(firstName, middleName, secondName, department, position, salary);

            IEnumerable<Employee> selectedEmployee = Filter.employees.Where(p => p.firstName == person.firstName
                                                                             && p.middleName == person.middleName
                                                                             && p.secondName == person.secondName
                                                                             && p.department == person.department
                                                                             && p.position == person.position
                                                                             && p.salary == person.salary);

            ShowEmployee showEmployee = new ShowEmployee(selectedEmployee);
            showEmployee.ShowDialog();

            searchLab.Text = "";

            UpdateMainDataGrid();
        }
        private void Search_Click(object sender, EventArgs e)
        {
            if(searchLab.Text.Length > 0)
            {
                Filter.selectedDepartment += searchLab.Text;
                Filter.isSearchByFilter = true;
            }
            Filter.employees.Clear();
            Filter.LoadFromDBEmp();

            Filter.selectedDepartment = "";
            Filter.isSearchByFilter = false;

            dataGridView1.DataSource = Filter.employees.Select(p => new { p.fullName, p.department, p.position, p.salary, p.kpi, p.premium }).ToList();
        }
        private void PaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payments payments = new Payments();
            payments.Show();
        }
        private void AddEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter.isAddEmployee = true;
            ShowEmployee showEmployee = new ShowEmployee();
            showEmployee.ShowDialog();
            Filter.isAddEmployee = false;

            UpdateMainDataGrid();
        }
        private void ExcelDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeReport employeeReport = new EmployeeReport();
            employeeReport.DataForReport();
            dataGridView1.DataSource = ' ';
            dataGridView1.DataSource = Filter.employeeReports.Select(p => new {p.fullName, p.department, p.position
                                                                              , p.salary, p.kpi, p.premium}).ToList();

            dataGridView1.Visible = false;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "All files (*.*)|*.*|Microsoft Office Excel *.xls|*.xlsx";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;
                excelApp.DisplayAlerts = false; // убираю проверку на перезапись - ибо использую стандартную диалог.окна сохранения

                worksheet.Cells.Font.Name = "Times New Roman"; // задал глобальный шрифт
                worksheet.Cells.Font.Size = 12; // задал глобальный размер шрифта

                for (int i = 0; i < dataGridView1.Columns.Count; i++) // делаю заголовки столбцов
                {
                    excelApp.Cells[i + 1] = dataGridView1.Columns[i].HeaderText.ToString();

                    if (i == 1)
                    {
                        worksheet.Rows[1].Font.Name = "Times New Roman"; // задал шрифт для заголовков
                        worksheet.Rows[1].Font.Size = 14; // задал размер шрифта для заголовков
                        worksheet.Rows[1].Font.Bold = true; // задал жирность шрифта для заголовков
                    }
                }

                for (int i = 2; i < dataGridView1.RowCount + 2; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount + 1; j++)
                    {
                        if(j == 5)
                        {
                            worksheet.Rows[i].Columns[j] = Char.ConvertFromUtf32((char)dataGridView1.Rows[i - 2].Cells[j - 1].Value);
                        }
                        else
                        {
                            worksheet.Rows[i].Columns[j] = dataGridView1.Rows[i - 2].Cells[j - 1].Value;
                        }
                    }
                }

                excelApp.AlertBeforeOverwriting = false;
                try
                {
                    workbook.SaveAs(path);
                    MessageBox.Show("Файл сохранен успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    dataGridView1.DataSource = ' ';
                    dataGridView1.DataSource = Filter.employees.Select(p => new { p.firstName, p.middleName, p.secondName, p.department, p.position, p.salary, p.kpi }).ToList();
                    MessageBox.Show("Файл уже открыт. Закройте файл и повторите операцию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                excelApp.Quit();
            }
            else
            {
                MessageBox.Show("Вы отменили операцию", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView1.Visible = true;
            dataGridView1.DataSource = ' ';
            dataGridView1.DataSource = Filter.employees.Select(p => new { p.fullName, p.department, p.position, p.salary, p.kpi, p.premium }).ToList();
        }
        private void TxtDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("reportEmployees.txt"))
            {
                EmployeeReport employeeReport = new EmployeeReport();
                employeeReport.DataForReport();

                foreach (var employee in Filter.employeeReports.Select(p => new { p.fullName, p.department, p.position
                                                                               , p.salary, p.kpi, p.premium}).ToList())
                {
                    writer.WriteLine($"ФИО: {employee.fullName}, отдел: {employee.department}, должность: {employee.position}, " +
                                     $"оклад: {employee.salary}, оценка: {employee.kpi}, премия: {employee.premium}"); 
                }
            }
            MessageBox.Show("Успешно создан файл reportEmployees.txt в корне проекта", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void EditPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Filter.positions.Count == 0)
            {
                Filter.LoadFromDBPositions();
            }

            ShowPositionsDepartments showPositionsDepartments = new ShowPositionsDepartments(Filter.positions, "Список должностей");

            try
            {
                showPositionsDepartments.ShowDialog();
            }
            catch
            {

            }

            UpdateMainDataGrid(); 
        }
        private void EditDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filter.LoadFromDBDepartments(out List<Subdivision> subdivisions);

            ShowPositionsDepartments showPositionsDepartments = 
                new ShowPositionsDepartments(subdivisions.Select(p => p.department).ToList(), "Список департаментов");
            try
            {
                showPositionsDepartments.ShowDialog();
            }
            catch
            {

            }

            UpdateMainDataGrid();
        }
        private void UpdateMainDataGrid()
        {
            Filter.employees.Clear();
            Filter.LoadFromDBEmp();
            dataGridView1.DataSource = Filter.employees.Select(p => new { p.fullName //p.firstName, p.middleName, p.secondName
                                                                        , p.department, p.position, p.salary, p.kpi, p.premium }).ToList();
        }
    }
}
