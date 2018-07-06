using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Ozon.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            //string indexPath = Path.Combine(_env.WebRootPath, "/index.html");
            //return PhysicalFile(indexPath, "text/html");

            return File("index.html", "text/html");
        }
    }
}
