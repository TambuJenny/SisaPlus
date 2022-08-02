using AutoMapper;
using DomainService.DTO;
using DomainService.Models;
using DomainService.Models.Interface;
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

        public Task<List<PersonDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> GetbyId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(PersonDTO request)
        {
            bool exist = (
                from u in _DbContext.Persons
                where
                    u.Id == request.Id
                    && u.PhoneNumber == request.PhoneNumber
                    && u.Email == request.Email
                    && u.Password == request.Password
                select u
            ).Any();

            if (exist)
                throw new NotImplementedException("Pessoa já existe");

            _DbContext.Add(_mapper.Map<PersonModel>(request));
            await _DbContext.SaveChangesAsync();
        }

        public Task Update(PersonDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
