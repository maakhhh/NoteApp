using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories;

public class NodeRepository : IRepository<Node>
{
    private readonly NoteAppDbContext context;
    private readonly DbSet<Node> dbSet;

    public NodeRepository(NoteAppDbContext context)
    {
        this.context = context;
        this.dbSet = context.Nodes;
    }

    public IQueryable<Node> GetAll() => dbSet;

    public async Task AddAsync(Node entity, CancellationToken cancellationToken = default)
    {
        await dbSet.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<Node> entities, CancellationToken cancellationToken = default)
    {
        await dbSet.AddRangeAsync(entities, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Node entity, CancellationToken cancellationToken = default)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Node entity, CancellationToken cancellationToken = default)
    {
        dbSet.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRangeAsync(IEnumerable<Node> entities, CancellationToken cancellationToken = default)
    {
        dbSet.RemoveRange(entities);
        await context.SaveChangesAsync(cancellationToken);
    }
}