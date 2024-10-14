using ShoppingList.WebApi.Models.Domains;
using ShoppingList.WebApi.Models.Dtos;

namespace ShoppingList.WebApi.Models.Converters
{
    public static class ProductsConverter
    {
        public static ProductsDto ToDto(this Products model)
        {
            return new ProductsDto 
            { 
                 Id = model.Id,
                 Name = model.Name,
                 Unit = model.Unit,
                 ListPosition = model.ListPosition
            };
        }

        public static IEnumerable<ProductsDto> ToDtos(this IEnumerable<Products> model) 
        { 
            if (model == null) 
            { 
                return Enumerable.Empty<ProductsDto>();
            }   

            return model.Select(x => x.ToDto());
        }

        public static Products ToDao(this ProductsDto model)
        {
            return new Products
            {
                Id = model.Id,
                Name = model.Name,
                Unit = model.Unit,
                ListPosition = model.ListPosition
            };
        }
    }
}
