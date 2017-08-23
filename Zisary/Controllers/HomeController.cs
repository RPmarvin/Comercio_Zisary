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
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
        public ActionResult Secion(string usuario, string clave)
        {
            var u = bd.Cliente.FirstOrDefault(x => x.Usuario == usuario && x.Clave == clave);
            if (u != null)
            {
                Helper.SessionHelper.AddUserToSession(u.ClienteId.ToString());
            }
            return RedirectToAction("Buscar", "Home");
        }
         public ActionResult Logout()
        {
            Helper.SessionHelper.DestroyUserSession();
            return RedirectToAction("Index","Home");
        }
        public ActionResult RegistrarCliente(Models.Cliente c)
        {
            bd.Cliente.Add(c);
            bd.SaveChanges();
            Helper.SessionHelper.AddUserToSession(c.ClienteId.ToString());
            return RedirectToAction("Index", "Home");
        }
        //public static string GetUsuario()
        //{
        //    //using (var b = new Models.TiendaEntities())
        //    //{
        //    //    return b.Cliente.Find(Helper.SessionHelper.GetUser()).Nombres;
        //    //}
        //}
    }
}