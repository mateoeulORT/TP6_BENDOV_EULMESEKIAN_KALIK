using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_BenDov_Eulmesekian_Kalik.Models;

namespace TP06_BenDov_Eulmesekian_Kalik.Controllers;

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
    public IActionResult Deportes()
    {
        ViewBag.ListaDeportes = DB.ListarDeportes();
        return View();
    }
    public IActionResult Paises()
    {
        ViewBag.ListaPaises = DB.ListarPaises();
        return View();
    }
    public IActionResult VerDetalleDeporte(int idDeporte)
    {
        ViewBag.DatosDeporte = DB.VerInfoDeporte(idDeporte);
        ViewBag.ListaDeportistasXDeporte = DB.ListarDeportistasXDeporte(idDeporte);
        return View();
    }
    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.DatosPais = DB.VerInfoPais(idPais);
        ViewBag.ListaDeportistasXPais = DB.ListarDeportistasXPais(idPais);
        return View();
    }
    public IActionResult VerDetalleDeporitsta(int idDeporitsta)
    {
        ViewBag.DatosDeportista = DB.VerInfoDeportista(idDeporitsta);
        return View();
    }
    public IActionResult AgregarDeportista()
    {
        ViewBag.ListaPaises = DB.ListarPaises();
        ViewBag.ListaDeportes = DB.ListarDeportes();
        return View();
    }
    public RedirectToActionResult GuardarDeportista(Deportista dep)
    {
        DB.AgregarDeportista(dep);
        return RedirectToAction("Index");
    }
    public RedirectToActionResult EliminarDeportista(int depId)
    {
        DB.EliminarDeportista(depId);
        return RedirectToAction("Index");
    }
    public ActionResult Creditos()
    {
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
