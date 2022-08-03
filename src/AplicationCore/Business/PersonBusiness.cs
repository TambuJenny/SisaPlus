using AutoMapper;
using DomainService.Models;
using DomainService.Models.Interface;
using DomainService.Request;
using DomainService.Response;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task Delete(Guid id)
        { 
            var teste = await (from u in _DbContext.Persons where u.Id == id select u).FirstOrDefaultAsync();
            bool exist = (
            from u in _DbContext.Persons
            where
                u.Id == id
            select u
            ).Any();

            if (!exist)
                throw new NotImplementedException("Pessoa não existe");

           // _DbContext.Remove()
        }

        public async Task<List<PersonResponse>> GetAll()
        {
            var getPersonById = await _DbContext.Persons.ToListAsync();

            return _mapper.Map<List<PersonResponse>>(getPersonById);
        }

        public async Task<PersonResponse> GetbyId(Guid id)
        {
            var getPersonById = await _DbContext.Persons.Where(e => e.Id == id).SingleOrDefaultAsync();
            
            if(getPersonById == null)
                 throw new NotImplementedException("Pessoa não existe");

            return _mapper.Map<PersonResponse>(getPersonById);
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

        public async Task Update(PersonResponse request)
        {
            bool exist = (from u in _DbContext.Persons where u.Id == request.Id select u).Any();
            
            if(!exist)
              throw new NotImplementedException("Pessoa não existe"); 

            var dataPerson = _mapper.Map<PersonModel>(request);
            dataPerson.ModifiedDate = DateTime.Now;
            
            _DbContext.Persons.Update(dataPerson);
            await  _DbContext.SaveChangesAsync(); 
        }
    }
}
