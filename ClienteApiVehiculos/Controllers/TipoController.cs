using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BaseServicios;
using ClienteApiVehiculos.Models;
using Microsoft.Practices.Unity;

namespace ClienteApiVehiculos.Controllers
{
    public class TipoController : Controller
    {
        [Dependency]
        public IServiciosRest<TipoVehiculo> Servicio { get; set; }
        // GET: Tipo
        public ActionResult Index()
        {
            var data = Servicio.Get();
            return View(data);
        }

        public ActionResult Alta()
        {
            return View(new TipoVehiculo());
        }

        [HttpPost]
        public async Task<ActionResult> Alta(TipoVehiculo model)
        {
            var data = await Servicio.Add(model);

            return RedirectToAction("Index");
        }
    }
}