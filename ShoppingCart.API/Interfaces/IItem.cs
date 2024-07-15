using ShoppingCart.API.Entities;

namespace ShoppingCart.API.Interfaces
{
	public interface IItem
	{
		Task<List<Item>> GetItems();
		Task<Item?> GetItem(int id);
		Task<Item?> CreateItem(Item item);
		Task<Item?> UpdateItem(Item item);
		Task<Item?> DeleteItem(int id);
	}
}
