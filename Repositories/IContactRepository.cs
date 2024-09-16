using MyAgendaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAgendaAPI.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task<Contact> AddAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
        Task<bool> DeleteAsync(int id);
    }
}
