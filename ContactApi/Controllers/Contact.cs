using ContactApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Contact : ControllerBase
	{

		private readonly DataContext _context;

		public Contact(DataContext context)
		{
			_context = context; 
		}

		[HttpGet]
		public async Task<IActionResult> AvoirToutLesContacts()
		{
			var contacts = await _context.Contact.ToListAsync();
			return Ok(contacts);
		}
	}
}
