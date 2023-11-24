using Microsoft.AspNetCore.Mvc;

namespace TimeStamp_and_Concurrency_Check.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
