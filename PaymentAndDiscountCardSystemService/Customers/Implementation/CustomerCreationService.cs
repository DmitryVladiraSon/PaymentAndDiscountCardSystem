using Microsoft.Extensions.Logging;
using PaymentAndDiscountCardSystem.Domain.Response;
using PaymentAndDiscountCardSystemDAL.Repositories.CustomerRepository;
using PaymentAndDiscountCardSystemDomain.Entity.Customers;
using PaymentAndDiscountCardSystemDomain.Enum;
using PaymentAndDiscountCardSystemService.Customers.Interfaces;

namespace PaymentAndDiscountCardSystemService.Customers.Implementation
{
    public class CustomerCreationService : ICustomerCreationService
    {
        private readonly ILogger<CustomerCreationService> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerQueryService _customerQueryService;

        public CustomerCreationService(
            ICustomerRepository customerRepository,
            ICustomerQueryService customerQueryService,
            ILogger<CustomerCreationService> logger)
        {
            _customerRepository = customerRepository;
            _customerQueryService = customerQueryService;
            _logger = logger;
        }

        public async Task<IBaseResponse<Guid>> Create(CustomerViewModel customerViewModel)
        {
            var response = new BaseResponse<Guid>();
            var log = string.Empty;

            var customer = await _customerQueryService.GetByName(customerViewModel.Name);
            if(customer.Data != null)
            {
                log = $"User creation failed. Username '{customerViewModel.Name}' is already taken.";
                _logger.LogError(log);

                response.Description = log;
                response.StatusCode = StatusCode.BadRequest;
                return response;
            }

            var customerId = await _customerRepository.Create(customerViewModel);
            
            if (customerId != null)
            {
                log = $"Customer created: {customerViewModel.Name}";
                _logger.LogInformation(log);

                response.StatusCode = StatusCode.OK;
            }
            else
            {
                log = $"Customer DID NOT created: {customerViewModel.Name}";
                _logger.LogError(log);

                response.StatusCode = StatusCode.BadRequest;
            }

            response.Data = customerId;
            response.Description = log;

            return response;
        }
        public async Task<IBaseResponse<Customer>> Update(Guid customerId, CustomerViewModel customerViewModel)
        {
            var response = new BaseResponse<Customer>();
            var customer = await _customerRepository.Update(customerId, customerViewModel);
            
            response.Data = customer;
            return response;
        }
        public async Task<IBaseResponse<bool>> Delete(Guid customerId)
        {

            var customer = await _customerRepository.Get(customerId);
            var response = new BaseResponse<bool>()
            { 
                Data = await _customerRepository.Delete(customerId),
            };
            return response; 
}



        public async Task<IBaseResponse<Customer>> Update(Customer customer)
        {
            var response = new BaseResponse<Customer>();
            var customer2 =  await _customerRepository.Update(customer);
            response.Data = customer2;
            return response;
        }
    }
}
