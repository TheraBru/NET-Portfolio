using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webbsida.Data;
using webbsida.Models;

namespace webbsida.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PortfolioDbContext _context;

    public HomeController(ILogger<HomeController> logger, PortfolioDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async void ViewBags(){
        List<Course>? Courses = await _context.Course.ToListAsync();
        List<Framework>? Frameworks = await _context.Framework.ToListAsync();
        List<Language>? Languages = await _context.Language.ToListAsync();
        List<Programs>? Programs = await _context.Programs.ToListAsync();
        List<Website>? Websites = await _context.Website.ToListAsync();
        List<WebsiteFramework>? WebsiteFrameworks = await _context.WebsiteFramework.ToListAsync();
        List<WebsiteLanguage>? WebsiteLanguages = await _context.WebsiteLanguage.ToListAsync();


        ViewBag.Courses = Courses;
        ViewBag.Frameworks = Frameworks;
        ViewBag.Languages = Languages;
        ViewBag.Programs = Programs;
        ViewBag.Websites = Websites;
        ViewBag.WebsiteFrameworks = WebsiteFrameworks;
        ViewBag.WebsiteLanguages = WebsiteLanguages;
    }

    // View for all albums
    public IActionResult Index()
    {
        ViewBags();
        
        return View();
    }

    [Authorize]
    public IActionResult Edit()
    {
        ViewBags();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
