using Azure.Core;

using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApiTesst.Contracts.Filter;

namespace WebApiTesst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {

        private IFilterService _filterService;
        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }
        /// <summary>
        /// Получение списка всех пользователей БД
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filterService.GetAll());
        }



        /// <summary>
        /// Возвращение айди всех пользователей пользователей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _filterService.GetById(id);
            var response = new GetFilterResponse()
            {

                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
                SubcategoryName = result.SubcategoryName,
                ProductId = result.ProductId,
                NameP = result.NameP,
                Color = result.Color,
                Material = result.Material,
                Size = result.Size,
                Price = result.Price,
                Sale = result.Sale,

            };
            return Ok(await _filterService.GetById(id));
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
        public async Task<IActionResult> Add(CreateFilterRequest request)
        {
            var filterDto = request.Adapt<Filterr>();
            await _filterService.Create(filterDto);
            return Ok();
        }
        /// <summary>
        /// Изменение сущностей записи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Filterr user)
        {
            await _filterService.Update(user);
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
            await _filterService.Delete(id);
            return Ok();
        }
    }
}
