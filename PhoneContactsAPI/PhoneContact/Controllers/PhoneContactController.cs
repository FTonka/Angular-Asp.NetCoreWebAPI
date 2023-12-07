using BusinessLayer.Service;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PhoneContact.Controllers
{
    public class PhoneContactController : Controller
    {
        private readonly IContactService _ContactService;
        public PhoneContactController(IContactService contactService)
        {
            _ContactService=contactService;
        }
        public async  Task<IActionResult> GetAllContacts()
        {
            var values=await _ContactService.GetAllContacts();
            return View(values);
        }
        public async Task<IActionResult> GetContactById(int id)
        {
            var value = await _ContactService.GetContact(id);
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> AddContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(Contact p)
        {
            ContactValidator cvd=new ContactValidator();
            ValidationResult result=cvd.Validate(p);
            if (result.IsValid)
            {
                await _ContactService.AddContact(p);
                return RedirectToAction("GetAllContacts", "PhoneContact");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View();
            }
             
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value=await _ContactService.GetContact(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(int id,Contact p)
        {
            ContactValidator cvd = new ContactValidator();
            ValidationResult result =cvd.Validate(p);
            if (result.IsValid) { 
            var value= await _ContactService.GetContact(id);
            var contactId = value.ContactID;
            

            await _ContactService.UpdateContact(contactId,p);
                return RedirectToAction("GetAllContacts", "PhoneContact");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _ContactService.DeleteContact(id);
            return RedirectToAction("GetAllContacts", "PhoneContact");
        }

    }
}
