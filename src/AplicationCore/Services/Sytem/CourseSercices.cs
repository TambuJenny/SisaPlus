using AutoMapper;
using DomainService.Interface;
using DomainService.Models;
using DomainService.Request;
using DomainService.Response;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

namespace Services.System
{
    public class CourseSercices : ICourse
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public CourseSercices(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CourseRequest request)
        {
            bool existeCourse = await (from c in _context.Courses where c.NameCourse == request.NameCourse select c).AnyAsync();

            if(existeCourse)
                    throw new NotImplementedException("Courso já existe");

            var course = _mapper.Map<CourseModel>(request);
            course.Id = Guid.NewGuid();

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();   
        }

        public async Task Delete(Guid id)
        {
            var existeCourse = await (from c in _context.Courses where c.Id == id select c).FirstOrDefaultAsync();

            if(existeCourse== null)
                throw new NotImplementedException("Curso não existe");

            _context.Courses.Remove(existeCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CourseResponse>> GetAll()
        {
            var getAllCourse = await _context.Courses.ToListAsync();

            if (getAllCourse == null)
                 throw new NotImplementedException("Curso não existe");
            
            return _mapper.Map<List<CourseResponse>>(getAllCourse);
        }
    }
}
