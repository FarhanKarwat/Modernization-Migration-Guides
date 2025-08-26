using Microsoft.AspNetCore.Mvc;
using ModernizedApi.Models;
using ModernizedApi.Services;

namespace ModernizedApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _svc;
    public UsersController(IUserService svc) => _svc = svc;

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> Get() => Ok(_svc.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<UserDto> GetById(int id)
    {
        var user = _svc.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }

    public record CreateUserRequest(string Name);

    [HttpPost]
    public ActionResult<UserDto> Post([FromBody] CreateUserRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Name)) return BadRequest("Name is required.");
        var created = _svc.Add(req.Name.Trim());
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) => _svc.Delete(id) ? NoContent() : NotFound();
}
