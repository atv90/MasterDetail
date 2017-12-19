using MasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterDetail.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            northwindEntities entities = new northwindEntities();
            try
            {
                //muodostetaan lista asiakkaista
                List<Customers> model = entities.Customers.ToList();
                //palautetaan lista näkymänä
                return View(model);
            }
            finally
            {
                //resurssien vapautus
                entities.Dispose();
            }

            return View();
        }
    }
}