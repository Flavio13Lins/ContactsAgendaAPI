
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAgendaAPI.Models;
using MyAgendaAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;
        private IMapper _mapper;

        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        // /api/contacts GET all contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllAsync()
        {
            var contacts = await _service.GetAllAsync();
            if (contacts == null) return NotFound();
            return Ok(contacts);
        }

        // /api/contacts/:id GET contact by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetByIdAsync(int id)
        {
            var contact = await _service.GetByIdAsync(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        // /api/contacts POST create a new contact
        [HttpPost]
        public async Task<ActionResult<Contact>> CreateAsync(Contact contact)
        {
            try
            {
                var contactMapped = _mapper.Map<Contact>(contact);
                var newContact = await _service.CreateAsync(contactMapped);
                return Ok(newContact);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = error.Message });
            }
        }

        // /api/contacts/:id PUT update a contact
        [HttpPut("{id}")]
        public async Task<ActionResult<Contact>> UpdateAsync(int id, [FromBody] Contact contact)
        {
            try
            {
                var contactMapped = _mapper.Map<Contact>(contact);
                if (id != contactMapped.Id) return BadRequest();
                if (contactMapped == null) return NotFound();
                var newContact = await _service.UpdateAsync(id, contactMapped);
                return Ok(newContact);

            }
            catch (Exception error)
            {
                return BadRequest(new { message = error.Message });
            }
        }

        // /api/contacts/:id DELETE a contact
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                if (!result) return NotFound();
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = error.Message });
            }
        }
    }
}
