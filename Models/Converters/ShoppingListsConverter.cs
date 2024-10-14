using ShoppingList.WebApi.Models.Domains;
using ShoppingList.WebApi.Models.Dtos;

namespace ShoppingList.WebApi.Models.Converters
{
    public static class ShoppingListsConverter
    {
        public static ShoppingListsDto ToDto(this ShoppingLists model)
        {
            return new ShoppingListsDto
            {
                Id = model.Id,
                Description = model.Description,
                DateOfCreation = model.DateOfCreation,
                IsCompleted = model.IsCompleted,
                ListPosition = model.ListPosition
            };
        }

        public static IEnumerable<ShoppingListsDto> ToDtos(this IEnumerable<ShoppingLists> model)
        {
            if (model == null)
            {
                return Enumerable.Empty<ShoppingListsDto>();
            }

            return model.Select(x => x.ToDto());
        }

        public static ShoppingLists ToDao(this ShoppingListsDto model)
        {
            return new ShoppingLists
            {
                Id = model.Id,
                Description = model.Description,
                DateOfCreation = model.DateOfCreation,
                IsCompleted = model.IsCompleted,
                ListPosition = model.ListPosition
            };
        }
    }
}

