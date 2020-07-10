using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using appsStore.Controllers;

namespace appsStore.Controllers
{
    public class inscriptionController : Controller
    {
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
       
        public int a;
        

        // GET: inscription
        [HttpGet]
        public ActionResult inscription()
        {
            return View();

        }
        void connectionString()
        {
            cnx.ConnectionString = @"Data Source=LV-Y\SQLEXPRESS;Initial Catalog=magasin_app;Integrated Security=True";
        }

      
        [HttpPost]
        public ActionResult Create(inscription i)
        {


            try
            {

                connectionString();
                cnx.Open();


                cmd.Connection = cnx;

                cmd.CommandText = "select max(id_per)+1 from utilisateur";
                a = int.Parse(cmd.ExecuteScalar().ToString());



                cmd.Connection = cnx;


                cmd.CommandText = "insert into login values('" +int.Parse(a.ToString()) + "')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into personne values('" + int.Parse(a.ToString()) + "','" + i.nom + "','" + i.prenom + "')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into utilisateur values ('" + int.Parse(a.ToString()) + "','u','" + i.adress + "','" + i.login + "','" + i.password + "')";
                cmd.ExecuteNonQuery();


                return RedirectToAction("../Login/Login");




                cnx.Close();
            }
            catch
            {
                return RedirectToAction("../Error/Error");
            }
            

            
          
            
        }
    }

    }
