using Microsoft.AspNetCore.Mvc;
using Service.Implementation;
using Service.Interface;

namespace SecondHandEShop.Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentedService _rentedService;

        public RentController(IRentedService rentedService)
        {
            this._rentedService = rentedService;
        }

        //displays only when the product has been ordered and its availability is set to false
        [HttpGet]
        public IActionResult GetRented(string email)
        {
            return Ok(_rentedService.getRentedInfo(email));
        }

        [HttpDelete]
        public IActionResult DeleteFromRented(string email, int product)
        {
            return Ok(_rentedService.deleteProductFromRented(email, product));
        }
    }
}
