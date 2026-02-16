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
    public class WebOperationServiceImpl: IWebOperationService
    {

        private readonly IWebServiceOperationDal _webServiceOperationDal;

        public WebOperationServiceImpl(IWebServiceOperationDal webServiceOperationDal)
        {
            _webServiceOperationDal = webServiceOperationDal;
        }

        public void add(CreateWebServiceOperationRequest request)
        {
            var operation = new WebServiceOperation
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Age = request.Age
            };
            _webServiceOperationDal.Add(operation);
        }

        public void delete(string name)
        {
            var operation = _webServiceOperationDal.GetAll(o => o.Name == name).FirstOrDefault();
            if (operation != null)
            {
                _webServiceOperationDal.Delete(operation);
            }
        }

        public List<WebServiceOperationResponse> getAll()
        {
            var persons = _webServiceOperationDal.GetAll();
            return persons.Select(p => new WebServiceOperationResponse
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Age = p.Age

            }).ToList();
        }

        public List<WebServiceOperationResponse> search(string name)
        {
            var operations = _webServiceOperationDal.GetAll(o => o.Name.Contains(name));
            return operations.Select(o => new WebServiceOperationResponse
            {
                Id = o.Id,
                Name = o.Name,
                Surname = o.Surname,
                Email = o.Email,
                PhoneNumber = o.PhoneNumber,
                Age = o.Age
            }).ToList();
        }
    }
}
