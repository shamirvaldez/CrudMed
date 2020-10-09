using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudMed.Models;
using CrudMed.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudMed.Controllers
{
    public class RegistroController : Controller
    {
        private readonly IRepository<Registro> _Registro;

        public RegistroController(IRepository<Registro> Registro)
        {
            _Registro = Registro;
        }



        // GET: Registro
        public ActionResult Index()
        {
            var valueList = _Registro.GetAll();

            return View(valueList);
        }

        // GET: Registro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registro registro)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _Registro.Insert(registro);
                    _Registro.Save();

                    
                }
                return RedirectToAction(nameof(Index));


            }
            catch
            {
                return View(nameof(Index));
            }
        }

        // GET: Registro/Edit/5

        public ActionResult Edit(int id)
        {
            if (id == 0)
            {

                BadRequest();
            }
           
           var registro = _Registro.GetId(id);
           return View(registro);
            
        }

        // POST: Registro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Registro registro)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
     
                    _Registro.Update(registro);
                    _Registro.Save();
                    return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            { 
                return View(ex.Message);
            }
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {

                BadRequest();
            }

            var registro = _Registro.GetId(id);
            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Registro registro)
        {
            try
            {
                // TODO: Add delete logic here
                if(id == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _Registro.Delete(id);
                _Registro.Save();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                
                return View(ex.Message);
            }
        }
    }
}