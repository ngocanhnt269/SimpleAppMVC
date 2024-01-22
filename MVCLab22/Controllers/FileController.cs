using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCLab22.Models;

namespace MVCLab22.Controllers;

public class FileController : Controller
{
    private readonly ILogger<FileController> _logger;
    private readonly IWebHostEnvironment _evn;
    public FileController(ILogger<FileController> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _evn = env;
    }

    public IActionResult Index()
    {
        var path = Path.Combine(_evn.ContentRootPath, "TextFiles");

        ViewBag.Files = Directory.GetFiles(path);

        return View();
    }


    public IActionResult OpenFile(string fileName)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "TextFiles", fileName);

        if (System.IO.File.Exists(filePath))
        {
            var fileContent = System.IO.File.ReadAllText(filePath);

            return Content(fileContent, "text/plain");
        }
        else
        {
            return NotFound();
        }
    }

}

