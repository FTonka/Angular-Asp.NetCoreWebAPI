using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactDal
    {
        Task<Contact> UpdateContactAsync(int contactId, Contact response );
        Task<List<Contact>> GetAllContacts();
        Task<bool> Exist( int contactId );
        Task<Contact> GetContactById(int id);
        Task<Contact> DeleteContactAsync(int id);
        Task<Contact> AddContactAsync(Contact response);


    }
}
