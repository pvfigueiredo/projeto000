using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Webservice.Entities;
using Webservice.Repositories;

namespace Webservice.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        ClientesRepository _clienteRepository;
        public ClienteController()
        {
            _clienteRepository = new ClientesRepository();
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _clienteRepository.GetClientes();
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Cliente> GetCliente(Guid id)
        {
            var cliente = _clienteRepository.GetCliente(id);
            
            if(cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult PostCliente(Cliente request)
        {
            if(request == null)
            {
                return BadRequest();
            }
            var cliente = new Cliente() { ClienteId = Guid.NewGuid(),Nome = request.Nome,Sobrenome = request.Sobrenome,CPF = request.CPF,DataNascimento = request.DataNascimento,Email = request.Email };
            _clienteRepository.SaveCliente(cliente);            
            return Ok(cliente);
            
        }

        [HttpPut("{id}")]
        public ActionResult PutCliente(Guid id, Cliente? request)
        {
            //Pode ser substituido por "var cliente" a declaração "Cliente cliente" para evitar redundância
            var cliente = _clienteRepository.GetCliente(id);
            //
            //Deve modificar o cliente encontrado, por isso deve receber um cliente ao invés da Guid
            return Ok(cliente);
        }
            

    }
}
