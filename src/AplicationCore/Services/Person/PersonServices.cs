using AutoMapper;
using DomainService.Models;
using DomainService.Models.Interface;
using DomainService.Request;
using DomainService.Response;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

namespace AplicationCore.Services
{
    public class PersonServices : IPerson
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;

        public PersonServices(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Delete(Guid idPerson)
        {
            var getPerson = await (
                from u in _context.Persons
                where u.Id == idPerson
                select u
            ).FirstOrDefaultAsync();

            if (getPerson == null)
                throw new NotImplementedException("Pessoa não existe");

            _context.Persons.Remove(getPerson);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PersonResponse>> GetAll()
        {
            var getPersonById = await _context.Persons.ToListAsync();

            return _mapper.Map<List<PersonResponse>>(getPersonById);
        }

        public async Task<PersonResponse> GetbyId(Guid idPerson)
        {
            var getPersonById = await _context.Persons
                .Where(e => e.Id == idPerson)
                .SingleOrDefaultAsync();

            if (getPersonById == null)
                throw new NotImplementedException("Pessoa não existe");

            return _mapper.Map<PersonResponse>(getPersonById);
        }

        public async Task Create(PersonRequest request)
        {
            bool exist = (
                from u in _context.Persons
                where u.PhoneNumber == request.PhoneNumber || u.Email == request.Email
                select u
            ).Any();

            if (exist)
                throw new NotImplementedException("Pessoa já existe");

            var dataPersonModel = _mapper.Map<PersonModel>(request);
            dataPersonModel.Id = Guid.NewGuid();

            _context.Persons.Add(_mapper.Map<PersonModel>(dataPersonModel));
            await _context.SaveChangesAsync();
        }

        public async Task Update(PersonResponse request)
        {
            bool existPerson = (
                from u in _context.Persons
                where u.Id == request.Id
                select u
            ).Any();

            if (!existPerson)
                throw new NotImplementedException("Pessoa não existe");

            bool existDataPerson = (
                from u in _context.Persons
                where u.PhoneNumber == request.PhoneNumber || u.Email == request.Email
                select u
            ).Any();

            if (!existDataPerson)
                throw new NotImplementedException("Dados utilizado");

            var dataPersonModel = _mapper.Map<PersonModel>(request);
            dataPersonModel.ModifiedDate = DateTime.Now;

            _context.Persons.Update(dataPersonModel);
            await _context.SaveChangesAsync();
        }
    }
}
