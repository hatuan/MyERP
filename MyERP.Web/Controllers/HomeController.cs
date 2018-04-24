using System.Net;
using System.Web.Mvc;
using Ext.Net.MVC;
using MyERP.Web.Models;

namespace MyERP.Web.Controllers
{
    [AllowAnonymous]
    [DirectController]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        [OutputCache(Duration = 3600)]
        public ActionResult GetMenuNodes(string node)
        {
            if (node == "Root")
            {
                return this.Content(TreeMenusModel.GetTreeMenusNodes().ToJson());
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
        }
    }
}