using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Webservice.Entities;
using Webservice.Repositories;
using WebService.Entities;

namespace WebService.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return userRepository.GetUser();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<User> GetCliente(Guid id)
        {
            var user = userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult PostUser(User request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var user = new User() { UserId = Guid.NewGuid(), Nome = request.Nome, Email = request.Email, UserName = request.UserName, Senha = request.Senha };
            userRepository.SaveUser(user);
            return Ok(user);

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteUser(Guid id)
        {
            if (userRepository.DeleteUser(id))
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(Guid id, User request)
        {
            var user = userRepository.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }
            user = new User { UserId = id, Nome = request.Nome, Email = request.Email, UserName = request.UserName, Senha = request.Senha };
            try
            {
                userRepository.UpdateUser(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            return NoContent();
        }

        [HttpPatch]
        public ActionResult<User> PatchUser(Guid id, JsonPatchDocument<User> jsonPatch)
        {
            var user = userRepository.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }
            jsonPatch.ApplyTo(user, ModelState);
            try
            {
                userRepository.UpdateUser(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            return Ok(user);
        }
    }
}
