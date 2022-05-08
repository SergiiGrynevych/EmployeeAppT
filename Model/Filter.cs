using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeApp.Model
{
    public static class Filter
    {
        public static string connectionString = "Data Source=DESKTOP-SS9RJG3;Initial Catalog=TPost;Integrated Security=True";
        public static List<Employee> employees = new List<Employee>();
        public static List<string> positions = new List<string>();
        public static List<EmployeeReport> employeeReports = new List<EmployeeReport>();
        public static bool isSearchByFilter;
        public static bool isSearchByIdDepartment;
        public static string selectedDepartment;
        public static bool isEditToolStripMenuItemClick { get; set; }
        public static bool isFirstStartAppWithNoData { get; set; }
        public static bool isFirstStartAppWithNoDataPositions { get; set; }
        public static bool isAddEmployee { get; set; }
        public static void LoadFromDBEmp()
        {
            Employee employee;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "select EM_ID, EM_FirstName, EM_MiddleName, " +
                                              "EM_LastName, EM_PhoneNumber, EM_Address, " +
                                              "SB_Department, AP_Position, SE_SALARY, SE_KPI " +
                                       "from Employees e " +
                                       "left join EmployeeAppointment ea on e.EM_Id = ea.ES_EmployeeId " +
                                       "left join Appointment a " +
                                            "on a.AP_Id = ea.ES_AppointmentId " +
                                       "left join Subdivision s " +
                                            "on s.SB_Id = a.AP_IdSubdivision " +
                                       "left join SalaryEmployee se " +
                                            "on e.EM_Id = se.SE_IdEmployee";

                if (isSearchByFilter)
                    sqlExpression += $" where SB_Department like '{selectedDepartment}%'";

                sqlExpression += " order by EM_Id";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) 
                    {
                        isFirstStartAppWithNoData = false;
                        while (reader.Read())
                        {
                            double salary;
                            char kpi;
                            employee = new Employee(Convert.ToInt32(reader.GetValue(0))
                                                   , reader.GetValue(1).ToString()
                                                   , reader.GetValue(2).ToString()
                                                   , reader.GetValue(3).ToString()
                                                   , reader.GetValue(4).ToString()
                                                   , reader.GetValue(5).ToString()
                                                   , reader.GetValue(6).ToString()
                                                   , reader.GetValue(7).ToString()
                                                   , double.TryParse(reader.GetValue(8).ToString(), out salary) ? salary : 0.0
                                                   , char.TryParse(reader.GetValue(9).ToString(), out kpi) ? kpi : '\0');

                            employees.Add(employee);
                        }
                    }
                    else
                    {
                        if (isFirstStartAppWithNoData)
                        {
                            return;
                        }
                        MessageBox.Show("Такого отдела или сотрудников в этом отделе не найдено", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isSearchByFilter = false;

                        LoadFromDBEmp();
                    }
                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("Неожиданная ошибка", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void LoadFromDBPositions()
        {
            selectedDepartment = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "select AP_Position from Appointment";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        isFirstStartAppWithNoDataPositions = false;
                        while (reader.Read())
                        {
                            for(int i = 0; i < reader.VisibleFieldCount; i++)
                            {
                                positions.Add(reader.GetValue(i).ToString());
                            }
                        }
                    }
                    else
                    {
                        if (isFirstStartAppWithNoDataPositions)
                        {
                            return;
                        }

                        if (selectedDepartment.Length == 0)
                        {
                            return;
                        }

                        MessageBox.Show("Такого отдела не найдено", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isSearchByFilter = false;
                        LoadFromDBEmp();
                    }
                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("Неожиданная ошибка", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void LoadFromDBDepartments(out List<string> departments, int idDepartment)
        {
            departments = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "select SB_Department from Subdivision";

                if (isSearchByIdDepartment)
                    sqlExpression += $" where SB_Id = {idDepartment}";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (!isSearchByIdDepartment)
                        {
                            departments.Add("Все отделы");
                        }
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.VisibleFieldCount; i++)
                            {
                                departments.Add(reader.GetValue(i).ToString());
                            }
                        }
                    }
                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("Неожиданная ошибка", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void LoadFromDBDepartments(out List<Subdivision> subdivisions)
        {
            int idSubdivisionSB;
            string departmentSB;
            Subdivision subdivision;
            subdivisions = new List<Subdivision>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "select SB_Id, Sb_Department from Subdivision";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            idSubdivisionSB = Convert.ToInt32(reader.GetValue(0));
                            departmentSB = reader.GetValue(1).ToString();
                            subdivision = new Subdivision(idSubdivisionSB, departmentSB);
                            subdivisions.Add(subdivision);
                        }
                    }
                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("Неожиданная ошибка", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void LoadFromDBPositions(out List<Appointment> positions, out List<Subdivision> subdivisions)
        {
            int id;
            string position;
            int idSubdivision;
            Appointment appointment;
            positions = new List<Appointment>();

            LoadFromDBDepartments(out List<Subdivision> departments);

            subdivisions = departments;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "select AP_Id, AP_Position, AP_IdSubdivision from Appointment";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            id = Convert.ToInt32(reader.GetValue(0));
                            position = reader.GetValue(1).ToString();
                            idSubdivision = Convert.ToInt32(reader.GetValue(2));
                            appointment = new Appointment(id, position, idSubdivision);
                            positions.Add(appointment);
                        }
                    }
                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("Неожиданная ошибка", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static void UpdateDBEmp(int id, Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                for(int i = 0; i <= 2; i++)
                {
                    string sqlExpression = "";
                    if (i == 0)
                    {
                        sqlExpression =
                        "update Employees " +
                        $"set EM_FirstName = '{employee.firstName}'" +
                          $", EM_MiddleName = '{employee.middleName}'" +
                          $", EM_LastName = '{employee.secondName}'" +
                          $", EM_PhoneNumber = '{employee.phoneNumber}'" +
                          $", EM_Address = '{employee.address}'" +
                          $"  where EM_Id = {id}";
                    } 
                    else if(i == 1)
                    {
                        sqlExpression = "update EmployeeAppointment " +
                            $"set ES_AppointmentId = (select AP_Id from Appointment where AP_Position = '{employee.position}') " +
                            $"where ES_EmployeeId = {id} " +
                            "and ES_AppointmentId in (select AP_Id from Appointment) ";
                    }
                    else
                    {
                        sqlExpression = "UPDATE SalaryEmployee " +
                                       $"SET SE_Salary = {employee.salary} " +
                                     $", SE_Kpi = '{employee.kpi}'" +
                                      $" where SE_IdEmployee = {id}";
                    }

                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                MessageBox.Show("Данные обновлены", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void UpdateDBDepartmentOrPosition(int depatmentOrPositionUPD, string item, string newItem)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression;
                if (depatmentOrPositionUPD == 2)
                {
                    sqlExpression = "update Appointment " +
                         $"set AP_Position = '{newItem}' " +
                         $"where AP_Position = '{item}'";
                }
                else
                {
                    sqlExpression = "update Subdivision " +
                                   $"set SB_Department = '{newItem}' " +
                                   $"where SB_Department = '{item}'";
                }

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                MessageBox.Show("Данные обновлены", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void InsertDBEmp(string firstName, string middleName, string lastName
                                     , string phoneNumber, string address, string position
                                     , double salary, char kpi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                string sqlExpression = "insert into Employees " +
                                       "values " +
                                       $"('{firstName}', '{middleName}', '{lastName}'" +
                                       $", '{phoneNumber}', '{address}')";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так при заполнения сотрудника"
                        , "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                string sqlExpression = "insert into EmployeeAppointment " +
                                       "values (" +
                                                "(select EM_ID " +
                                                "from Employees e " +
                                                "left join EmployeeAppointment ea " +
                                                    "on e.EM_Id = ea.ES_EmployeeId " +
                                                "where ea.ES_EmployeeId is null " +
                                                $"and e.EM_FirstName = '{firstName}' " +
                                                $"and e.EM_MiddleName = '{middleName}' " +
                                                $"and e.EM_LastName = '{lastName}' " +
                                                $"and e.EM_PhoneNumber = '{phoneNumber}' " +
                                                $"and e.EM_Address = '{address}' " +
                                                ")" +
                                                ", (select AP_Id " +
                                                   "from Appointment " +
                                                   $"where AP_Position = '{position}'))";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так при заполнении позиции", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "insert into SalaryEmployee " +
                                       "values (" +
                                                "(select EM_ID " +
                                                 "from Employees e " +
                                                 "left join SalaryEmployee se " +
                                                    "on e.EM_ID = se.SE_IdEmployee " +
                                                  "where SE_IdEmployee is null " +
                                                  $"and e.EM_FirstName = '{firstName}' " +
                                                  $"and e.EM_MiddleName = '{middleName}' " +
                                                  $"and e.EM_LastName = '{lastName}' " +
                                                  $"and e.EM_PhoneNumber = '{phoneNumber}' " +
                                                  $"and e.EM_Address = '{address}') " +
                                                  $",{salary} " +
                                                  $",'{kpi}')";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так при заполнении зарплаты", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            MessageBox.Show("Данные добавлены", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void InsertDBNewDepartmentPosition(int insertToSsubdivisionOrAppointment, string department, string position)
        {
            #region обозначение insertToSsubdivisionOrAppointment
            //insertToSsubdivisionOrAppointment == 1 to insert into tb Subdivision
            //insertToSsubdivisionOrAppointment == 2 to insert into tb Appointment
            #endregion

            if (insertToSsubdivisionOrAppointment == 1)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlExpression = "insert into Subdivision " +
                                          $"values ('{department}')";

                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так при добавлении отдела", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            if (insertToSsubdivisionOrAppointment == 2)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlExpression = "insert into Appointment " +
                                          $"values ('{position}'" +
                                          $",  (select SB_Id " +
                                               "from Subdivision " +
                                              $"where SB_Department = '{department}'))";

                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так при добавлении отдела", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            MessageBox.Show("Данные добавлены", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void DeleteEmpFromDB(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int iteration = 0;
                for (int i = 0; i <= 3; i++)
                {
                    string sqlExpression = "";
                    if (i == 0)
                    {
                        sqlExpression = "DELETE EmployeeAppointment " +
                                       $"WHERE ES_EmployeeId = {id}";
                    }
                    else if(i == 1)
                    {
                        sqlExpression = "DELETE SalaryEmployee " +
                                       $"WHERE SE_IdEmployee = {id}";
                    }
                    else if (i == 2)
                    {
                        sqlExpression = "DELETE Employees " +
                                       $"WHERE EM_Id = {id}";
                    }
                    else
                    {
                        iteration = 3;
                        sqlExpression = "select count(*) from Employees";
                    }

                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    try
                    {
                        if(iteration == 3)  
                        {
                            SqlDataReader reader = command.ExecuteReader(); 

                            if (reader.HasRows) 
                            {
                                while (reader.Read())   
                                {
                                    int countEmployees = Convert.ToInt32(reader.GetValue(0));

                                    if(countEmployees == 0)
                                    {
                                        isFirstStartAppWithNoData = true;
                                    }
                                }
                            }
                        }
                        if (!isFirstStartAppWithNoData && iteration != 3) 
                        {                               
                            command.ExecuteNonQuery();  
                            connection.Close();         
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Что-то пошло не так", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                MessageBox.Show("Сотрудник удален", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public static void DeleteDepartmentOrPositionFromDB(int deteFromSubdivisionOrAppointment, string itemToDelte, out int countEmployees)
        {
            countEmployees = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Appointment> appointments = new List<Appointment>();

                string positions = "";

                string sqlExpression = "select COUNT(EM_Id) " +
                                       "from Employees e " +
                                       "left join EmployeeAppointment ea " +
                                        "on e.EM_Id = ea.ES_EmployeeId " +
                                       "left join Appointment a " +
                                        "on ea.ES_AppointmentId = a.AP_Id " +
                                       $"where AP_Position = '{itemToDelte}'";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            countEmployees = Convert.ToInt32(reader.GetValue(0));
                        }
                    }

                    if (countEmployees == 0)
                    {
                        if(deteFromSubdivisionOrAppointment == 2)
                        {
                            sqlExpression = "delete from Appointment " +
                                           $"where AP_Position = '{itemToDelte}'";
                        }
                        else
                        {
                            sqlExpression = "delete from Subdivision " +
                                           $"where SB_Department = '{itemToDelte}'";
                        }

                        connection.Close();
                        connection.Open();

                        SqlCommand newCommand = new SqlCommand(sqlExpression, connection);

                        try
                        {
                            newCommand.ExecuteNonQuery();
                        }
                        catch
                        {
                            connection.Close();

                            sqlExpression = "select AP_Id, AP_Position, AP_IdSubdivision " +
                                            "from Appointment a join Subdivision s " +
                                            "on a.AP_IdSubdivision = s.SB_Id " +
                                           $"where SB_Department = '{itemToDelte}'";

                            connection.Open();

                            SqlCommand Command = new SqlCommand(sqlExpression, connection);

                            try
                            {
                                SqlDataReader readerApp = Command.ExecuteReader();

                                if (readerApp.HasRows)
                                {
                                    while (readerApp.Read())
                                    {
                                        int id = Convert.ToInt32(readerApp.GetValue(0));
                                        string aa = readerApp.GetValue(1).ToString();
                                        int ad = Convert.ToInt32(readerApp.GetValue(2));

                                        Appointment appointment = new Appointment(Convert.ToInt32(readerApp.GetValue(0))
                                                                                , readerApp.GetValue(1).ToString()
                                                                                , Convert.ToInt32(readerApp.GetValue(2)));

                                        appointments.Add(appointment);
                                    }
                                }

                                foreach(var el in appointments)
                                {
                                    positions += $"{el.position}\n";
                                }

                                MessageBox.Show("Изначально нужно удалить все позиции у департамента, \n" +
                                        "и только потом удалять департамент. \n" +
                                        "Конфликт с позициями: \n" +
                                       $"{positions}", "Внимание!"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        MessageBox.Show("В данном элементу присутствуют сотрудники. " +
                            "Удалите изначально сотрудников с позиции, а потом удаляйте елемент"
                            , "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("При удалении что-то пошло не так", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            MessageBox.Show("Элемент удален", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void LoadPayments(out double sumPayments, string department)
        {
            sumPayments = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "";
                double salary;
                double premium;

                List<Payment> payments = new List<Payment>();

                sqlExpression = "select sum(SE_Salary) as salary" +
                              ", case when SE_Kpi = 'a' then 0.2 " +
                                     "when SE_KPI = 'B' then 0.3 " +
                                     "when SE_Kpi = 'c' then 0.4 " +
                                "end as premium " +
                                "from SalaryEmployee se ";

                if (department.Length != 0 && department != "Все отделы")
                {
                    sqlExpression += $"right join Employees e " +
                                        $"on se.SE_IdEmployee = e.EM_Id " +
                                     $"right join EmployeeAppointment ea " +
                                        $"on ea.ES_EmployeeId = e.EM_Id " +
                                     $"right join Appointment a " +
                                        $"on ea.ES_AppointmentId = a.AP_Id " +
                                     $"join Subdivision s " +
                                        $"on a.AP_IdSubdivision = s.SB_Id " +
                                    $"where SB_Department = '{department}' ";
                }

                sqlExpression += "group by SE_Kpi";
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) 
                    {
                        while (reader.Read()) 
                        {
                            Payment payment = new Payment(double.TryParse(reader.GetValue(0).ToString(), out salary) ? salary : 0.0
                                                        , double.TryParse(reader.GetValue(1).ToString(), out premium) ? premium : 0.0);

                            payments.Add(payment);
                        }
                    }

                    foreach (var el in payments)
                    {
                        if (el.premium == 0)
                        {
                            sumPayments += el.salary;
                        }
                        else
                        {
                            sumPayments += el.salary;
                            sumPayments += el.salary * el.premium;
                        }
                    }
                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("Неожиданная ошибка", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
