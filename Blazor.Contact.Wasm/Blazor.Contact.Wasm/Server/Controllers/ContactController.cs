using Blazor.Contact.Wasm.Shared;
using Blazor.Contacts.Wasm.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Blazor.Contact.Wasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
       private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contato contato)
        {
            if (contato == null)
                return BadRequest();

            if (string.IsNullOrEmpty(contato.FirstName))            
                ModelState.AddModelError("FirstName", "First name can´t be empty");

            if (string.IsNullOrEmpty(contato.LastName))
                ModelState.AddModelError("LastName", "Last name can´t be empety");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactRepository.InsertContact(contato);

            return NoContent();          

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] Contato contato)
        {
            if (contato == null)
                return BadRequest();

            if (string.IsNullOrEmpty(contato.FirstName))
                ModelState.AddModelError("FirstName", "First name can´t be empty");

            if (string.IsNullOrEmpty(contato.LastName))
                ModelState.AddModelError("LastName", "Last name can´t be empety");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactRepository.UpdateContact(contato);

            return NoContent();

        }

        [HttpGet]
        public async Task<IEnumerable<Contato>> Get()
        {
            return await _contactRepository.GetAllContacts();
        }


        [HttpGet("{id}")]
        public async Task<Contato> Get(int id)
        {
            return await _contactRepository.GetContactById(id);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _contactRepository.DeleteContact(id);
        }
    }
}
