using Azure.Core;

using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApiTesst.Contracts.DescriptionProduct;

namespace WebApiTesst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionProductController : ControllerBase
    {
        private IDescriptionProductService _descriptionproductService;
        public DescriptionProductController(IDescriptionProductService descriptionproductService)
        {
            _descriptionproductService = descriptionproductService;
        }
        /// <summary>
        /// Получение списка всех пользователей БД
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _descriptionproductService.GetAll());
        }



        /// <summary>
        /// Возвращение айди всех пользователей пользователей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _descriptionproductService.GetById(id);
            var response = new GetDescriptionProductResponse()
            {
                CustomerId = result.CustomerId,
                TextD = result.TextD,
                Rating = result.Rating,

            };
            return Ok(await _descriptionproductService.GetById(id));
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
        public async Task<IActionResult> Add(CreateDescriptionProductRequest request)
        {
            var descriptionproductDto = request.Adapt<DescriptionProduct>();
            await _descriptionproductService.Create(descriptionproductDto);
            return Ok();
        }
        /// <summary>
        /// Изменение сущностей записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(DescriptionProduct user)
        {
            await _descriptionproductService.Update(user);
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
            await _descriptionproductService.Delete(id);
            return Ok();
        }
    }
}
