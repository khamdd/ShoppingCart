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

		public Task<Item> CreateItem(Item item)
		{
			throw new NotImplementedException();
		}

		public Task<Item> DeleteItem(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Item> GetItem(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Item>> GetItems()
		{
			throw new NotImplementedException();
		}

		public Task<Item> UpdateItem(Item item)
		{
			throw new NotImplementedException();
		}
	}
}
