using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trabajo_n4.Models;

namespace Trabajo_n4.Controllers
{
    public class VeterinariaController : Controller
    {
        // GET: Veterinaria
        public VeterinariaEntities db = new VeterinariaEntities();

        public ActionResult Index()
        {
            ViewBag.Tservicios = (from servicios in db.servicio_tipos select servicios).ToList();

            return View();
        }

        // GET: Veterinaria/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Detalle = db.servicio_tipos.Where(p => p.id == id).ToList();

            return View();
        }

        // GET: Veterinaria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinaria/Create
        [HttpPost]
        public ActionResult Create(string nombre)
        {
            try
            {
                using (var Context = new VeterinariaEntities())
                {
                    var insert = Context.servicio_tipos
                    .FirstOrDefault(p => p.nombre == nombre);

                    if (insert == null)
                    {
                        insert.nombre = nombre;
                        Context.servicio_tipos.Add(insert);
                        Context.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Veterinaria/Edit/5
     
        public ActionResult Edit(int id)
        {
            ViewBag.Id = db.servicio_tipos
                .Where(p => p.id == id)
                .Select(s=> s.id)
                .Single();

            ViewBag.EditarNombre = db.servicio_tipos
                .Where(p => p.id == id)
                .Select(s => s.nombre)
                .Single();

            return View();
        }

        // POST: Veterinaria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string nombre)
        {
            try
            {

                using (var Context = new VeterinariaEntities())
                {
                    var edit = Context.servicio_tipos
                    .FirstOrDefault(p => p.id == id);

                    if (edit!= null)
                    {
                        edit.nombre = nombre;
                        Context.SaveChanges();
                    }                 

                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Veterinaria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Veterinaria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (var Context = new VeterinariaEntities())
                {
                    var delete = Context.servicio_tipos
                    .FirstOrDefault(p => p.id == id);

                    if (delete != null)
                    {
                        Context.servicio_tipos.Remove(delete);
                        Context.SaveChanges();
                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
