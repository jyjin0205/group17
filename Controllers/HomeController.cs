using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using iCARE.Models;


namespace iCARE.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly Group17ICaredbContext _context;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

        _context = new Group17ICaredbContext();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var geoCodeData = _context.GeoCodes.ToList();
        return View(geoCodeData);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
