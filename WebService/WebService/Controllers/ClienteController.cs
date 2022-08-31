using Microsoft.AspNetCore.JsonPatch;
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
        private IClientesRepository clienteRepository;
        public ClienteController(IClientesRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        // GET /clientes/
        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return clienteRepository.GetClientes();
        }

        // GET /clientes/{id}
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Cliente> GetCliente(Guid id)
        {
            var cliente = clienteRepository.GetCliente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // POST /clientes/
        [HttpPost]
        public ActionResult PostCliente(Cliente request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var cliente = new Cliente() { ClienteId = Guid.NewGuid(), Nome = request.Nome, Sobrenome = request.Sobrenome, CPF = request.CPF, DataNascimento = request.DataNascimento, Email = request.Email };
            clienteRepository.SaveCliente(cliente);
            return Ok(cliente);

        }

        // DELETE /clientes/{id}
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCliente(Guid id)
        {
            if (clienteRepository.DeleteCliente(id))
            {
                return Ok();
            }
            return BadRequest();

        }

        //PUT /clientes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCliente(Guid id, Cliente request)
        {
            var cliente = clienteRepository.GetCliente(id);
            if (cliente is null)
            {
                return NotFound();
            }
            cliente = new Cliente { ClienteId = id, Nome = request.Nome, Sobrenome = request.Sobrenome, CPF = request.CPF, DataNascimento = request.DataNascimento, Email = request.Email };
            try
            {
                clienteRepository.UpdateCliente(cliente);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            return NoContent();
        }

        //PATCH /clientes/{id}
        [HttpPatch]
        public ActionResult<Cliente> PatchCliente(Guid id, JsonPatchDocument<Cliente> jsonPatch)
        {
            var cliente = clienteRepository.GetCliente(id);
            if (cliente is null)
            {
                return NotFound();
            }
            jsonPatch.ApplyTo(cliente, ModelState);
            try
            {
                clienteRepository.UpdateCliente(cliente);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
            return Ok(cliente);
        }
    }
}
