using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core;

public static class NoteAppDbContextConfig
{
    public static void ConfigureNode(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>(e =>
        {
            e.HasKey(n => n.Id);
        });
    }
}