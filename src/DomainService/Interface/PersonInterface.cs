using DomainService.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DomainService.Models.Interface
{
    public interface PersonInterface
    {
        ActionResult<PersonModel> Post (PersonDTO request);
    }
}