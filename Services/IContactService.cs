

using Microsoft.AspNetCore.Mvc;
using MyAgendaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAgendaAPI.Services
{
    public interface IContactService
    {
        Task<ActionResult<IEnumerable<Contact>>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task<Contact> CreateAsync(Contact contact);
        Task<Contact> UpdateAsync(int id, Contact contact);
        Task<bool> DeleteAsync(int id);
    }
}
