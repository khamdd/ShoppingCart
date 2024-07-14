using ShoppingCart.API.Entities;

namespace ShoppingCart.API.Interfaces
{
	public interface ICategory
	{
		Task<List<Category>> GetCategories();
		Task<Category> GetCategoryById(int id);
		Task<Category> CreateCategory(Category category);
		Task<Category> UpdateCategory(Category category);
		Task<Category> DeleteCategory(int id);
	}
}
