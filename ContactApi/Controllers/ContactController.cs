using ContactApi.Data;
using ContactApi.Entities;
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

		public ContactController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> AvoirToutLesContacts()
		{
			var contacts = await _context.Contact.ToListAsync();
			return Ok(contacts);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> ContactParId(int id)
		{
			var contactsParId = await _context.Contact.FindAsync(id);
			return Ok(contactsParId);
		}

		[HttpPost]
		public async Task<IActionResult> AjoutContact([FromBody] Contact ajoutContact)
		{
			_context.Contact.Add(ajoutContact);
			await _context.SaveChangesAsync();
			return Ok(await AvoirToutLesContacts());
		}

		[HttpPut]
		public async Task<IActionResult> ModifierContact(Contact modifierUnContact)
		{
			var dbContact = await _context.Contact.FindAsync(modifierUnContact.Id);
			
			dbContact.Nom = modifierUnContact.Nom;
			dbContact.Prenom = modifierUnContact.Prenom;
			dbContact.Nom_Complet = modifierUnContact.Nom_Complet;
			dbContact.Sexe = modifierUnContact.Sexe;
			dbContact.Date_Naissance = modifierUnContact.Date_Naissance;
			dbContact.Avatar = modifierUnContact.Avatar;

			await _context.SaveChangesAsync();
			return Ok(modifierUnContact);
		}

		[HttpDelete]
		public async Task<IActionResult> SupprimerUnContact(int Id)
		{
			var supprimerEntrer = await _context.Contact.FindAsync(Id);
			_context.Contact.Remove(supprimerEntrer);
			await _context.SaveChangesAsync(); 
			return Ok(await _context.Contact.ToListAsync());
		}
	}
}
