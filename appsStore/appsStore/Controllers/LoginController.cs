using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appsStore.Models;
using System.Data.SqlClient;

namespace appsStore.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd= new SqlCommand();
       
    
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
               return View();
        }
        void connectionString()
        {
            cnx.ConnectionString = @"Data Source=LV-Y\SQLEXPRESS;Initial Catalog=magasin_app;Integrated Security=True";
        }
        [HttpPost]
        public ActionResult Verify(account acc)
        {

            /*try { 
                connectionString();
                cnx.Open();


                cmd.Connection = cnx;
                cmd.CommandText = "select * from login l,utilisateur u, personne p where u.id_per=p.id_per and p.id_per=l.id_p and u.login='" + acc.login + "' and u.password='" + acc.password + "'";

                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    return RedirectToAction("../App/index");
                }
                else
                {
                    cmd.CommandText = "select * from login l, admin a, personne p  where a.id_per = p.id_per and p.id_per = l.id_p and p.id_per = l.id_p and u.login = '" + acc.login + "' and u.password = '" + acc.password + "'";
                    drr = cmd.ExecuteReader();
                    if (drr.Read())
                    {
                        return RedirectToAction("../app_Admin/app_admin");
                    }
                    else
                {
                    return View("../Error/Error");
                }

                }

                cnx.Close();

            }
            catch
            {
                return View("../Error/Error");

            }*/

            connectionString();
            cnx.Open();


            cmd.Connection = cnx;
            cmd.CommandText = "select count(*) from login l,utilisateur u, personne p where u.id_per=p.id_per and p.id_per=l.id_p and u.login='" + acc.login + "' and u.password='" + acc.password + "'";
            int u =int.Parse(cmd.ExecuteScalar().ToString());

            

            if(u==1)
            {
                return RedirectToAction("../App/index");
            }
            else if (u==0)
            {
                

                cmd.CommandText = "select count(*) from login l, admin a, personne p  where a.id_per = p.id_per and p.id_per = l.id_p and p.id_per = l.id_p and a.login = '" + acc.login + "' and a.password = '" + acc.password + "'";
                int a = int.Parse(cmd.ExecuteScalar().ToString());
                if(a==1)
                {
                    return RedirectToAction("../app_Admin/app_admin");
                }
                else
                    return View("../Error/Error");
            }
            else
            {
                return View("../Error/Error");
            }


        }
       
    }
}
