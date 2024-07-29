using HrProject.Core.Entities;

namespace HrProject.Business.Abstracts;

public interface IEmployeeService
{
    void Create(string name, string? lastname, int departmentId, int positionId);
    void Update(Guid id, string name, string? lastname, int departmentId, int positionId);
    void Delete(Guid id);
    List<Employee> GetAll();
    Employee GetById(Guid id);
}
