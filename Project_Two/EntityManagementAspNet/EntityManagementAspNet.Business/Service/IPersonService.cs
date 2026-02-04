using EntityManagementAspNet.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagementAspNet.Business.Service
{
    public interface IPersonService
    {
        void add(CreatePersonRequest request);

        void delete(string name);

        List<PersonResponse> getAll();

        List<PersonResponse> search(string name);
    }
}
