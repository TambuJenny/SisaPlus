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

        public async Task Delete(Guid idPerson)
        { 
            var getPerson = await (from u in _DbContext.Persons where u.Id == idPerson select u).FirstOrDefaultAsync();

            if (getPerson == null)
                throw new NotImplementedException("Pessoa não existe");

            _DbContext.Remove(getPerson);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<List<PersonResponse>> GetAll()
        {
            var getPersonById = await _DbContext.Persons.ToListAsync();

            return _mapper.Map<List<PersonResponse>>(getPersonById);
        }

        public async Task<PersonResponse> GetbyId(Guid idPerson)
        {
            var getPersonById = await _DbContext.Persons.Where(e => e.Id == idPerson).SingleOrDefaultAsync();
            
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
                    || u.Email == request.Email
                select u
            ).Any();

            if (exist)
                throw new NotImplementedException("Pessoa já existe");

            var dataPersonModel = _mapper.Map<PersonModel>(request);
            dataPersonModel.Id = Guid.NewGuid();

            _DbContext.Add(_mapper.Map<PersonModel>(dataPersonModel));
            await _DbContext.SaveChangesAsync();
        }

        public async Task Update(PersonResponse request)
        {
            bool existPerson = (from u in _DbContext.Persons where u.Id == request.Id select u).Any();
            
            if(!existPerson)
              throw new NotImplementedException("Pessoa não existe"); 
            
            bool existDataPerson =(
                from u in _DbContext.Persons
                where
                    u.PhoneNumber == request.PhoneNumber
                    || u.Email == request.Email
                select u
            ).Any();

            if(!existDataPerson)
              throw new NotImplementedException("Dados utilizado");
            

            var dataPersonModel = _mapper.Map<PersonModel>(request);
            dataPersonModel.ModifiedDate = DateTime.Now;
            
            _DbContext.Persons.Update(dataPersonModel);
            await  _DbContext.SaveChangesAsync(); 
        }
    }
}
