using HrProject.Core.Interfaces;

namespace HrProject.Core.Entities;

public class Employee : IEntity<Guid>
{
    public Guid Id { get; }
    public string Name { get; set; } = null!;
    public string? LastName { get; set; }
    public int DepartmentId { get; set; }
    public int PositionId { get; set; }

    public Employee(string name , string? lastname, int departmentId, int positionId)
    {
        Name = name;
        LastName = lastname;
        DepartmentId = departmentId;
        PositionId = positionId;
        Id = Guid.NewGuid();
    }
}

