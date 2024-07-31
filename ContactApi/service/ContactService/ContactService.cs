using ContactApi.Data;
using ContactApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

namespace ContactApi.Service.ContactService
{
	public class ContactService : IContactService
	{
		private readonly DataContext _context;

		public ContactService(DataContext context)
		{
			_context = context;
		}
		public async Task<ActionResult<List<Contact>>>? AvoirToutLesContacts()
		{
				var contacts = await _context.Contact.ToListAsync();
				return contacts;
		}

		public async Task<ActionResult<Contact>>? ContactParId(int Id)
		{
			var contactsParId = await _context.Contact.FindAsync(Id);
			if (contactsParId == null) {
				return null;
					}
			return contactsParId;
		}
		public async Task<ActionResult<Contact>>? ContactParNom(string nom)
		{
			var contactsParNom = await _context.Contact.FindAsync(nom);
			if (contactsParNom == null)
			{
				return null;
			}
			return contactsParNom;
		}

		public async Task<ActionResult<Contact>>? ContactParPrenom(string prenomCommencantPar)
		{
			var contactsParPrenom = await _context.Contact.FindAsync("Like " + "%" + prenomCommencantPar + "");
			if (contactsParPrenom == null)
			{
				return null;
			}
			return contactsParPrenom;
		}
		public async Task<ActionResult<List<Contact>>>? AjoutContact([FromBody] Contact ajoutContact)
		{
			_context.Contact.Add(ajoutContact);
			await _context.SaveChangesAsync();
			return  await _context.Contact.ToListAsync();
		}

		public async Task<ActionResult<List<Contact>>>? ModifierContact(Contact modifierUnContact, int Id)
		{
			var dbContact = await _context.Contact.FindAsync(modifierUnContact.Id, Id);

			if (dbContact is null)
				return null;


			dbContact.Nom = modifierUnContact.Nom;
			dbContact.Prenom = modifierUnContact.Prenom;
			dbContact.Nom_Complet = dbContact.Prenom + " " + dbContact.Nom;
			dbContact.Sexe = modifierUnContact.Sexe;
			dbContact.Date_Naissance = modifierUnContact.Date_Naissance;
			dbContact.Avatar = modifierUnContact.Avatar;

			await _context.SaveChangesAsync();
			return await _context.Contact.ToListAsync();
		}

		public async Task<ActionResult<List<Contact>>>? SupprimerUnContact(int Id)
		{
			var supprimerEntrer = await _context.Contact.FindAsync(Id);

			if (supprimerEntrer is null)
				return null;

			_context.Contact.Remove(supprimerEntrer);
			await _context.SaveChangesAsync();
			return await _context.Contact.ToListAsync();
		}

		public async Task<ActionResult<List<Contact>>>? ModifierLePrenomDuContact(Contact modifierUnNomDeContact, int Id)
		{
			var dbContact = await _context.Contact.FindAsync(Id);

			if (dbContact is null) { 
				return null;
			}
			dbContact.Prenom = modifierUnNomDeContact.Prenom;
			dbContact.Nom_Complet = dbContact.Prenom +" " + dbContact.Nom;

			await _context.SaveChangesAsync();
			return await _context.Contact.ToListAsync();
		}


	}
}
