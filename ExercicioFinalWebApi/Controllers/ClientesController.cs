using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ExercicioFinalWebApi.Enums;
using ExercicioFinalWebApi.Models;
using Refit;

namespace ExercicioFinalWebApi.Controllers
{
    public class ClientesController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Clientes
        public IQueryable<Cliente> GetClientes()
        {
            return db.Clientes;
        }

        // GET: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> GetCliente(int id)
        {
            Cliente cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCliente(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (cliente.Cnpj == null && cliente.Cpf == null)
            {
                return BadRequest("Deve-se preencher ao menos um dos Campos CPF / Cnpj.");
            }

            else if(cliente.Cnpj.Length >= 14 && cliente.Cnpj.Length <= 18 && cliente.NomeFantasia == null)
            {                   
                return BadRequest("Nome fantasia nao pode ser nulo");
            }

            if (cliente.Cep.Length >= 8 && cliente.Cep.Length <= 9)
            {
                {
                    var cepClient = RestService.For<ICepApiService>("https://viacep.com.br");
                    string cep = cliente.Cep.ToString();

                    var address = await cepClient.GetAddressAsync(cep);

                    cliente.Estado = address.Estado;
                    cliente.Cidade = address.Cidade;
                    cliente.Cep = address.Cep;
                    cliente.Endereco = address.Endereco;
                }
            }

            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [ResponseType(typeof(Cliente))]
        public async Task<IHttpActionResult> DeleteCliente(int id)
        {
            Cliente cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            
            cliente.Ativo = false;
            await db.SaveChangesAsync();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClienteExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
    }
}