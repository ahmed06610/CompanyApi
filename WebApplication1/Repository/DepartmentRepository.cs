using WebApplication1.Models;
using WebApplication1.Repository.Interfaces;

namespace WebApplication1.Repository
{
    public class DepartmentRepository: IRepository<Department>
    {
        SystemEntity context;
        public DepartmentRepository(SystemEntity _context)
        {
            context = _context;
        }
        public List<Department> GetAall()
        {
            return context.Department.ToList();
        }
        public Department GetById(int Id)
        {
            return context.Department.FirstOrDefault(e => e.Id == Id);

        }
        public Department GetByName(string name)
        {
            return context.Department.FirstOrDefault(e => e.Name == name);

        }
        public void insert(Department Department)
        {
            context.Add(Department);
            context.SaveChanges();
        }
        public void update(int Id, Department Department)
        {
            Department orgemp = GetById(Id);
            orgemp.Name = Department.Name;
            orgemp.ManagerName = Department.ManagerName;
            context.SaveChanges();
        }
        public void delete(int Id)
        {
            Department orgemp = GetById(Id);
            context.Department.Remove(orgemp);
            context.SaveChanges();
        }

        
    }
}
