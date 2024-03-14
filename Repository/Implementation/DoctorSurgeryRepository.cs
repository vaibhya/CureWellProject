using CureWell.Database;
using CureWell.Models;
using Microsoft.EntityFrameworkCore;

namespace CureWell.Repository
{
    public class DoctorSurgeryRepository : IDoctorSurgeryRepository
    {

        private readonly CureWellDbContext _cureWellDbContext;
        public DoctorSurgeryRepository(CureWellDbContext cureWellDbContext)
        {
            _cureWellDbContext = cureWellDbContext;
        }
        public async Task<Surgery> AddDoctorSurgery(Surgery surgery)
        {
            await _cureWellDbContext.Surgeries.AddAsync(surgery);
            await _cureWellDbContext.SaveChangesAsync();
            return surgery;
        }

        public async Task<int> DeleteDoctorSurgery(int id)
        {
            var surgery = await _cureWellDbContext.Surgeries.FindAsync(id);
            if (surgery == null)
            {
                throw new Exception();
            }
            _cureWellDbContext.Surgeries.Remove(surgery);
            await _cureWellDbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<List<Surgery>> GetAllSurgeries()
        {
            return await _cureWellDbContext.Surgeries.ToListAsync();
        }

        public async Task<Surgery> GetSurgeryById(int id)
        {
            return await _cureWellDbContext.Surgeries.FindAsync(id);
        }

        public async Task<Surgery> UpdateDoctorSurgery(Surgery surgery)
        {
            var surgery1 = await _cureWellDbContext.Surgeries.FindAsync(surgery.SurgeryID);
            if (surgery1 == null)
            {
                throw new Exception();
            }
            _cureWellDbContext.Entry(surgery1).CurrentValues.SetValues(surgery);
            await _cureWellDbContext.SaveChangesAsync();
            return surgery;
        }
    }
}