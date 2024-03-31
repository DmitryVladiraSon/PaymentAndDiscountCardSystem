using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemDomain.Enum;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystemService.Customers.Implementation
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ILogger<CustomerQueryService> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerQueryService(ICustomerRepository customerRepository, ILogger<CustomerQueryService> logger)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public async Task<IBaseResponse<Customer>>? GetById(Guid customerId)
        {
            var response = new BaseResponse<Customer>();
            var customer = await _customerRepository.Get(customerId);
            response.Data = customer;
            string log = string.Empty;
            if (customer != null)
            {
                log = $"Customer found with id: {customerId}";
                _logger.LogInformation(log);

                response.StatusCode = StatusCode.OK;
                response.Description = log;
                
                return response;
            }
            else
            {
                log = $"Customer not found with id: {customerId}";
                _logger.LogError(log);

                response.StatusCode = StatusCode.BadRequest;
                response.Description = log;

                return response;
            }
        }

        public async Task<IBaseResponse<Customer>>? GetByName(string name)
        {
            var response = new BaseResponse<Customer> ();
            var log = string.Empty;
            var customer = await _customerRepository.GetByName(name);
           
            response.Data = customer;

            if (customer != null)
            {
                log = $"Customer found with name: {name}";
                _logger.LogInformation(log);

                response.StatusCode = StatusCode.OK;
            }
            else
            {
                log = $"Customer not found with name: {name}";
                _logger.LogError(log);

                response.StatusCode = StatusCode.BadRequest;
            }
            return response;

        }
    }
}
