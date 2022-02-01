using bfitapi.Data.IServices;
using bfitapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.RepositoryServices
{
    public class IngredientsRepository : IIngredientRepository
    {
        private readonly BfitContext _context;
        public IngredientsRepository(BfitContext context)
        {
            _context = context;
        }
        public async Task<Ingredient> Create(Ingredient ingredient)
        {
            try
            {
                _context.Ingredients.Add(ingredient);
                await _context.SaveChangesAsync();
                return await Get(ingredient.Id);
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Ingredient> Delete(int key)
        {
            var ingredient = await Get(key);
            try
            {
                _context.Ingredients.Remove(ingredient);
                await _context.SaveChangesAsync();
                return ingredient;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<Ingredient> Get(int key)
        {
            var ingredient = await _context.Ingredients
                 .SingleOrDefaultAsync(ingredient => ingredient.Id == key);
            if (ingredient == null)
            {
                throw new KeyNotFoundException("Ingredient not found");
            }
            return ingredient;
        }

        public async Task<IEnumerable<Ingredient>> GetList()
        {
            return await _context.Ingredients
                .OrderBy(ingredient => ingredient.Description)
                .ToListAsync();
        }

        public async Task<Ingredient> Update(Ingredient ingredient)
        {
            await Get(ingredient.Id);
            try
            {
                _context.ChangeTracker.Clear();
                _context.Ingredients.Update(ingredient);
                await _context.SaveChangesAsync();
                return ingredient;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }
    }
}
