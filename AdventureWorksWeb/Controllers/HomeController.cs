using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace AdventureWorksWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(AdventureWorksBLL.ProductController.GetProductList().ToDataSourceResult(request));
        }

        public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, AdventureWorksModel.Product.Product_dto product)
        {
            product.IsDirty = true;
            var retVal = AdventureWorksBLL.ProductController.Save(product);

            return Json(AdventureWorksBLL.ProductController.GetProductList().ToDataSourceResult(request));
        }

        public ActionResult Products_Add([DataSourceRequest]DataSourceRequest request, AdventureWorksModel.Product.Product_dto product)
        {
            product.IsNew = true;
            var retVal = AdventureWorksBLL.ProductController.Save(product);
            return Json(AdventureWorksBLL.ProductController.GetProductList().ToDataSourceResult(request));
        }

    }
}