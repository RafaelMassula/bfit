using bfitapi.Data.IServices;
using bfitapi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _repository;
        public IngredientController(IIngredientRepository repository)
        {
            _repository = repository;
        }
        [Route("ingredients"), HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] Ingredient ingredient)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(ingredient);
            try
            {
                await _repository.Create(ingredient);
                return Created(nameof(GetIngredientForId), ingredient);
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
            catch (ArgumentNullException error)
            {
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Route("ingredients/{id}"), HttpDelete]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            try
            {
                await _repository.Delete(id);
                return NoContent();
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }

        [Route("ingredients/{id}"), HttpGet]
        public async Task<IActionResult> GetIngredientForId(int id)
        {
            try
            {
                var ingredient = await _repository.Get(id);
                return Ok(ingredient);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }

        [Route("ingredients"), HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await _repository.GetList();
            return Ok(ingredients);
        }

        [Route("ingredients"), HttpPut]
        public async Task<IActionResult> UpdateTypePayment([FromBody] Ingredient ingredient)
        {
            try
            {
                return Ok(await _repository.Update(ingredient));
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }
    }
}
