using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public interface IContactService
    {
        Task<Contact> AddContact(Contact c);
        Task<Contact> UpdateContact(int id,Contact p);
        Task<Contact> DeleteContact(int id);
        Task<List<Contact>> GetAllContacts();
        Task<Contact> GetContact(int id);
    }
}
