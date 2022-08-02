using DomainService.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DomainService.Models.Interface
{
    public interface IPerson
    {
        Task Create (PersonDTO request);
        Task<PersonDTO> GetbyId(Guid id);
        Task<List<PersonDTO>> GetAll();
        Task Update(PersonDTO request);
        Task Delete(Guid id);
    }
}
