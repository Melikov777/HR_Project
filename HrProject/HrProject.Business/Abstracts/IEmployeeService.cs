using HrProject.Core.Entities;

namespace HrProject.Business.Abstracts;

public interface IEmployeeService
{
    void Create(string name);
    void Update(int id, string name);
    void Delete(int id);
    List<Employee> GetAll();
    Employee GetById(int id);
}
