using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneContactsAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneContactsAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactDal _ContactDal;
        public ContactController(IContactDal contactDal)
        {
            _ContactDal = contactDal;
        }
       


        //Bu bir yorum satırı
        [HttpGet("GetAllContacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var values=await _ContactDal.GetAllContacts();
            return Ok(values);
        }
        [HttpGet("GetContact/{id}")]
        public IActionResult GetContact(int id)
        {
            using var c = new Context();
            var contact = c.Contacts.FirstOrDefault(x=>x.ContactID==id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPut("UpdateContactAsync/{id}")]
        public async Task<IActionResult> UpdateContactAsync(int id, Contact response)
        {
            if(await _ContactDal.Exist(id))
            {
                var updatedContact = await _ContactDal.UpdateContactAsync(id,response);
                if (updatedContact != null)
                {
                    return Ok(updatedContact);
                }
            }   
           return NotFound();
        }
        [HttpDelete("DeleteContactAsync/{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            if (await _ContactDal.Exist(id))
            {
                var contact=await _ContactDal.DeleteContactAsync(id);
                return Ok(contact);
            }
            return NotFound();
        }
        [HttpPost("AddContactAsync")]
        public async Task<IActionResult>  AddContactAsync(Contact contact)
        {
            var con=await _ContactDal.AddContactAsync(contact);
            return Ok(con);
        }
}
}
