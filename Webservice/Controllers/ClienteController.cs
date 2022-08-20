using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Webservice.Model;

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
                new Cliente(){ClienteID = Guid.NewGuid(), Nome = "Paulo", SobreNome = "Figueiredo", CPF = "12345678901", DataNascimento = DateTime.UtcNow },
                new Cliente(){ClienteID = Guid.NewGuid(), Nome = "Arthur", SobreNome = "Lima", CPF = "31278987601", DataNascimento = DateTime.UtcNow },
                new Cliente(){ClienteID = Guid.NewGuid(), Nome = "Amanda", SobreNome = "Lima", CPF = "98087653100", DataNascimento = DateTime.UtcNow }
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
            var cliente = _clienteList.Where(c => id == c.ClienteID).FirstOrDefault();
            
            if(cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
    }
}
