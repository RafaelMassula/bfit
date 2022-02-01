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
    public class ProductIngredientController : ControllerBase
    {
        private readonly IProductIngredientRepository _repository;
        public ProductIngredientController(IProductIngredientRepository repository)
        {
            _repository = repository;
        }


        [Route("product_ingredients"), HttpPost]
        public async Task<IActionResult> CreateProductIngredient([FromBody] Product_Ingredient product_Ingredient)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(product_Ingredient);
            try
            {
                await _repository.Create(product_Ingredient);
                return Created("", product_Ingredient);
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
        [Route("product_ingredients/products/{idProduct}/ingredients/{idIngredient}"), HttpDelete]
        public async Task<IActionResult> DeleteProductIngredient(int idProduct, int idIngredient)
        {
            try
            {
                await _repository.Delete(idProduct, idIngredient);
                return NoContent();
            }
            catch (KeyNotFoundException error)
            {
                return BadRequest(error.Message);
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
