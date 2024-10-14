using ShoppingList.WebApi.Models.Domains;

namespace ShoppingList.WebApi.Models.Dtos
{
    public class ProductsDto
    {
        public ProductsDto()
        {
            ListPosition = new HashSet<ListPosition>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        public virtual ICollection<ListPosition> ListPosition { get; set; }
    }
}
