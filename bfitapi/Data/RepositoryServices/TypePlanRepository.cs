using bfitapi.Data.IServices;
using bfitapi.Data.Services;
using bfitapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.RepositoryServices
{
    public class TypePlanRepository : Services<TypePlan>, ITypePlanRepository
    {
        private readonly BfitContext _context;

        public TypePlanRepository(BfitContext bfitContext)
        {
            _context = bfitContext;
        }

        public async Task<TypePlan> Create(TypePlan typePlan)
        {
            try
            {
                await CheckExistenceOfRecord(typePlan);
                _context.Add(typePlan);
                await _context.SaveChangesAsync();

                return await Get(typePlan.Id);
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

          public async Task<TypePlan> Delete(int key)
        {
            var TypePlan = await Get(key);
            try
            {
                _context.TypesPlans.Remove(TypePlan);
                await _context.SaveChangesAsync();
                return TypePlan;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<TypePlan> Get(int key)
        {
            var typePlan = await _context.TypesPlans
                .SingleOrDefaultAsync(typePlan => typePlan.Id == key);
            if (typePlan == null)
            {
                throw new KeyNotFoundException("plan type not found.");
            }
            return typePlan;
        }

        public async Task<IEnumerable<TypePlan>> GetList()
        {
            return await _context.TypesPlans
                .OrderBy(typePlan => typePlan.Description)
                .ToListAsync();
        }

        public async Task<TypePlan> Update(TypePlan typePlan)
        {
            try
            {
                await Get(typePlan.Id);
                _context.ChangeTracker.Clear();
                _context.TypesPlans.Update(typePlan);
                await _context.SaveChangesAsync();
                return typePlan;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public override async Task CheckExistenceOfRecord(TypePlan typePlan)
        {
            var plansTypes = await GetList();

            foreach (var planType in plansTypes)
            {
                if (planType.Equals(typePlan))
                    throw new DbUpdateException("Plan type has already been registered.");
            }
            //procurar entender melhor sobre 
            _context.ChangeTracker.Clear();
        }

    }
}
