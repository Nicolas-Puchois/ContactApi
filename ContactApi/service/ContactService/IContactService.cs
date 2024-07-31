using ContactApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Service.ContactService
{
	public interface IContactService
	{

		public Task<ActionResult<List<Contact>>>? AvoirToutLesContacts();
		public Task<ActionResult<Contact>>? ContactParId(int Id);
		public Task<ActionResult<List<Contact>>>? AjoutContact([FromBody] Contact ajoutContact);
		public Task<ActionResult<List<Contact>>>? ModifierContact(Contact modifierUnContact, int Id);
		public Task<ActionResult<List<Contact>>>? SupprimerUnContact(int Id);
		public Task<ActionResult<List<Contact>>>? ModifierLePrenomDuContact(Contact modifierUnNomDeContact, int Id);
	}
}
