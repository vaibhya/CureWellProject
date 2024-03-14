using CureWell.Database;
using CureWell.Models;
using Microsoft.EntityFrameworkCore;

namespace CureWell.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly CureWellDbContext _cureWellDbContext;
        public DoctorRepository(CureWellDbContext cureWellDbContext)
        {
            _cureWellDbContext = cureWellDbContext;
        }
        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            await _cureWellDbContext.Doctors.AddAsync(doctor);
            await _cureWellDbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<int> DeleteDoctor(int id)
        {
            var doctor = await _cureWellDbContext.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new Exception();
            }
            _cureWellDbContext.Doctors.Remove(doctor);
            await _cureWellDbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _cureWellDbContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _cureWellDbContext.Doctors.FindAsync(id);

        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            var doc = await _cureWellDbContext.Doctors.FindAsync(doctor.DoctorID);
            if (doc == null)
            {
                throw new Exception();
            }


            //doc.DoctorName = doctor.DoctorName;
            //_cureWellDbContext.Entry(doc).State = EntityState.Modified;
            _cureWellDbContext.Entry(doc).CurrentValues.SetValues(doctor);
            await _cureWellDbContext.SaveChangesAsync();
            return doc;

        }
    }
}