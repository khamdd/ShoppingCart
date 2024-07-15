using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.API.Data;
using ShoppingCart.API.Entities;
using ShoppingCart.API.Interfaces;

namespace ShoppingCart.API.Repositories
{
	public class ItemRepository : IItem
	{
		private readonly DataContext context;

		public ItemRepository(DataContext _context)
        {
			context = _context;
		}

		public async Task<Item?> CreateItem(Item item)
		{
			await context.Items.AddAsync(item);
			await context.SaveChangesAsync();
			return item;
		}

		public async Task<Item?> DeleteItem(int id)
		{
			var item = await context.Items.FindAsync(id);
			if (item == null)
			{
				return null;
			}

			context.Items.Remove(item);
			await context.SaveChangesAsync();

			return item;
		}

		public async Task<Item?> GetItem(int id)
		{
			var item = await context.Items.FindAsync(id);

			if (item == null)
			{
				return null;
			}

			return item;
		}

		public async Task<List<Item>> GetItems()
		{
			return await context.Items.ToListAsync();
		}

		public async Task<Item?> UpdateItem(Item item)
		{
			context.Entry(item).State = EntityState.Modified;
			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ItemExists(item.Id))
				{
					return null;
				}
				else
				{
					throw;
				}
			}

			return item;
		}

		private bool ItemExists(int id)
		{
			return context.Items.Any(e => e.Id == id);
		}
	}
}
