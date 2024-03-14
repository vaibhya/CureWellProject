using CureWell.Models;

namespace CureWell.Repository
{
    public interface ISpecializationRepository
    {
        Task<Specialization> GetSpecializationByCode(string code);
        Task<List<Specialization>> GetAllSpecializations();
        Task<Specialization> AddSpecialization(Specialization doctor);
        Task<Specialization> UpdateSpecialization(Specialization doctor);
        Task<int> DeleteSpecialization(string code);

    }
}