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
    public class ListPositionController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ListPositionController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all list positions from the database.
        /// </summary>
        /// <returns>Return value: DataResponse - ListPositionDto</returns>
        [HttpGet]
        public DataResponse<IEnumerable<ListPositionDto>> GetAll()
        {
            var response = new DataResponse<IEnumerable<ListPositionDto>>();

            try
            {
                response.Data = _unitOfWork.ListPosition.GetAll().ToDtos();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Get a specific list position from the database based on its Id
        /// </summary>
        /// <param name="id">Id (integer)</param>
        /// <returns>Return value: DataResponse ListPositionDto</returns>
        [HttpGet("{id}")]
        public DataResponse<ListPositionDto> GetById(int id)
        {
            var response = new DataResponse<ListPositionDto>();

            try
            {
                response.Data = _unitOfWork.ListPosition.GetById(id)?.ToDto();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Add new list position to database.
        /// </summary>
        /// <param name="listPositionDto">listPositionDto (decimal Quantity, bool IsBuyed, int ProductId, int ShoppingListId)</param>
        /// <returns>DataResponse - Id of new added list position.</returns>
        [HttpPost]
        public DataResponse<int> Add(ListPositionDto listPositionDto)
        {
            var response = new DataResponse<int>();

            try
            {
                var listPosition = listPositionDto.ToDao();
                _unitOfWork.ListPosition.Add(listPosition);
                _unitOfWork.Complete();
                response.Data = listPosition.Id;    
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Updating specific list position data in the database based on its ID.
        /// </summary>
        /// <param name="ListPosition">ListPositionDto (int Id, decimal Quantity, bool IsBuyed, int ProductId, int ShoppingListId)</param>
        /// <returns>no data returns</returns>
        [HttpPut]
        public Response Update(ListPositionDto listPosition)
        {
            var response = new Response();

            try
            {
                _unitOfWork.ListPosition.Update(listPosition.ToDao());
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Delete specyfic list position from database based on its ID
        /// </summary>
        /// <param name="id">Id (integer)</param>
        /// <returns>no data returns</returns>
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var response = new Response();

            try
            {
                _unitOfWork.ListPosition.Delete(id);
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