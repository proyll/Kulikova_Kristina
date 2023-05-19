using Azure.Core;

using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApiTesst.Contracts.Product;

namespace WebApiTesst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// Получение списка всех пользователей БД
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }



        /// <summary>
        /// Возвращение айди всех пользователей пользователей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetById(id);
            var response = new GetProductResponse()
            {

                ProductId = result.ProductId,
                CategoryId = result.CategoryId,
                NameP = result.NameP,
                Price = result.Price,
                ProductAvailability = result.ProductAvailability,

            };
            return Ok(await _productService.GetById(id));
        }

        /// <summary>
        /// Создание нового бронирования
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "login" : "A4Tech Bloody B188",
        ///         "password" : "!Pa$$word123@",
        ///         "firstname" : "Иван",
        ///         "lastname" : "Иванов",
        ///         "middlename" : "Иванович"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            var productDto = request.Adapt<Product>();
            await _productService.Create(productDto);
            return Ok();
        }
        /// <summary>
        /// Изменение сущностей записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Product user)
        {
            await _productService.Update(user);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
