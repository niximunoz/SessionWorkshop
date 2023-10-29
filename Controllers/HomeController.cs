using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("dashboard")]
    public IActionResult Dashboard(User user)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetInt32("NumberSession", 22);
            return View("Dashboard");
        }
        return View("Index");
    }

    [HttpGet("LogOut")]
    public ViewResult LogOut()
    {
        HttpContext.Session.Clear();
        return View("Index");
    }

    [HttpGet("calculadora/{valor}")]
    public IActionResult Calculadora(string valor)
    {
        int numero = HttpContext.Session.GetInt32("NumberSession") ?? 0;
        if(valor == "sumar"){
            numero++;
        }else if(valor == "restar"){
            numero--;
        }else if(valor == "multiplicar"){
            numero = numero * 2;
        }else{
            var rand = new Random();
            numero = numero + rand.Next(1, 11);
        }
        HttpContext.Session.SetInt32("NumberSession", numero);
        return View("Dashboard");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
