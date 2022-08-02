using AutoMapper;
using DomainService.Models;
using DomainService.Models.Interface;
using DomainService.Request;
using DomainService.Response;
using Infrastruture.Context;

namespace AplicationCore.Business
{
    public class PersonBusiness : IPerson
    {
        private readonly DataBaseContext _DbContext;
        private readonly IMapper _mapper;

        public PersonBusiness(DataBaseContext DbContext, IMapper mapper)
        {
            _DbContext = DbContext;
            _mapper = mapper;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PersonResponse> GetbyId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(PersonRequest request)
        {
            bool exist = (
                from u in _DbContext.Persons
                where
                    u.PhoneNumber == request.PhoneNumber
                    && u.Email == request.Email
                    && u.Password == request.Password
                select u
            ).Any();

            if (exist)
                throw new NotImplementedException("Pessoa já existe");
            
            var dataPerson = _mapper.Map<PersonModel>(request);
            dataPerson.Id = Guid.NewGuid();
            _DbContext.Add(_mapper.Map<PersonModel>(dataPerson));
            await _DbContext.SaveChangesAsync();
        }

        public Task Update(PersonRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
