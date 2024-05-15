using WebApplication1.Models;
using WebApplication1.Repository.Interfaces;

namespace WebApplication1.Repository
{
    public class EmployeeRepsitory: IRepository<Employee>
    {
        SystemEntity context;
        public EmployeeRepsitory(SystemEntity _context)
        {
            context = _context;
        }
        public List<Employee> GetAall() {
            return context.Employees.ToList();
        }
        public Employee GetById(int Id) 
        {
            return context.Employees.FirstOrDefault(e=>e.Id==Id);
        
        }
        public Employee GetByName(string name)
        {
            return context.Employees.FirstOrDefault(e => e.Name == name);

        }
        public void insert(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
        }
        public void update(int Id,Employee employee)
        {
            Employee orgemp=GetById(Id);
            orgemp.Name = employee.Name;
            context.SaveChanges();
        }
        public void delete(int Id)
        {
            Employee orgemp = GetById(Id);
            context.Employees.Remove(orgemp);
            context.SaveChanges();
        }


    }
}
