using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ContactRepository : IContactDal
    {
        Context context=new Context();

        public async Task<Contact> AddContactAsync(Contact response)
        {
            var contact=await context.Contacts.AddAsync(response);
            await context.SaveChangesAsync();
            return contact.Entity;
        }

        public async Task<Contact> DeleteContactAsync(int id)
        {
            var contact=await GetContactById(id);
             if (contact != null)
            {
                context.Contacts.Remove(contact);
                await context.SaveChangesAsync();
                return contact;
            }
            return null;
        }

        public async Task<bool> Exist(int contactId)
        {
            return await context.Contacts.AnyAsync(x=>x.ContactID==contactId);
        }

        public async  Task<List<Contact>> GetAllContacts()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await context.Contacts.FindAsync(id);
        }


        public async Task<Contact> UpdateContactAsync(int contactId, Contact response)
        {
            var value=await GetContactById(contactId);
            if (value != null)
            {
                
                value.ContactName= response.ContactName;
                value.ContactEmail= response.ContactEmail;
                value.ContactPhone= response.ContactPhone;
                value.ContactWebPage= response.ContactWebPage;
                value.ContactAddress= response.ContactAddress;
                value.ContactJob= response.ContactJob;
                value.ContactImage= response.ContactImage;
                await context.SaveChangesAsync();
                return value;
            }
            return null;

        }
    }
}
