using Azure.Core;

using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApiTesst.Contracts.CartItem;

namespace WebApiTesst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private ICartItemService _cartitemService;
        public CartItemController(ICartItemService cartitemService)
        {
            _cartitemService = cartitemService;
        }
        /// <summary>
        /// Получение списка всех пользователей БД
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cartitemService.GetAll());
        }



        /// <summary>
        /// Возвращение айди всех пользователей пользователей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cartitemService.GetById(id);
            var response = new GetCartItemResponse()
            {
                ProductId = result.ProductId,
                CartId = result.CartId,
                Quantity = result.Quantity,

            };
            return Ok(await _cartitemService.GetById(id));
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
        public async Task<IActionResult> Add(CreateCartItemRequest request)
        {
            var cartitemDto = request.Adapt<CartItem>();
            await _cartitemService.Create(cartitemDto);
            return Ok();
        }
        /// <summary>
        /// Изменение сущностей записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CartItem user)
        {
            await _cartitemService.Update(user);
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
            await _cartitemService.Delete(id);
            return Ok();
        }
    }
}
