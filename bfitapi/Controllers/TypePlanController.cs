using bfitapi.Data;
using bfitapi.Data.IServices;
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

        [Route("typesPlans"), HttpGet]
        public async Task<IActionResult> GetTypesPlans()
        {
            var typesPlans = await _repository.GetList();
            return Ok(typesPlans);
        }
    }
}
