using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public string Test()
        {
            return "Hello Fanu!";
        }
    }
}