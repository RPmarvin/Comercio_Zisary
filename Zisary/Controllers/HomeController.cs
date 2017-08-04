using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zisary.Controllers
{
    public class HomeController : Controller
    {
        private Models.TiendaEntities bd = new Models.TiendaEntities();
        // GET: HomeD:\e-commer\proyectoZ\ComercioElectronico\Zisary\Views\Home\
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Buscar(String id=" ")
        {
            //logica de acceso a base de datos
            var productos = bd.Producto.Where(x=>x.Tag.Contains(id)).Take(20).ToList();
            ViewBag.clave = id;
            //lista de productos
            return View(productos);
        }
    }
}