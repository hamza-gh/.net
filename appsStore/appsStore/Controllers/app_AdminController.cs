using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appsStore.Models;

namespace appsStore.Controllers
{
    public class app_AdminController : Controller
    {
        magasin_appEntities1 ctx = new magasin_appEntities1();
        // GET: App
        public ActionResult app_admin()
        {
            IList<app> applist = ctx.app.ToList<app>();

            return View(applist);
        }

       
        // GET: app_Admin/Create
        public ActionResult Create()
        {

            app a = new app();
            return View(a);
        }

        // POST: app_Admin/Create
        [HttpPost]
        public ActionResult Create(app model, HttpPostedFileBase File1)
        {

            if (File1 != null && File1.ContentLength > 0)
            {
                model.image = new byte[File1.ContentLength]; // file1 to store image in binary formate  
                File1.InputStream.Read(model.image, 0, File1.ContentLength);


                ctx.app.Add(model);
                ctx.SaveChanges();
                return RedirectToAction("../app_Admin/app_admin");
            }
            else
                return View("../Error/Error");



        }

        // GET: app_Admin/Edit/5
        public ActionResult Edit(int id)
        {

            app a = ctx.app.Single<app>(b => b.id_app == id);
            return View(a);
            
        }

        // POST: app_Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,app newapp, HttpPostedFileBase File1)
        {
            
            try
            {
                app oldapp = ctx.app.Single<app>(b => b.id_app == id);
                
                // TODO: Add update logic here
                oldapp.id_app = newapp.id_app;
                oldapp.nom = newapp.nom;
                oldapp.taille = newapp.taille;
                
                if (File1 != null && File1.ContentLength > 0)
                {
                    newapp.image = new byte[File1.ContentLength]; // file1 to store image in binary formate  
                    File1.InputStream.Read(newapp.image, 0, File1.ContentLength);

                    oldapp.image = newapp.image;

                }
                oldapp.Liste_OS = newapp.Liste_OS;
                oldapp.editeur = newapp.editeur;
                oldapp.categorie = newapp.categorie;
                oldapp.prix = newapp.prix;
                ctx.SaveChanges();

                return RedirectToAction("../app_Admin/app_admin");
            }
            catch
            {
                return View("../Error/Error");
            }
        }

        // GET: app_Admin/Delete/5
        public ActionResult Delete(int id)
        {
            app a = ctx.app.Single<app>(b => b.id_app == id);
    
            return View(a);
        }

        // POST: app_Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                app a = ctx.app.Single<app>(b => b.id_app == id);
                ctx.app.Remove(a);
                ctx.SaveChanges();
                return RedirectToAction("../app_Admin /app_admin");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
