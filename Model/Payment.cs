
namespace EmployeeApp.Model
{
    public class Payment
    {
        public double salary { get; private set; }
        public double premium { get; private set; }
        public Payment(double salary, double premium)
        {
            this.salary = salary;
            this.premium = premium;
        }
    }
}
