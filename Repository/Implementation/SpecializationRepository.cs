using CureWell.Database;
using CureWell.Models;
using Microsoft.EntityFrameworkCore;

namespace CureWell.Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly CureWellDbContext _cureWellDbContext;
        public SpecializationRepository(CureWellDbContext cureWellDbContext)
        {
            _cureWellDbContext = cureWellDbContext;
        }
        public async Task<Specialization> AddSpecialization(Specialization specialization)
        {
            await _cureWellDbContext.Specializations.AddAsync(specialization);
            await _cureWellDbContext.SaveChangesAsync();
            return specialization;
        }

        public async Task<int> DeleteSpecialization(string code)
        {
            var specialization = await _cureWellDbContext.Specializations.FindAsync(code);
            if (specialization == null)
            {
                throw new Exception();
            }
            _cureWellDbContext.Specializations.Remove(specialization);
            await _cureWellDbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<List<Specialization>> GetAllSpecializations()
        {
            return await _cureWellDbContext.Specializations.ToListAsync();
        }

        public async Task<Specialization> GetSpecializationByCode(string code)
        {
            return await _cureWellDbContext.Specializations.FindAsync(code);
        }

        public async  Task<Specialization> UpdateSpecialization(Specialization specialization)
        {
            var specialization1 = await _cureWellDbContext.Specializations.FindAsync(specialization.SpecializationCode);
            if (specialization1 == null)
            {
                throw new Exception();
            }
            _cureWellDbContext.Entry(specialization1).CurrentValues.SetValues(specialization);
            await _cureWellDbContext.SaveChangesAsync();
            return specialization;
        }
    }
}