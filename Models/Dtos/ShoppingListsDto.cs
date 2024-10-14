using ShoppingList.WebApi.Models.Domains;

namespace ShoppingList.WebApi.Models.Dtos
{
    public class ShoppingListsDto
    {
        public ShoppingListsDto()
        {
            ListPosition = new HashSet<ListPosition>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool IsCompleted { get; set; }

        public virtual ICollection<ListPosition> ListPosition { get; set; }
    }
}
