using CureWell.Database;
using CureWell.Models;
using Microsoft.EntityFrameworkCore;

namespace CureWell.Repository
{
    public class DoctorSpecializationRepository : IDoctorSpecializationRepository
    {
        private readonly CureWellDbContext _cureWellDbContext;

        public DoctorSpecializationRepository(CureWellDbContext cureWellDbContext)
        {
            _cureWellDbContext = cureWellDbContext;
        }
        public async Task<DoctorSpecialization> AddDoctorSpecialization(DoctorSpecialization doctorSpecialization)
        {
            await _cureWellDbContext.DoctorSpecializations.AddAsync(doctorSpecialization);
            await _cureWellDbContext.SaveChangesAsync();
            return doctorSpecialization;
        }

        public async Task<int> DeleteDoctorSpecialization(int doctorId, string specializationCode)
        {
            var specialization = await _cureWellDbContext.DoctorSpecializations.FirstOrDefaultAsync(x=>x.DoctorID==doctorId && x.SpecializationCode==specializationCode);
            if (specialization == null)
            {
                throw new Exception();
            }
            _cureWellDbContext.DoctorSpecializations.Remove(specialization);
            await _cureWellDbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<List<DoctorSpecialization>> GetAllDoctorSpecializations()
        {
             return await _cureWellDbContext.DoctorSpecializations.ToListAsync();
        }

        public async Task<DoctorSpecialization> UpdateDoctorSpecialization(DoctorSpecialization doctorSpecialization)
        {
            var specialization = await _cureWellDbContext.DoctorSpecializations.FirstOrDefaultAsync(x=>x.DoctorID==doctorSpecialization.DoctorID && x.SpecializationCode==doctorSpecialization.SpecializationCode);
            if (specialization == null)
            {
                throw new Exception();
            }

            _cureWellDbContext.Entry(specialization).CurrentValues.SetValues(doctorSpecialization);
            await _cureWellDbContext.SaveChangesAsync();

            return doctorSpecialization;
        }
    }
}