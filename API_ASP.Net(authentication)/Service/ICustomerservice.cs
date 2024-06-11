using API_ASP.Net_authentication_.Helper;
using API_ASP.Net_authentication_.Modal;
using API_ASP.Net_authentication_.Repos.Models;

namespace API_ASP.Net_authentication_.Service
{
    public interface ICustomerservice
    {
       Task< List<CustomerModal> >Getall();
       Task<CustomerModal> GetbyCode(int code);
       Task<APIResponse> Remove(int code);
       Task<APIResponse> Create(CustomerModal data);
       Task<APIResponse> Update(CustomerModal data, int code);
    }
}
