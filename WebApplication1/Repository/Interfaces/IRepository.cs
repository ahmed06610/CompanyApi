using WebApplication1.Models;

namespace WebApplication1.Repository.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAall();
        T GetById(int id);
        T GetByName(string name);
        void delete(int Id);
        void insert(T employee);
        void update(int Id, T employee);

    }
}