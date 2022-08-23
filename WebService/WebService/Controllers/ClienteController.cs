using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Webservice.Entities;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly List<Cliente> _clienteList;
        public ClienteController()
        {
            _clienteList = new List<Cliente>()
            {
                new Cliente(Guid.Parse("7a775e1a-3344-4eb3-a04b-cec9a0452af8"), "Paulo", "Figueiredo", "12345678901",DateTime.UtcNow, "paulo@email.com"),
                new Cliente(Guid.Parse("5370e311-7db2-454f-ace0-ae1257666288"), "Arthur", "Lima", "12345678901",DateTime.UtcNow, "arthur@email.com"),
                new Cliente(Guid.Parse("7889733a-b93a-4809-97ef-321d38acf4b9"), "Amanda", "Lima", "12345678901",DateTime.UtcNow, "amanda@email.com"),
                new Cliente(Guid.Parse("8171be86-ac02-46c5-b964-ba1e46a4d189"), "Steffania", "Lima", "12345678901",DateTime.UtcNow, "steffania@email.com")
            }; 
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _clienteList;
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Cliente> GetCliente(Guid id)
        {
            var cliente = _clienteList.Where(c => id == c.ClienteId).FirstOrDefault();
            
            if(cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult PostCliente(Cliente request)
        {
           var cliente = new Cliente(Guid.NewGuid(), request.Nome, request.Sobrenome, request.CPF, request.DataNascimento, request.Email);
           _clienteList.Add(cliente);            
           return Ok(cliente);
        }
    }
}
