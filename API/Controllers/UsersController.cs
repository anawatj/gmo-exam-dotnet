using Core.Domains;
using Core.Dtos;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IServices service;
        public UsersController(IServices service)
        {
            this.service = service;
        }
        [HttpGet("api/usergroup")]
        public ActionResult<IEnumerable<UserGroup>> GetAllUserGroup()
        {
          
            try
            {
                var userGroups = service.LoadUserGroup();
                return Ok(userGroups);
            }catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(Exception ex)
            {
                return Problem(ex.Message, null, 500, "Error", null);
            }
        }
        [HttpPost("api/register")]
        public ActionResult<RegisterDto> Register(RegisterDto data)
        {
            try
            {
                var user = service.Register(data);
                return Ok(user);
            }catch(BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception ex)
            {
                return Problem(ex.Message,null,500,"Error",null);
            }
           
        }
    }
}
