using WebApplication1.Models;
using WebApplication1.Repository.Interfaces;

namespace WebApplication1.Repository
{
    public class Deptstuff : DepartmentRepository,DepartmentStuff
    {
        SystemEntity context;
        public Deptstuff(SystemEntity _context) : base(_context)
        {
            context = _context;
        }
        public List<string> GetEmployees(int DeptID)
        {
            List<string> employees = (from e in context.Employees
                                      where e.deptId == DeptID
                                      select e.Name).ToList();
            return employees;
        }
    }
}
