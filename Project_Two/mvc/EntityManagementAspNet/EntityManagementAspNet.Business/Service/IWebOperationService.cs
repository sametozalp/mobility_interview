using EntityManagementAspNet.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagementAspNet.Business.Service
{
    public interface IWebOperationService
    {
        void add(CreateWebServiceOperationRequest request);

        void delete(string name);

        List<WebServiceOperationResponse> getAll();

        List<WebServiceOperationResponse> search(string name);
    }
}
