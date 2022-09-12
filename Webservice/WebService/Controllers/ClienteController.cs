using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WebService.DTO;
using WebService.Entities;
using WebService.Repositories;

namespace WebService.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteController(IRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        // GET /clientes/
        [HttpGet]
        public ActionResult GetClientes()
        {
            var clientes = clienteRepository.GetAll().Cast<Cliente>().ToList();
            return Ok(mapper.Map<IEnumerable<ClienteDTO>>(clientes));
        }
        
        // GET /clientes/{id}
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Cliente> GetCliente(Guid id)
        {
            var cliente = clienteRepository.Get(id) as Cliente;
            
            if(cliente == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ClienteDTO>(cliente));
        }

        // POST /clientes/
        [HttpPost]
        public ActionResult PostCliente(Cliente request)
        {
            if(request == null)
            {
                return BadRequest();
            }
            var cliente = new Cliente() { Id = Guid.NewGuid(),Nome = request.Nome,Sobrenome = request.Sobrenome,CPF = request.CPF,DataNascimento = request.DataNascimento,Email = request.Email };
            clienteRepository.Add(cliente);            
            return Ok(cliente);
            
        }

        // DELETE /clientes/{id}
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCliente(Guid id)
        {
            var cliente = clienteRepository.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }
            clienteRepository.Delete(cliente);
            return Ok("Cliente apagado.");
        }

        //PUT /clientes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCliente(Guid id, Cliente request)
        {
            var cliente = clienteRepository.Get(id) as Cliente;
            if(cliente is null)
            {
                return NotFound();
            }
            clienteRepository.Update(request);
            return NoContent();
        }

        //PATCH /clientes/{id}
        [HttpPatch]
        public ActionResult<Cliente> PatchCliente(Guid id, JsonPatchDocument<Cliente> jsonPatch)
        {
            var cliente = clienteRepository.Get(id) as Cliente;
            if(cliente is null)
            {
                return NotFound();
            }
            jsonPatch.ApplyTo(cliente, ModelState);
            clienteRepository.Update(cliente);
            return Ok(cliente);
        }
    }
}
