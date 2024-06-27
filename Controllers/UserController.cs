using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Communication.Request;
using MyFirstApi.Communication.Response;

namespace MyFirstApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult GetByID([FromRoute]int id, [FromRoute]string nickname)
    {
        var response = new User
        {
            Id = 1,
            Age = 7,
            Name = "welisson"
        };
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody]RegisterUserJson request)
    {
        var response = new ResponseRegisterUserJson
        {
            Id = 1,
            Name= "Danilo"
        };
        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestUpdateUserProfileJson request)
    {

        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] int id)
    {
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var response = new List<User>()
        {
            new User {Id = 1, Name = "Danilo", Age = 30},
            new User {Id = 2, Name = "Thais", Age = 27}
        };

        return Ok(response);
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ChangePassword([FromBody] RequestChangePasswordJson request)
    {
        return NoContent();
    }
}
