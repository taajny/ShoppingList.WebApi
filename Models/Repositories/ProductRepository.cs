using ShoppingList.WebApi.Models.Domains;

namespace ShoppingList.WebApi.Models.Repositories
{
    public class ProductRepository
    {
        private readonly ShoppingListContext _context;

        public ProductRepository(ShoppingListContext context)
        {
            _context = context;
        }
        public IEnumerable<Products> GetAll() 
        { 
            return _context.Products;
        } 

        public Products GetById(int id) 
        { 
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Products product) 
        { 
            _context.Products.Add(product);
        }

        public void Update(Products product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(x => x.Id == product.Id);

            productToUpdate.Name = product.Name;
            productToUpdate.Unit = product.Unit;
            

        }

        public void Delete(int id)
        {
            var productToDelete = _context.Products.FirstOrDefault(x => x.Id == id);

            _context.Products.Remove(productToDelete);
        }

    }
}
