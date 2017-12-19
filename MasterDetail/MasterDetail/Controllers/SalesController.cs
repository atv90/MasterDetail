using MasterDetail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public ActionResult GetOrderData(string id)
        {
            northwindEntities entities = new northwindEntities();
            try
            {
                List<Orders> orders = (from o in entities.Orders
                                       where o.CustomerID == id
                                       orderby o.OrderDate descending
                                       select o).ToList();
                StringBuilder html = new StringBuilder();
                html.Append("Hello World!");

                var jsonData = new { html = html.ToString() };
                return Json(jsonData,JsonRequestBehavior.AllowGet);
            }
            finally
            {
                //resurssien vapautus
                entities.Dispose();
            }
        }
    }
}