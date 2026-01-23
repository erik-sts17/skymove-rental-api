using Microsoft.AspNetCore.Mvc;
using SkyMove.Application.Dtos.Customer;
using SkyMove.Application.Services.Customers;

namespace SkyMove.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpPost]
        public async Task<IActionResult> Insert(CreateCustomerRequest request)
        {
            return Ok(await _customerService.Insert(request));
        }

    }
}
