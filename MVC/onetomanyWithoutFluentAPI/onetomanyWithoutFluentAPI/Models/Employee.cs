using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onetomanyWithoutFluentAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Department")]
        public int DeptId {  get; set; }

        public Department Department { get; set; }

    }
}
