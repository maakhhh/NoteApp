using Core.Domain;
using Core.Repositories;

namespace Core.Services;

public class NodeService : INodeService
{
    private readonly IRepository<Node> repository;

    public NodeService(IRepository<Node> repository)
    {
        this.repository = repository;
    }
    
    public async Task<IEnumerable<Node>> GetAll()
    {
        return repository.GetAll();
    }

    public async Task<int> Add(Node node)
    {
        node.CreatedAt = DateTime.UtcNow;
        node.UpdatedAt = DateTime.UtcNow;
        await repository.AddAsync(node);
        return node.Id;
    }

    public async Task<Node?> GetById(int id)
    {
        return GetAll().Result.FirstOrDefault(n => n.Id == id);
    }

    public async Task<int> Delete(int id)
    {
        var node = await GetById(id);
        await repository.DeleteAsync(node);
        return id;
    }

    public async Task<int> Update(Node node)
    {
        await repository.UpdateAsync(node);
        return node.Id;
    }
}