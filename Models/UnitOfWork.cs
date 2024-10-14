using ShoppingList.WebApi.Models.Domains;
using ShoppingList.WebApi.Models.Repositories;

namespace ShoppingList.WebApi.Models
{
    public class UnitOfWork
    {
        private readonly ShoppingListContext _context;
        public UnitOfWork(ShoppingListContext context)
        {
            _context = context;
            Product = new ProductRepository(context);
            ListPosition = new ListPositionRepository(context);
            ShoppingList = new ShoppingListRepository(context);
        }

        public ProductRepository Product { get; }
        public ListPositionRepository ListPosition { get; }
        public ShoppingListRepository ShoppingList { get;  } 

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
