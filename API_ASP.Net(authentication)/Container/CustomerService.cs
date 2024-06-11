using API_ASP.Net_authentication_.Helper;
using API_ASP.Net_authentication_.Modal;
using API_ASP.Net_authentication_.Repos;
using API_ASP.Net_authentication_.Repos.Models;
using API_ASP.Net_authentication_.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_ASP.Net_authentication_.Container
{
    public class CustomerService : ICustomerservice
    {
        private readonly APIContext context;
        private readonly IMapper mapper;
        private readonly ILogger<CustomerService> logger;
        public CustomerService( APIContext context, IMapper mapper, ILogger<CustomerService> logger) 
        {
            this.mapper = mapper;
            this.context = context;
            this.logger = logger;
                
        }

        public async Task<APIResponse> Create(CustomerModal data)
        {
            APIResponse response = new APIResponse();
            try
            {
                this.logger.LogInformation("Create Begins");
                Test customer = this.mapper.Map<CustomerModal, Test>(data);
                await this.context.Tests.AddAsync(customer);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = data.Code;
            }
            catch(Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage= ex.Message;
                this.logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<List<CustomerModal>> Getall()
        {
            List<CustomerModal> response = new List<CustomerModal>();   
            var _data = await this.context.Tests.ToListAsync();
            if( _data != null)
            {
                response = this.mapper.Map<List<Test>,List<CustomerModal>>(_data);
            }
            return response;
                
        }

     


         public async Task<CustomerModal>GetbyCode(int code)
        {
            CustomerModal response = new CustomerModal();
            var _data = await this.context.Tests.FindAsync(code);
            if (_data != null)
            {
                response = this.mapper.Map<Test,CustomerModal>(_data);
            }
            return response;

        }

        public async Task<APIResponse> Remove(int code)
        {
            APIResponse response = new APIResponse();
            try
            {
                //Test customer = this.mapper.Map<CustomerModal, Test>(data);
                //await this.context.Tests.AddAsync(customer);
                //await this.context.SaveChangesAsync();
                var _customer = await this.context.Tests.FindAsync(code);
                if(_customer != null)
                {
                    this.context.Remove( _customer );
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Errormessage ="Data Not Found";
                }
                
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> Update(CustomerModal data, int code)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.Tests.FindAsync(code);
                if (_customer != null)
                {
                    _customer.Name = data.Name; 
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.IsActive = data.IsActive;
                    _customer.CreditLimit = data.CreditLimit;
                    await this.context.SaveChangesAsync();

                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 201;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Errormessage = "Data Not Found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
            }
            return response;
        }

       
    }
}
