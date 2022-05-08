
namespace EmployeeApp.Model
{
    public class Appointment
    {
        public int id { get; private set; }
        public string position { get; private set; }
        public int idSubdivision { get; private set; }
        public Appointment(int id, string position, int idSubdivision)
        {
            this.id = id;
            this.position = position;
            this.idSubdivision = idSubdivision;
        }
    }
}
