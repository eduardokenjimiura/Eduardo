using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Using_Angular.Controllers
{
    /// <summary>
    /// Classe que realiza o gerencioamento do controller da entidade Carro
    /// </summary>
    public class CarroController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewCarro()
        {
            return PartialView("AddCarro");
        }

        public ActionResult AddCarro()
        {
            return PartialView("AddCarro");
        }
        public ActionResult listaCarro()
        {
            return PartialView("listaCarro");
        }

        public ActionResult EditCarro()
        {
            return PartialView("EditCarro");
        }

        public ActionResult DeleteCarro()
        {
            return PartialView("DeleteCarro");
        }
    }
}