using bfitapi.Data.IServices;
using bfitapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.Services
{
    public class TypePlanRepository : ITypePlanRepository
    {
        private readonly BfitContext _context;

        public TypePlanRepository(BfitContext bfitContext)
        {
            _context = bfitContext;
        }

        public Task<TypePlan> Create(TypePlan obj)
        {
            throw new NotImplementedException();
        }

        public Task<TypePlan> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<TypePlan> Get(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TypePlan>> GetList()
        {
            return await _context.TypesPlans
                .OrderBy(typePlan => typePlan.Description)
                .ToListAsync();
        }

        public Task<TypePlan> Update(TypePlan obj)
        {
            throw new NotImplementedException();
        }
    }
}
