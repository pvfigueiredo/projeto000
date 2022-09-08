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
    public class UserController
    {
        UserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return _userRepository.GetUser();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Cliente> GetCliente(Guid id)
        {
            var user = _userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        private ActionResult<Cliente> NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult PostUser(User request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var user = new User() { UserId = Guid.NewGuid(), Nome = request.Nome,Email = request.Email, UserName = request.UserName, Senha = request.Senha };
            _userRepository.SaveUser(user);
            return Ok(user);

        }

        private ActionResult BadRequest()
        {
            throw new NotImplementedException();
        }

        private ActionResult Ok(User user)
        {
            throw new NotImplementedException();
        }
    }
}
