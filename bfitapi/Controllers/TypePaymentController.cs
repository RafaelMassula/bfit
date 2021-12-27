using bfitapi.Data.IServices;
using bfitapi.Model;
using Microsoft.AspNetCore.Http;
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
    public class TypePaymentController : ControllerBase
    {
        private readonly ITypePaymentRepository _repository;
        public TypePaymentController(ITypePaymentRepository repository)
        {
            _repository = repository;
        }

        [Route("typespayments"), HttpPost]
        public async Task<IActionResult> CreateTypePayment([FromBody] TypePayment typePayment)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(typePayment);
            try
            {
                return Created("", await _repository.Create(typePayment));
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
        }

        [Route("typesPayments/{id}"), HttpDelete]
        public async Task<IActionResult> DeleteTypePayment(int id)
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

        [Route("typespayments/{id}"), HttpGet]
        public async Task<IActionResult> GetTypesPaymentsForId(int id)
        {
            try
            {
                var typePayment = await _repository.Get(id);
                return Ok(typePayment);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }

        [Route("typespayments"), HttpGet]
        public async Task<IActionResult> GetTypesPayments()
        {
            var typesPayments = await _repository.GetList();
            return Ok(typesPayments);
        }

        [Route("typespayments"), HttpPut]
        public async Task<IActionResult> UpdateTypePayment([FromBody] TypePayment typePayment)
        {
            try
            {
                return Ok(await _repository.Update(typePayment));
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
            catch(KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }
    }
}
