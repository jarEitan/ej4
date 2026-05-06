using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ej4.Models;

namespace ej4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Resultado(string nombre, int edad, int DNI, string trabaja, string tipoEmpleo, int ingresoMensual, string deudas, string[] tipoDeuda, int montoSolucitado, string plazo, bool aceptarTerminos)
    {
        bool si = true;
        if (edad <18){
            si = false;
        }
        else if (trabaja == "no")
        {
            si = false;
        }
        else if (ingresoMensual < 250000)
        {
            si = false;
        }
        else if (montoSolucitado < ingresoMensual * 5)
        {
            si = false;
        }
        else if (deudas == "si")
        {
            si = false;
        }
        else if (!aceptarTerminos)
        {
            si = false;
        }
        else
        {
            si = true;
        }

        ViewBag.si = si;

        return View();
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
