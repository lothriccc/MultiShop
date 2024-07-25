using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService ContactService)
        {
            _contactService = ContactService;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _contactService.GetAllContactsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var values = await _contactService.GetByIdContactAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateContactAsync(createContactDto);
            return Ok("Mesaj başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAync(id);
            return Ok("Mesaj başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContactAsync(updateContactDto);
            return Ok("Mesaj başarıyla güncellendi");
        }
    }
}
