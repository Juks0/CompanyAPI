using Company_APBD.Data;
using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Company_APBD.Services
{
    public class CountIncomeService : ICountIncomeService
    {
        private readonly DatabaseContext _context;

        public CountIncomeService(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("countIncome")]
        public async Task<decimal> CountPostedIncome()
        {
            var contractIndividualCustomers = await _context.ContractIndividualCustomers.ToListAsync();
            var contractCompanyCustmers = await _context.ContractCompanyCustmers.ToListAsync();

            decimal sum = 0;

            foreach (var contract in contractIndividualCustomers)
            {
                if (contract.isActive)
                {
                    sum += contract.Price;
                }
            }
            foreach (var contract in contractCompanyCustmers)
            {
                if (contract.isActive)
                {
                    sum += contract.Price;
                }
            }
            return sum;
        }
        
        [HttpGet("countUnpostedIncome")]
        public async Task<decimal> CountUnpostedIncome()
        {
            var contractsIndividualCustomers = await _context.ContractIndividualCustomers.ToListAsync();
            var contractsCompanyCustomers = await _context.ContractCompanyCustmers.ToListAsync();

            decimal sum = 0;

            foreach (var contract in contractsIndividualCustomers)
                    sum += contract.TotalToPay;
            
            foreach (var contract in contractsCompanyCustomers)
                    sum += contract.TotalToPay;
            
            
            return sum;
        
        }
    }
}