using Infrastructure.Data;
using Infrastructure.Data.Identity.UseCases;
using Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Identity;

public class Repository(AppDbContext context) : IRepository
{
    private readonly AppDbContext _context = context;

    public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
    => await _context
        .Users
        .AsNoTracking()
        .AnyAsync(x => x.Email == email, cancellationToken: cancellationToken);


    public async Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}