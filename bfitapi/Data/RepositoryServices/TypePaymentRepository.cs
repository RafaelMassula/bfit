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
    public class TypePaymentRepository : Services<PaymentType>, ITypePaymentRepository
    {
        private readonly BfitContext _context;

        public TypePaymentRepository(BfitContext context)
        {
            _context = context;
        }
        public async Task<PaymentType> Create(PaymentType typePayment)
        {
            try
            {
                await CheckExistenceOfRecord(typePayment);
                _context.TypesPayments.Add(typePayment);
                await _context.SaveChangesAsync();

                return await Get(typePayment.Id);
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<PaymentType> Delete(int key)
        {
            var typePayment = await Get(key);

            try
            {
                _context.TypesPayments.Remove(typePayment);
                await _context.SaveChangesAsync();
                return typePayment;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public async Task<PaymentType> Get(int key)
        {
            var typepayment = await _context.TypesPayments
                .SingleOrDefaultAsync(typePayment => typePayment.Id == key);
            if (typepayment == null)
            {
                throw new KeyNotFoundException("Payment type not found.");
            }
            return typepayment;
        }

        public async Task<IEnumerable<PaymentType>> GetList()
        {
            return await _context.TypesPayments
                .OrderBy(typePayment => typePayment.Description)
                .ToListAsync();
        }

        public async Task<PaymentType> Update(PaymentType typePayment)
        {
            try
            {
                await Get(typePayment.Id);
                _context.ChangeTracker.Clear();
                _context.TypesPayments.Update(typePayment);
                await _context.SaveChangesAsync();
                return typePayment;
            }
            catch (DbUpdateException error)
            {
                throw new DbUpdateException(error.Message);
            }
        }

        public override async Task CheckExistenceOfRecord(PaymentType typePayment)
        {
            var paymentsTypes = await GetList();
         
                foreach (var paymentType in paymentsTypes)
                {
                    if (paymentType.Equals(typePayment))
                        throw new DbUpdateException("Payment type has already been registered.");
                }
            _context.ChangeTracker.Clear();
        }
    }
}
