using HrProject.Business.Abstracts;
using HrProject.Business.Exceptions;
using HrProject.Core.Entities;

namespace HrProject.Business.Implementations;

public class PositionService : IPositionService
{
    private List<Position> _positions;
    public PositionService()
    {
        _positions = new List<Position>();
    }
    public void Create(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        var check_position = _positions.Find(d=> d.Name == name);
        if (check_position is not null)
        {
            throw new AlreadyExistException("This name exists");
        }
        Position position = new Position(name);
        _positions.Add(position);
    }

    public void Delete(int id)
    {
        var position = _positions.Find(d => d.Id == id);
        if (position is null)
        {
            throw new NotFoundException("This Position doesn't exist");
        }
        _positions.Remove(position);
    }

    public List<Position> GetAll()
    {
        return _positions;
    }

    public Position GetById(int id)
    {
        var position = _positions.Find(d => d.Id == id);
        if (position is null)
        {
            throw new NotFoundException("This Position doesn't exist");
        }
        return position;
    }

    public void Update(int id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException("Invalid Name");
        }
        var position = _positions.Find(d => d.Id == id);
        if (position is null)
        {
            throw new NotFoundException("this position doesn't exist");
        }
        var check_position = _positions.Find(d => d.Name == name);
        if (check_position is not null)
        {
            throw new AlreadyExistException("Position with this name exists");
        }
        position.Name = name;
    }
}
