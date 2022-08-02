using DomainService.Request;
using DomainService.Response;
using Microsoft.AspNetCore.Mvc;

namespace DomainService.Models.Interface
{
    public interface IPerson
    {
        Task Create (PersonRequest request);
        Task<PersonResponse> GetbyId(Guid id);
        Task<List<PersonResponse>> GetAll();
        Task Update(PersonRequest request);
        Task Delete(Guid id);
    }
}
