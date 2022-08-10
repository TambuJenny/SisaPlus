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
            var existeStudent = await (
                from s in _context.Students
                where s.Person.Id == request.Person
                select s
            ).FirstOrDefaultAsync();

            if (existeStudent == null)
                    throw new NotImplementedException("Pessoa já existe");

            var getPersonById = await (
                from p in _context.Persons
                where p.Id == request.Person
                select p
            ).FirstOrDefaultAsync();

            existeStudent.Person = getPersonById;

            await _context.AddAsync(existeStudent);
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
