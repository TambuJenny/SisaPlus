using DomainService.Request;
using DomainService.Response;

namespace DomainService.Interface 
{
    public interface IStudent
    {
        Task Create (StudentRequest request);
        Task<StudentResponse> Update (StudentRequest request);
    
    }
    
}
