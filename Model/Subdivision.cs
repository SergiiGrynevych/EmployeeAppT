
namespace EmployeeApp.Model
{
    public class Subdivision
    {
        public int id { get; private set; }
        public string department { get; private set; }
        public Subdivision(int id, string department)
        {
            this.id = id;
            this.department = department;
        }
    }
}
