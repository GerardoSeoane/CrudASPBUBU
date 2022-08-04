using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;

namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        Negocio negocio = new Negocio();
        // GET: Home
        public ActionResult Mostrar()
        {
            TempData["Mensaje"] = "";
            List<ModelPersonas> Lista = negocio.Mostrar();
            return View(Lista);
        }
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ModelPersonas datos)
        {
            TempData["Mensaje"] = "Error al Agregar";
            string respuesta = negocio.Agregar(datos.Nombre, datos.Nacionalidad, datos.Fecha);
            List<ModelPersonas> Lista = negocio.Mostrar();
            if (respuesta== "Agregado con Exito")
            {
                TempData["Mensaje"] = respuesta;
            }
            return View("Mostrar",Lista);
        }




        public ActionResult Actualizar(int id)
        {
            ModelPersonas Persona = negocio.BuscarById(id);
            return View(Persona);
        }

        [HttpPost]
        public ActionResult Actualizar(ModelPersonas datos)
        {
            TempData["Mensaje"] = "Error al Actualizar";
            string respuesta = negocio.Actualizar(datos.id,datos.Nombre,datos.Nacionalidad,datos.Fecha);
            List<ModelPersonas> Lista = negocio.Mostrar();
            if (respuesta== "Actualizado exitosamente")
            {
                TempData["Mensaje"] = respuesta;
            }
            return View("Mostrar",Lista);
        }




        public ActionResult Borrar(int id)
        {
            ModelPersonas Persona = negocio.BuscarById(id);
            return View(Persona);
        }
        [HttpPost]
        public ActionResult Borrar(ModelPersonas datos)
        {
            TempData["Mensaje"] = "Error al Borrar";
            string respuesta = negocio.Borrar(datos.id);
            List<ModelPersonas> Lista = negocio.Mostrar();
            if (respuesta== "Borrado exitosamente")
            {
                TempData["Mensaje"] = respuesta;
            }
            return View("Mostrar",Lista);
        }
    }
}