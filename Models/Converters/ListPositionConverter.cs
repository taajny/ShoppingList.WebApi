using ShoppingList.WebApi.Models.Domains;
using ShoppingList.WebApi.Models.Dtos;

namespace ShoppingList.WebApi.Models.Converters
{
    public static class ListPositionConverter
    {
        public static ListPositionDto ToDto(this ListPosition model)
        {
            return new ListPositionDto
            {
                Id = model.Id,
                Quantity = model.Quantity,
                IsBuyed = model.IsBuyed,
                ProductId = model.ProductId,
                ShoppingListId = model.ShoppingListId,

                Product = model.Product,
                ShoppingList = model.ShoppingList
            };
        }
        public static IEnumerable<ListPositionDto> ToDtos(this IEnumerable<ListPosition> model)
        {
            if (model == null)
            {
                return Enumerable.Empty<ListPositionDto>();
            }

            return model.Select(x => x.ToDto());
        }

        public static ListPosition ToDao(this ListPositionDto model)
        {
            return new ListPosition
            {
                Id = model.Id,
                Quantity = model.Quantity,
                IsBuyed = model.IsBuyed,
                ProductId = model.ProductId,
                ShoppingListId = model.ShoppingListId,

                Product = model.Product,
                ShoppingList = model.ShoppingList
            };
        }
    }
}
