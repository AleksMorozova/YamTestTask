using AuthenticationApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApp.DataAccess.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetUser(string username, string password);
}

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly APIDbContext _context;

    public UserRepository(APIDbContext context) : base(context) => _context = context;

    public Task<User?> GetUser(string username, string password) =>
        _context.Users.FirstOrDefaultAsync(_ => _.Name == username);
}
