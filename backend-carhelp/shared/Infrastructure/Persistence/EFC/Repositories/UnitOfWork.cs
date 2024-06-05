using backend_carhelp.shared.Domain.Repositories;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration;

namespace backend_carhelp.shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context) => _context = context;
    
    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}