using ShoppingList.WebApi.Models.Domains;

namespace ShoppingList.WebApi.Models.Dtos
{
    public class ListPositionDto
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public bool IsBuyed { get; set; }
        public int ProductId { get; set; }
        public int ShoppingListId { get; set; }

        public virtual Products Product { get; set; }
        public virtual ShoppingLists ShoppingList { get; set; }

    }
}
