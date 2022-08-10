using AutoMapper;
using DomainService.Interface;
using DomainService.Models;
using DomainService.Request;
using DomainService.Response;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

namespace Services.Person
{
    public class StudentServices : IStudent
    {
        private DataBaseContext _context;
        private IMapper _mapper;

        public StudentServices(IMapper mapper, DataBaseContext DbContext)
        {
            _context = DbContext;
            _mapper = mapper;
        }

        public async Task Create(StudentRequest request)
        {
            bool existeStudent = await (
                from s in _context.Students
                where s.Person.Id == request.Person && s.StudentNumber == request.StudentNumber
                select s
            ).AnyAsync();

            if (existeStudent)
                    throw new NotImplementedException("Estudante já existe");
            
            var getPersonById = await (
                from p in _context.Persons
                where p.Id == request.Person
                select p
            ).FirstOrDefaultAsync();

             if (getPersonById == null)
                    throw new NotImplementedException("Pessoa não existe");

            var getCourseById = await _context.Courses.Where(c => c.Id == request.Course).FirstOrDefaultAsync();

            if (getCourseById == null)
                throw new NotImplementedException("Curso não existe");

            var student = new StudentModel();
            student.Person = getPersonById;
            student.Id =  Guid.NewGuid();
            student.StudentNumber = request.StudentNumber;
            student.Course = getCourseById;

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentResponse> GetStudent(Guid id)
        {
            var getStudent = await (
                from s in _context.Students
                where s.Id == id
                select s
            ).FirstOrDefaultAsync();

            if (getStudent == null)
                    throw new NotImplementedException("Estudante não existe");

            var response = _mapper.Map<StudentResponse>(getStudent);
            return response;
        }

        public Task<StudentResponse> Update(StudentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
