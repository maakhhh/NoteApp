using Core.Domain;

namespace Core.Services;

public interface INodeService
{
    Task<IEnumerable<Node>> GetAll();
    Task<int> Add(Node node);
    Task<Node?> GetById(int id);
    Task<int> Delete(int id);
    Task<int> Update(Node node);
}