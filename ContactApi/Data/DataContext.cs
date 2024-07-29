using ContactApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options): base(options) { }


		public DbSet<Contact> Contact { get; set; }
	}
}
