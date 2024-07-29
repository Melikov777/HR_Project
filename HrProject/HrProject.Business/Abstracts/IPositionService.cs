using HrProject.Core.Entities;

namespace HrProject.Business.Abstracts;

public interface IPositionService
{
    void Create(string name);
    void Update(int id, string name);
    void Delete(int id);
    List<Position> GetAll();
    Position GetById(int id);
}
