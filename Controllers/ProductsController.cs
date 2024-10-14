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
    public class ProductsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all products from the database.
        /// </summary>
        /// <returns>Return value: DataResponse - ProductsDto</returns>
        [HttpGet]
        public DataResponse<IEnumerable<ProductsDto>> GetAll()
        {
            var response = new DataResponse<IEnumerable<ProductsDto>>();

            try
            {
                response.Data = _unitOfWork.Product.GetAll().ToDtos();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }
            
            return response;
        }


        /// <summary>
        /// Get a specific product from the database based on its Id
        /// </summary>
        /// <param name="id">Id (integer)</param>
        /// <returns>Return value: DataResponse ProductsDto</returns>
        [HttpGet("{id}")]
        public DataResponse<ProductsDto> GetById(int id)
        {
            var response = new DataResponse<ProductsDto>();

            try
            {
                response.Data = _unitOfWork.Product.GetById(id)?.ToDto();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            } 

            return response;
        }

        /// <summary>
        /// Add new product to database.
        /// </summary>
        /// <param name="productDto">ProductsDto (string Name, string Unit)</param>
        /// <returns>DataResponse - Id of new added product.</returns>
        [HttpPost]
        public DataResponse<int> Add(ProductsDto productDto)
        {
            var response = new DataResponse<int>();

            try
            {
                var product = productDto. ToDao();
                _unitOfWork.Product.Add(product);
                _unitOfWork.Complete();
                response.Data = product.Id;
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Updating specific product data in the database based on its ID.
        /// </summary>
        /// <param name="product">ProductsDto (int Id, string Name, string Unit)</param>
        /// <returns>no data returns</returns>
        [HttpPut]
        public Response Update(ProductsDto product)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Product.Update(product.ToDao());
                _unitOfWork.Complete();
            }
            catch (Exception exception)
            {
                response.Errors.Add(new Error(exception.Source, exception.Message));
            }

            return response;
        }

        /// <summary>
        /// Delete specyfic product from database based on its ID
        /// </summary>
        /// <param name="id">Id (integer)</param>
        /// <returns>no data returns</returns>
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var response = new Response();

            try
            {
                _unitOfWork.Product.Delete(id);
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
