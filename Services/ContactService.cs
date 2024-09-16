using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAgendaAPI.Data;
using MyAgendaAPI.Models;
using MyAgendaAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MyAgendaAPI.Repositories
{
    public class ContactService : IContactService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ContactService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<Contact>>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            if (await _context.Contacts.AnyAsync(dbContact => dbContact.Email == contact.Email))
                throw new Exception("email already exists: '" + contact.Email + "'");

            var newContact = _mapper.Map<Contact>(contact);

            await _context.Contacts.AddAsync(newContact);
            await _context.SaveChangesAsync();

            return newContact;
        }

        public async Task<Contact> UpdateAsync(int id, Contact contact)
        {
            var oldContact = await _context.Contacts.FindAsync(id);
            if (oldContact == null)
            {
                throw new Exception("this id is not related with a contact in the database");
            }

            if (contact.Email != oldContact.Email && await _context.Contacts.AnyAsync(dbContact => dbContact.Email == contact.Email))
                throw new Exception("email already exists: '" + contact.Email + "'");

            oldContact.Name = contact.Name;
            oldContact.Email = contact.Email;
            oldContact.Phone = contact.Phone;

            _context.Entry(oldContact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                throw new Exception("this id is not related with a contact in the database");
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
