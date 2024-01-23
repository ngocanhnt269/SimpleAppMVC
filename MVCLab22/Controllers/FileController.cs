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

        var files = Directory.GetFiles(path);
        for (int i = 0; i < files.Length; i++)
        {
            files[i] = Path.GetFileName(files[i]);
        }
        ViewBag.files = files;
        return View();
    }


    public IActionResult Content(string id)
    {
        var filePath = Path.Combine(_evn.ContentRootPath, "TextFiles", id);

        if (System.IO.File.Exists(filePath))
        {
            var fileContent = System.IO.File.ReadAllText(filePath);
            ViewBag.fileContent = fileContent;
            return View();
        }
        else
        {
            return NotFound();
        }
    }

}

