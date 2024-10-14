using ShoppingList.WebApi.Models.Domains;

namespace ShoppingList.WebApi.Models.Repositories
{
    public class ShoppingListRepository
    {
        private readonly ShoppingListContext _context;

        public ShoppingListRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public IEnumerable<ShoppingLists> GetAll()
        {
            return _context.ShoppingLists;
        }
        public ShoppingLists GetById(int id)
        {
            return _context.ShoppingLists.FirstOrDefault(x => x.Id == id);
        }
        public void Add(ShoppingLists shoppingList)
        {
            shoppingList.DateOfCreation = DateTime.Now;
            _context.ShoppingLists.Add(shoppingList);
        }
        public void Update(ShoppingLists shoppingList)
        {
            var shoppingListToUpdate = _context.ShoppingLists.FirstOrDefault(x => x.Id == shoppingList.Id);

            shoppingListToUpdate.Description = shoppingList.Description;
            shoppingListToUpdate.IsCompleted = shoppingList.IsCompleted;
            
        }

        public void Delete(int id) 
        { 
            var shoppingListToDelete = _context.ShoppingLists.FirstOrDefault(x => x.Id == id);

            _context.ShoppingLists.Remove(shoppingListToDelete);
        }
    }
}
