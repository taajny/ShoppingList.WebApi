using ShoppingList.WebApi.Models.Domains;

namespace ShoppingList.WebApi.Models.Repositories
{
    public class ListPositionRepository
    {
        private readonly ShoppingListContext _context;

        public ListPositionRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public IEnumerable<ListPosition> GetAll() 
        {
            return _context.ListPosition;
        }

        public ListPosition GetById(int id) 
        { 
            return _context.ListPosition.FirstOrDefault(x => x.Id == id);
        }

        public void Add(ListPosition listPosition)
        {
            _context.ListPosition.Add(listPosition);
        }

        public void Update(ListPosition listPosition) 
        { 
            var listPositionToUpdate = _context.ListPosition.FirstOrDefault(x => x.Id == listPosition.Id);

            listPositionToUpdate.Quantity = listPosition.Quantity;
            listPositionToUpdate.IsBuyed = listPosition.IsBuyed;
            listPositionToUpdate.Product = listPosition.Product;
            listPositionToUpdate.ShoppingList = listPosition.ShoppingList;

        }

        public void Delete(int id) 
        { 
            var listPositionToDelete = _context.ListPosition.FirstOrDefault(x => x.Id == id);

            _context.ListPosition.Remove(listPositionToDelete);
        }
    }
}
