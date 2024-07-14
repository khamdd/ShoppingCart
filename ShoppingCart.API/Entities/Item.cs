namespace ShoppingCart.API.Entities
{
	public class Item
	{
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime ImportDate { get; set; } = DateTime.Now;
        public float Price { get; set; } = 0f;
    }
}
