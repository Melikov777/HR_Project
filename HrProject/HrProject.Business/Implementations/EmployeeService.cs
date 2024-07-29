using HrProject.Business.Abstracts;
using HrProject.Business.Exceptions;
using HrProject.Core.Entities;

namespace HrProject.Business.Implementations;

public class EmployeeService : IEmployeeService
{
    private List<Employee> _employees;
    public EmployeeService()
    {
        _employees = new List<Employee>();
    }
    public void Create(string name,string? lastname , int departmentId, int positionId)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        var check_employee_name = _employees.Find(d => d.Name == name);
        if (check_employee_name is not null)
        {
            throw new AlreadyExistException("This name exists");
        }

        var check_employee_lastname = _employees.Find(d => d.LastName == lastname);
        if(check_employee_lastname is not null)
        {
            throw new AlreadyExistException("This lastname exists");
        }

        if (departmentId == 0)
        {
            throw new ArgumentNullException("Invalid departmentId");
        }
        var check_employee_departmentId = _employees.Find(d => d.DepartmentId == departmentId);
        if(check_employee_departmentId is not null)
        {
            throw new AlreadyExistException("This departmentId exists");
        }
        if(positionId == 0)
        {
            throw new ArgumentNullException("Invalid positionId");
        }
        var check_employee_positionId = _employees.Find(d=> d.PositionId == positionId);
        if( check_employee_positionId is not null)
        {
            throw new AlreadyExistException("This positionId exists");
        }
        Employee employee = new Employee(name,lastname,departmentId,positionId);
        _employees.Add(employee);
    }

    public void Delete(Guid id)
    {
        var employee = _employees.Find(d => d.Id == id);
        if (employee is null)
        {
            throw new NotFoundException("This employee doesn't exist");
        }
        _employees.Remove(employee);
    }

    public List<Employee> GetAll()
    {
        return _employees;
    }

    public List<Employee> GetByDepartment(string departmentName)
    {
        var employee = _employees.FindAll(d => d.Name == departmentName);
        if (employee is null)
        {
            throw new NotFoundException("This employee doesn't exist");
        }
        return employee;
    }

    public Employee GetById(Guid id)
    {
        var employee = _employees.Find(d => d.Id == id);
        if (employee is null)
        {
            throw new NotFoundException("This employee doesn't exist");
        }
        return employee;
    }

    public List<Employee> GetByPosition(string positionName)
    {
        var employee = _employees.FindAll(d => d.Name == positionName);
        if(employee is null)
        {
            throw new NotFoundException("This employee doesn't exist");
        }
        return employee;
    }

    public List<Employee> SearchByName(string name)
    {
        var employee = _employees.FindAll(d=> d.Name == name);
        if (employee is null)
        {
            throw new NotFoundException("This employee doesn't exist");
        }
        return employee;
    }

    public void Update(Guid id, string name, string? lastname, int departmentId,int positionId)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        var employee = _employees.Find(d => d.Id == id);
        if (employee is null)
        {
            throw new NotFoundException("this employee doesn't exist");
        }
        var check_employee_name = _employees.Find(d => d.Name == name);
        if (check_employee_name is not null)
        {
            throw new AlreadyExistException("Employee with this name exists");
        }

        var check_employee_lastname = _employees.Find(d => d.LastName == lastname);
        if (check_employee_lastname is not null)
        {
            throw new AlreadyExistException("Employee with this lastname exists");
        }

        if (departmentId == 0)
        {
            throw new ArgumentNullException("Invalid departmentId");
        }
        var check_employee_departmentId = _employees.Find(d => d.DepartmentId == departmentId);
        if (check_employee_departmentId is not null)
        {
            throw new AlreadyExistException("Employee with this departmentId exists");
        }
        if (positionId == 0)
        {
            throw new ArgumentNullException("Invalid positionId");
        }
        var check_employee_positionId = _employees.Find(d => d.PositionId == positionId);
        if (check_employee_positionId is not null)
        {
            throw new AlreadyExistException("Employee with this positionId exists");
        }
        employee.Name = name;
        employee.LastName = lastname;
        employee.DepartmentId = departmentId;
        employee.PositionId = positionId;
    }
}
