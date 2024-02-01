using CrudApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoApiController : ControllerBase
    {
        private readonly ApiDemoDbContext _apiDemoDbContext;

        public DemoApiController(ApiDemoDbContext apiDemoDbContext)
        {
            _apiDemoDbContext = apiDemoDbContext;
        }



        [HttpGet]
        [Route("get-users-list")]
        public  IActionResult GetUsers()
        {
            var users = _apiDemoDbContext.Users ; 
            return Ok(users);
        }


        [HttpGet]
        [Route("get-user-by-id/{UserId}")]
        public IActionResult GetUsersById(int UserId)
        {
            var user = _apiDemoDbContext.Users.Find(UserId);
            if (user == null)
            {
                return NotFound(); // Return 404 Not Found if user with given Id is not found
            }

            return Ok(user);
        }


        [HttpPost]
        [Route("create-user")]

        public IActionResult adduser(User user)
        {
            _apiDemoDbContext.Users.Add(user);
            _apiDemoDbContext.SaveChanges();
            return Created($"/get-user-by-id/{user.UserId}",user);
        }


        [HttpPut]
        [Route("Update")]
        public IActionResult Update(User userToUpdate)
        {
            _apiDemoDbContext.Users.Update(userToUpdate);
            _apiDemoDbContext.SaveChanges();
            return NoContent();
        }



        [HttpDelete]
        [Route("Delete-User")]

        public IActionResult DeleteUser (int UserId)
        {
            var UserToDelete = _apiDemoDbContext.Users.Find(UserId);
            if (UserToDelete == null)
            {
                return NotFound();
            }

            _apiDemoDbContext.Users.Remove(UserToDelete);
            _apiDemoDbContext.SaveChanges();
            return NoContent();

        }




    }

}
