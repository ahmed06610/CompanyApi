using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Department")]
        public int deptId { get; set; }
        public Department? Department { get; set; }
    }
}
