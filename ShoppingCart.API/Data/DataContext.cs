using Microsoft.EntityFrameworkCore;
using ShoppingCart.API.Entities;

namespace ShoppingCart.API.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<Item> Items { get; set; }
	}
}
