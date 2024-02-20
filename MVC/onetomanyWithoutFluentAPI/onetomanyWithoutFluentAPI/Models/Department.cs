using System.ComponentModel.DataAnnotations;

namespace onetomanyWithoutFluentAPI.Models
{
    public class Department
    {
        [Key]
       public int DeptId { get; set; }
        public string Name { get; set; }
        public  ICollection<Employee> Employees { get; set; }
    }
}
