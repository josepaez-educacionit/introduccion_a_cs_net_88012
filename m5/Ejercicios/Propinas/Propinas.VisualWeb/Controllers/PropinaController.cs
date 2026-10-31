using Microsoft.AspNetCore.Mvc;
using Propinas.Core;
using Propinas.VisualWeb.Models;

namespace Propinas.VisualWeb.Controllers
{
    public class PropinaController : Controller
    {
        public IActionResult Index()
        {
            return View(new PropinaViewModel());
        }

        // POST /Propina: el usuario envió el formulario.
        // [ValidateAntiForgeryToken] protege el formulario contra envíos falsificados desde otros sitios.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PropinaViewModel modelo)
        {
            // Si algún dato no cumple las reglas del modelo, se vuelve a mostrar el formulario con los errores.
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            // Llegados aquí, los datos ya fueron validados: tienen valor y están dentro del rango.
            // GetValueOrDefault() convierte el decimal? en decimal.
            decimal monto = modelo.Monto.GetValueOrDefault();
            decimal porcentaje = modelo.Porcentaje.GetValueOrDefault() / 100m;

            CalculadoraPropina calculadora = new CalculadoraPropina(porcentaje);
            modelo.Detalle = calculadora.Calcular(monto);

            return View(modelo);
        }
    }
}
