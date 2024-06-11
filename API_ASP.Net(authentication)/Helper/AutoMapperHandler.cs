using API_ASP.Net_authentication_.Modal;
using API_ASP.Net_authentication_.Repos.Models;
using AutoMapper;


namespace API_ASP.Net_authentication_.Helper
{
    public class AutoMapperHandler: Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Test, CustomerModal>().ReverseMap();
            //.ForMember(item => item.Statusname,
            //opt => opt.MapFrom(item => (item.IsActive&&item.IsActive.Value) ? "Active" : "In Active"));
        }
    }
}
