using ModernizedApi.Data;
using ModernizedApi.Models;

namespace ModernizedApi.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _db;
    public UserService(AppDbContext db) => _db = db;

    public IEnumerable<UserDto> GetAll() => _db.Users.Select(Map);
    public UserDto? GetById(int id) => _db.Users.Where(u => u.Id == id).Select(Map).FirstOrDefault();

    public UserDto Add(string name)
    {
        var nextId = _db.Users.Any() ? _db.Users.Max(u => u.Id) + 1 : 1;
        var entity = new User { Id = nextId, Name = name };
        _db.Users.Add(entity);
        _db.SaveChanges();
        return Map(entity);
    }

    public bool Delete(int id)
    {
        var entity = _db.Users.FirstOrDefault(u => u.Id == id);
        if (entity == null) return false;
        _db.Users.Remove(entity);
        _db.SaveChanges();
        return true;
    }

    private static UserDto Map(User u) => new(u.Id, u.Name);
}
