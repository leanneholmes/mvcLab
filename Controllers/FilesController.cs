using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mvcLab.Controllers
{
    public class FilesController : Controller
    {

        private IWebHostEnvironment _hostEnvironment;

        public FilesController(IWebHostEnvironment environment) {
            _hostEnvironment = environment;
        }

        public IActionResult Index()
        {
        string webRootPath = _hostEnvironment.WebRootPath;
        string contentRootPath = _hostEnvironment.ContentRootPath;

        string[] files = Directory.GetFiles("./TextFiles").Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
            return View(files);
        }

        public IActionResult Content(string id)
        {
            StreamReader streamReader = System.IO.File.OpenText("./TextFiles/" + id + ".txt");
            string fileDetails = streamReader.ReadToEnd();
            ViewBag.Content = fileDetails;
            return View();
        }
    }
}