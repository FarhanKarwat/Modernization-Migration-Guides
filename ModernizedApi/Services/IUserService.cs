using ModernizedApi.Models;

namespace ModernizedApi.Services;

public interface IUserService
{
    IEnumerable<UserDto> GetAll();
    UserDto? GetById(int id);
    UserDto Add(string name);
    bool Delete(int id);
}
