using BusinessLayer.Service;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Manager
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _ContactDal;
        public ContactManager(IContactDal contactDal)
        {
            _ContactDal = contactDal;
        }
        public Task<Contact> AddContact(Contact p)
        {
             return  _ContactDal.AddContactAsync(p);
        }

        public Task<Contact> DeleteContact(int id)
        {
            return _ContactDal.DeleteContactAsync(id);
        }

        public Task<List<Contact>> GetAllContacts()
        {
            var values=_ContactDal.GetAllContacts();
            return values;
        }

        public Task<Contact> GetContact(int id)
        {
            var value=_ContactDal.GetContactById(id);
            return value;
        }

        public Task<Contact> UpdateContact(int id,Contact p)
        {
            return _ContactDal.UpdateContactAsync(id,p);
        }
    }
}
