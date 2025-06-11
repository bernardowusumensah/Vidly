using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        /// <summary>
        /// The Index action method for the Movies controller.
        public ActionResult Index()
        {
            return View();
        }
    }
}