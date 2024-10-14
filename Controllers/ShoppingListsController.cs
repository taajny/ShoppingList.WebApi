using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.WebApi.Models;
using ShoppingList.WebApi.Models.Converters;
using ShoppingList.WebApi.Models.Domains;
using ShoppingList.WebApi.Models.Dtos;
using ShoppingList.WebApi.Models.Response;

namespace ShoppingList.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ShoppingListsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all shopping lists from the database.
        /// </summary>
        /// <returns>Return value: DataResponse - ShoppingListDto</returns>
        [HttpGet]
        public DataResponse<IEnumerable<ShoppingListsDto>> GetAll()
        {
            var response = new DataResponse<IEnumerable<ShoppingListsDto>>();

            try
            {
                response.Data = _unitOfWork.ShoppingList.GetAll().ToDtos();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Get a specific shopping list from the database based on its Id
        /// </summary>
        /// <param name="id">Id (integer)</param>
        /// <returns>Return value: DataResponse ShoppingListDto</returns>
        [HttpGet("{id}")]
        public DataResponse<ShoppingListsDto> GetById(int id)
        {
            var response = new DataResponse<ShoppingListsDto>();

            try
            {
                response.Data = _unitOfWork.ShoppingList.GetById(id)?.ToDto();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Add new shopping list to database.
        /// </summary>
        /// <param name="ShoppingListDto">ShoppingListDto (string Description, bool IsCompleted)</param>
        /// <returns>DataResponse - Id of new added shopping list.</returns>
        [HttpPost]
        public DataResponse<int> Add(ShoppingListsDto shoppingListDto)
        {
            var response = new DataResponse<int>();

            try
            {
                var shoppingList = shoppingListDto.ToDao();
                _unitOfWork.ShoppingList.Add(shoppingList);
                _unitOfWork.Complete();
                response.Data = shoppingList.Id;
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Updating specific shopping list data in the database based on its ID.
        /// </summary>
        /// <param name="shoppingList">ShoppingListDto (int Id, string Description, bool IsCompleted)</param>
        /// <returns>no data returns</returns>
        [HttpPut]
        public Response Update(ShoppingListsDto shoppingList)
        {
            var response = new Response();

            try
            {
                _unitOfWork.ShoppingList.Update(shoppingList.ToDao());
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Delete specyfic shopping list from database based on its ID
        /// </summary>
        /// <param name="id">Id (integer)</param>
        /// <returns>no data returns</returns>
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var response = new Response();

            try
            {
                _unitOfWork.ShoppingList.Delete(id);
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }
    }
}
