
using Microsoft.AspNetCore.Mvc;
using Socialmedia.DTOs;
using Socialmedia.Models;
using Socialmedia.Repositories;

namespace Socialmedia.Controllers;


[ApiController]
[Route("api/user")]


public class UserController : ControllerBase 
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _user;
    private readonly IPostRepository _post;

    public UserController(ILogger<UserController> logger,
    IUserRepository user,IPostRepository post)
    {
        _logger = logger;
        _user = user;
        _post = post;
    }
    


[HttpGet]

 public async Task<ActionResult<List<UserDTO>>> GetAllUser()
{
        var usersList = await _user.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
}



    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] long id)
    {
        var user = await _user.GetById(id);

        if (user is null)
            return NotFound("No user found with given id");

        var dto = user.asDto;
        dto.Post = await _post.GetAllForUser(user.Id);


        return Ok(dto);
    }
[HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO Data)
    {
        if (!(new string[] { "male", "female" }.Contains(Data.Gender.Trim().ToLower())))
            return BadRequest("Gender value is not recognized");

    //    / var subtractDate = DateTimeOffset.Now - Data.DateOfBirth;
    //     if (subtractDate.TotalDays / 365 < 18.0)
    //         return BadRequest("User must be at least 18 years old");

        var toCreateUser = new User
        {
            UserName = Data.UserName.Trim(),
            FirstName = Data.FirstName.Trim(),
            LastName = Data.LastName.Trim(),
            DateOfBirth = Data.DateOfBirth.UtcDateTime,
            Email = Data.Email.Trim().ToLower(),
            Gender = Data.Gender.Trim(),
            Contact = Data.Contact,
            CreatedAt = Data.CreatedAt.UtcDateTime,
        };

        var createdUser = await _user.Create(toCreateUser);

        return StatusCode(StatusCodes.Status201Created, createdUser.asDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser([FromRoute] long id,
    [FromBody] UserUpdateDTO Data)
    {
        var existing = await _user.GetById(id);
        if (existing is null)
            return NotFound("No user found with given id");

        var toUpdateUser = existing with
        {
            Email = Data.Email?.Trim()?.ToLower() ?? existing.Email,
            LastName = Data.LastName?.Trim() ?? existing.LastName,
            FirstName = Data.FirstName?.Trim() ?? existing.FirstName,
            Contact = Data.Contact ?? existing.Contact,
            
        };

        var didUpdate = await _user.Update(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }



 [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long id)
    {
        var existing = await _user.GetById(id);
        if (existing is null)
            return NotFound("No user found with given user name");

        var didDelete = await _user.Delete(id);

        return NoContent();
    }
}