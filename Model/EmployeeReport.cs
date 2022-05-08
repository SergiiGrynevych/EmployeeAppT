using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeApp.Model
{
    public class EmployeeReport : Person
    {
        public string fullName { get; private set; }
        public double premium { get; private set; }
        public EmployeeReport(string firstName, string lastName, string middleName
                            , string department, string position, double salary
                            , char kpi, double premium) : base(firstName, lastName
                                                             , middleName, department
                                                             , position, salary, kpi)
        {
            this.premium = premium;
            fullName = $"{secondName} {firstName} {middleName}";
        }
        public EmployeeReport() { }
        public void DataForReport()
        {
            if(Filter.employeeReports.Count != 0)
            {
                return;
            }
            using (SqlConnection connection = new SqlConnection(Filter.connectionString))
            {
                string sqlExpression = "select EM_FirstName, EM_LastName, EM_MiddleName" +
                                            ", SB_Department AS отдел, AP_Position AS должность" +
                                            ", SE_Salary as оклад, SE_Kpi as оценка" +
                                            ", CAST(case when SE_Kpi = 'a' then sum(SE_Salary * 0.2) " +
                                                        "when SE_Kpi = 'b' then sum(SE_Salary * 0.3) " +
                                                        "when SE_Kpi = 'c' then sum(SE_Salary * 0.4) " +
                                              "end AS SMALLMONEY) as премия " +
                                        "from Employees e " +
                                        "left join EmployeeAppointment ea " +
                                            "on e.EM_Id = ea.ES_EmployeeId " +
                                        "left join Appointment a " +
                                            "on a.AP_Id = ea.ES_AppointmentId " +
                                        "left join Subdivision s " +
                                            "on s.SB_Id = a.AP_IdSubdivision " +
                                        "left join SalaryEmployee se " +
                                            "on e.EM_Id = se.SE_IdEmployee " +
                                        "group by EM_LastName, EM_FirstName, EM_MiddleName" +
                                               ", SB_Department, AP_Position, SE_Salary" +
                                               ", SE_Kpi " +
                                        "order by SB_Department";

                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            double salary;
                            char kpi;
                            double premium;

                            EmployeeReport employeeReport = 
                                new EmployeeReport(reader.GetValue(0).ToString()
                                                 , reader.GetValue(1).ToString()
                                                 , reader.GetValue(2).ToString()
                                                 , reader.GetValue(3).ToString()
                                                 , reader.GetValue(4).ToString()
                                                 , double.TryParse(reader.GetValue(5).ToString(), out salary) ? salary : '\0'
                                                 , char.TryParse(reader.GetValue(6).ToString(), out kpi) ? kpi : '\0'
                                                 , double.TryParse(reader.GetValue(7).ToString(), out salary) ? salary : '\0') ;

                            Filter.employeeReports.Add(employeeReport);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
