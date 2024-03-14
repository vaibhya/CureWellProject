using CureWell.Models;
using CureWell.Repository;

namespace CureWell.Service
{
    public class CureWellService : ICureWellService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorSpecializationRepository _doctorSpecializationRepository;
        private readonly IDoctorSurgeryRepository _doctorSurgeryRepository;
        private readonly ISpecializationRepository _specializationRepository;
        public CureWellService(IDoctorRepository doctorRepository,
        IDoctorSpecializationRepository doctorSpecializationRepository,
        IDoctorSurgeryRepository doctorSurgeryRepository,
        ISpecializationRepository specializationRepository
        )
        {
            _doctorRepository = doctorRepository;
            _doctorSpecializationRepository = doctorSpecializationRepository;
            _doctorSurgeryRepository = doctorSurgeryRepository;
            _specializationRepository = specializationRepository;
        }
        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            return await _doctorRepository.AddDoctor(doctor);
        }

        public async Task<int> DeleteDoctor(int DoctorId)
        {
            return await _doctorRepository.DeleteDoctor(DoctorId);
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _doctorRepository.GetAllDoctors();
        }

        public async Task<List<Specialization>> GetAllSpecialization()
        {
            return await _specializationRepository.GetAllSpecializations();
        }

        public async Task<List<Surgery>> GetAllSurgeryTypeForToday()
        {
            var todaySurgeries = new List<Surgery>();
            var surgeyList =await  _doctorSurgeryRepository.GetAllSurgeries();
            todaySurgeries = surgeyList.Where(x=>x.StartTime.Date==DateTime.Today.Date).ToList();
            return todaySurgeries;
        }

        public async Task<Doctor> UpdateDoctorDetails(Doctor doctor)
        {
            return await _doctorRepository.UpdateDoctor(doctor);
        }

        public async Task<Surgery> UpdateSurgery(Surgery surgery)
        {
            return await _doctorSurgeryRepository.UpdateDoctorSurgery(surgery);
        }

        public async Task<Surgery> AddSurgery(Surgery surgery)
        {
             return await _doctorSurgeryRepository.AddDoctorSurgery(surgery);
        }

        public async Task<Specialization> AddSpecialization(Specialization specialization)
        {
             return await _specializationRepository.AddSpecialization(specialization);
        }
    }
}