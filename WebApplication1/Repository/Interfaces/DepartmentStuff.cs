using WebApplication1.Models;

namespace WebApplication1.Repository.Interfaces
{
    public interface DepartmentStuff: IRepository<Department>
    {
        List<string> GetEmployees(int DeptID);
    }
}
