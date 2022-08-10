using DomainService.Request;
using DomainService.Response;

namespace DomainService.Interface
{
    public interface ICourse
    {
        Task Create(CourseRequest request);
        Task Delete(Guid id);
        Task<List<CourseResponse>> GetAll();
    }
}
