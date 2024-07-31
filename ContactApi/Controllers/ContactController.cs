using ContactApi.Data;
using ContactApi.Entities;
using ContactApi.Service.ContactService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly DataContext _context;
		private readonly IContactService _contactService;

		public ContactController(DataContext context,IContactService contactService)
		{
			_context = context;
			_contactService = contactService;
		}


		[HttpGet(Name ="RécupérerToutLesContacts")]
		public async Task<ActionResult<List<Contact>>>? AvoirToutLesContacts()
		{
			return await  _contactService.AvoirToutLesContacts();
		}

		[HttpGet("{Id}")]
		public async Task<ActionResult<Contact>>? ContactParId(int Id)
		{
			return await _contactService.ContactParId(Id);
		}

		[HttpPost]
		public async Task<ActionResult<List<Contact>>>? AjoutContact([FromBody] Contact ajoutContact)
		{
			return await _contactService.AjoutContact(ajoutContact);
		}

		[HttpPut]
		public async Task<ActionResult<List<Contact>>>? ModifierContact(Contact modifierUnContact, int Id)
		{
			return await _contactService.ModifierContact(modifierUnContact, Id);
		}

		[HttpDelete]
		public async Task<ActionResult<List<Contact>>>? SupprimerUnContact(int Id)
		{
			return await _contactService.SupprimerUnContact(Id);
		}

		[HttpPatch]
		public async Task<ActionResult<List<Contact>>>? ModifierLePrenomDuContact(Contact modifierUnNomDeContact, int Id)
		{
			return await _contactService.ModifierLePrenomDuContact(modifierUnNomDeContact,Id);
		}
	}
}
