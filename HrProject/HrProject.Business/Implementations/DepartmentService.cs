using HrProject.Business.Abstracts;
using HrProject.Business.Exceptions;
using HrProject.Core.Entities;
using System.ComponentModel;
using System.Xml.Linq;

namespace HrProject.Business.Implementations;

public class DepartmentService : IDepartmentService
{
    private List<Department> _departments;

    public DepartmentService()
    {
        _departments = new List<Department>();
    }
    public void Create(string name)
    {
        if (string.IsNullOrEmpty(name)) 
        {
            throw new ArgumentNullException("Invalid Name");
        }
        var check_department = _departments.Find(d=> d.Name == name);
        if (check_department is not null)
        {
            throw new AlreadyExistException("This name exists ");
        }
        Department department = new Department(name);
        _departments.Add(department);
    }

    public void Delete(int id)
    {
        var department = _departments.Find(d => d.Id ==id);
        if (department is null)
        {
            throw new NotFoundException("This Department doesn't exist");
        }
        _departments.Remove(department);

    }

    public List<Department> GetAll()
    {
        return _departments;
    }

    public Department GetById(int id)
    {
        var department = _departments.Find(d => d.Id == id);
        if (department is null)
        {
            throw new NotFoundException("This Department doesn't exist");
        }
        return department;
    }

    public void Update(int id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        var department = _departments.Find(d=>d.Id == id);
        if (department is null)
        {
            throw new NotFoundException("this department doesn't exist");
        }
        var check_department = _departments.Find(d=>d.Name == name);
        if (check_department is not null)
        {
            throw new AlreadyExistException("Department with this name exists");
        }
        department.Name = name; 
    }
}
