using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EmployeeApp.Model;

namespace EmployeeApp
{
    public partial class ShowPositionsDepartments : Form
    {
        List<Subdivision> allSubdivisions;
        private int insertToSsubdivisionOrAppointment { get; set; }
        public ShowPositionsDepartments()
        {
            InitializeComponent();
            MaximizeBox = false;
        }
        public ShowPositionsDepartments(List<string> positions, string nameForm)
        {
            InitializeComponent();
            MaximizeBox = false;
            Text = nameForm;

            departmentsCB.DropDownStyle = ComboBoxStyle.DropDownList;

            dataGridView1.DataSource = positions.Select(allPositions => new { allPositions }).ToList();

            allSubdivisions = new List<Subdivision>();
          
            if(nameForm != "Список департаментов")
            {
                Filter.LoadFromDBDepartments(out List<Subdivision> getSubdivisions);

                allSubdivisions = getSubdivisions;

                departmentsCB.DataSource = allSubdivisions.Select(p => p.department).ToList();

                departmentsTB.Visible = false;
                departmentsCB.Visible = true;
                SelectPositionLB.Visible = true;
                positionAddTB.Visible = true;
                SelectDepartmentLB.Text = "Выберите департамент";
                AddBTN.Location = new Point(387, 143);
                NewPositionLB.Text = "Выберите из списка должность \nи введите новую должность";
                DeletePositionLB.Text = "Выберите позицию, которую \nхотите удалить и нажмите кнопку";
                insertToSsubdivisionOrAppointment = 2;
            }
            else
            {
                departmentsTB.Visible = true;
                departmentsCB.Visible = false;
                departmentsCB.DataSource = positions;
                SelectPositionLB.Visible = false;
                positionAddTB.Visible = false;
                SelectDepartmentLB.Text = "Введите департамент";
                AddBTN.Location = new Point(387, 104);
                NewPositionLB.Text = "Выберите департамент из списка \nи введите новое название";
                DeletePositionLB.Text = "Выберите департамент, который \nхотите удалить и нажмите кнопку";
                insertToSsubdivisionOrAppointment = 1;
            }
        }
        private void AddBTN_Click(object sender, EventArgs e)
        {
            string department;
            if (insertToSsubdivisionOrAppointment == 2)
                department = departmentsCB.Text;
            else
                department = departmentsTB.Text;
            

            if(department.Length == 0)
            {
                MessageBox.Show("Вы не ввели название отдела, который хотите добавить", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                departmentsTB.Focus();
                return;
            }

            string position = positionAddTB.Text;
            Filter.InsertDBNewDepartmentPosition(insertToSsubdivisionOrAppointment, department, position);
            positionAddTB.Text = "";

            UpdateDataGridView();
        }
        private void EditPisitionBTN_Click(object sender, EventArgs e)
        {
            string selectedItem = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (EditTB.Text.Length == 0)
            {
                MessageBox.Show("Введите новую должность", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EditTB.Focus();
                return;
            }

            string newItem = EditTB.Text;

            Filter.UpdateDBDepartmentOrPosition(insertToSsubdivisionOrAppointment, selectedItem, newItem);

            UpdateDataGridView();
        }
        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            string selectedPosition = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Filter.DeleteDepartmentOrPositionFromDB(insertToSsubdivisionOrAppointment, selectedPosition, out int countEmployees);

            if(countEmployees == 0)
                UpdateDataGridView();
        }
        private void UpdateDataGridView()
        {
            if (insertToSsubdivisionOrAppointment == 2)
            {
                Filter.positions.Clear();
                Filter.LoadFromDBPositions();
                dataGridView1.DataSource = Filter.positions.Select(allPositions => new { allPositions }).ToList();
            }
            else
            {
                departmentsTB.Text = "";
                Filter.LoadFromDBDepartments(out List<Subdivision> getSubdivisions);
                dataGridView1.DataSource = getSubdivisions.Select(p => new { p.department }).ToList();
            }
            EditTB.Text = "";
        }
    }
}
