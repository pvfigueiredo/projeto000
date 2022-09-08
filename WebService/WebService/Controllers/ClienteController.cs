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
            var clientes = clienteRepository.GetClientes();
            return Ok(mapper.Map<IEnumerable<ClienteDTO>>(clientes));
        }
        
        // GET /clientes/{id}
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Cliente> GetCliente(Guid id)
        {
            var cliente = clienteRepository.GetCliente(id);
            
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
            var cliente = new Cliente() { ClienteId = Guid.NewGuid(),Nome = request.Nome,Sobrenome = request.Sobrenome,CPF = request.CPF,DataNascimento = request.DataNascimento,Email = request.Email };
            clienteRepository.SaveCliente(cliente);            
            return Ok(cliente);
            
        }

        // DELETE /clientes/{id}
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCliente(Guid id)
        {
            try
            {
                clienteRepository.DeleteCliente(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //PUT /clientes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCliente(Guid id, Cliente request)
        {
            var cliente = GetCliente(id);
            if(cliente is null)
            {
                return NotFound();
            }
            clienteRepository.UpdateCliente(request);
            return NoContent();
        }

        //PATCH /clientes/{id}
        [HttpPatch]
        public ActionResult<Cliente> PatchCliente(Guid id, JsonPatchDocument<Cliente> jsonPatch)
        {
            var cliente = clienteRepository.GetCliente(id);
            if(cliente is null)
            {
                return NotFound();
            }
            jsonPatch.ApplyTo(cliente, ModelState);
            clienteRepository.UpdateCliente(cliente);
            return Ok(cliente);
        }
    }
}
