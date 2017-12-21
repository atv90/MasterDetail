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
            NorthwindEntities entities = new NorthwindEntities();
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
            NorthwindEntities entities = new NorthwindEntities();
            try
            {
                List<Orders> orders = (from o in entities.Orders
                                       where o.CustomerID == id
                                       orderby o.OrderDate descending
                                       select o).ToList();
                StringBuilder html = new StringBuilder();
                html.AppendLine("<td colspan=\"5\">" +
                    "<table class=\"table table-striped\">");

                foreach (Orders order in orders)
                {
                    html.AppendLine("<tr><td>" +
                        order.OrderDate.Value.ToShortDateString() + "</td>" +
                        "<td>"+order.OrderID+"</td>"+
                        "<td>"+order.ShipCity+"</td>"+
                        "<td>"+order.RequiredDate.Value.ToShortDateString()+"</td></tr>");
                }
                  

               html.AppendLine("</table></td>");


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