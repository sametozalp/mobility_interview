using EntityManagementAspNet.Business.Dtos;
using EntityManagementAspNet.Business.Service;
using EntityManagementAspNet.DataAccess.Abstract;
using EntityManagementAspNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagementAspNet.Business.Impl
{
    public class PersonServiceImpl : IPersonService
    {

        private IPersonDal _personDal;

        public PersonServiceImpl(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public void add(CreatePersonRequest request)
        {
            var person = new Person
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Age = request.Age
            };
            _personDal.Add(person);
        }

        public void delete(string name)
        {
            var person = _personDal.GetAll(p => p.Name == name).FirstOrDefault();
            if (person != null)
            {
                _personDal.Delete(person);
            }
        }

        public List<PersonResponse> getAll()
        {
            var persons = _personDal.GetAll();
            return persons.Select(p => new PersonResponse
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Age = p.Age

            }).ToList();
        }

        public List<PersonResponse> search(string name)
        {
            var persons = _personDal.GetAll(p => p.Name.Contains(name));
            return persons.Select(p => new PersonResponse
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Age = p.Age
            }).ToList();
        }
    }
}
