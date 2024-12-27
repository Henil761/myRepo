using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using xUnitExample.Service;

namespace xUnitExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IPrintService printService;
        public HomeController(IPrintService printService)
        {
            this.printService = printService;
        }
        public string Index(string data)
        {
            string aR = printService.Print(data);
            return aR;
        }
    }
}
