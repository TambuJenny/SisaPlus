using DomainService.Request;
using DomainService.Response;

namespace DomainService.Interface
{
    public interface ICourse
    {
        Task Create(CourseRequest request);
        Task<List<CourseResponse>> GetAll();
    }
}
