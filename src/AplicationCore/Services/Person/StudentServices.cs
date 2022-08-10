using AutoMapper;
using DomainService.Interface;
using DomainService.Models.Person;
using DomainService.Request;
using DomainService.Response;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

namespace Services.Person
{
    public class StudentServices : IStudent
    {
        private  DataBaseContext _context;
        private  IMapper _mapper;

        public StudentServices(IMapper mapper, DataBaseContext DbContext)
        {
            _context = DbContext;
            _mapper = mapper;
        }

        public async Task Create(StudentRequest request)
        {
            bool existeStudent = (from s in _context.Students where s.Person.Id == request.Person.Id select s).Any(); 
            
            if(existeStudent)
                throw new NotImplementedException("Pessoa j� existe"); 

            await _context.AddAsync(_mapper.Map<StudentModel>(request));
            await _context.SaveChangesAsync();
            

        }

        public Task<StudentResponse> Update(StudentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
