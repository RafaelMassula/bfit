﻿using bfitapi.Data;
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
    public class TypePlanController : ControllerBase
    {
        private readonly ITypePlanRepository _repository;

        public TypePlanController(ITypePlanRepository repository)
        {
            _repository = repository;
        }

        [Route("typesPlans"), HttpPost]
        public async Task<IActionResult> CreateTypePlan([FromBody] TypePlan typePlan)
        {
            if (!ModelState.IsValid)
                return (IActionResult)Task.FromResult(typePlan);
            try
            {
                return Created("", await _repository.Create(typePlan));
            }
            catch (DbUpdateException error)
            {
                return BadRequest(error.Message);
            }
        }

        [Route("typesPlans/{id}"), HttpDelete]
        public async Task<IActionResult> DeleteTypePlan(int id)
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

        [Route("typesPlans/{id}"), HttpGet]
        public async Task<IActionResult> GetTypesPaymentsForId(int id)
        {
            try
            {
                var typePlan = await _repository.Get(id);
                return Ok(typePlan);
            }
            catch (KeyNotFoundException error)
            {
                return NotFound(error.Message);
            }
        }

        [Route("typesPlans"), HttpGet]
        public async Task<IActionResult> GetTypesPlans()
        {
            var typesPlans = await _repository.GetList();
            return Ok(typesPlans);
        }

        [Route("typesPlans"), HttpPut]
        public async Task<IActionResult> UpdateTypePlan([FromBody] TypePlan typePlan)
        {
            try
            {
                return Ok(await _repository.Update(typePlan));
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
