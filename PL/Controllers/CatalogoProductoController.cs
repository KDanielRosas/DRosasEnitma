using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CatalogoProductoController : Controller
    {
        // GET: CatalogoProducto
        public ActionResult GetAll()
        {
            var serv = new CatalogoProdServiceReference.CatalogoProdServiceClient();
            var result = serv.GetAll();
            ML.CatalogoProducto producto = new ML.CatalogoProducto();
            producto.Productos = new List<object>();
            foreach (var item in result)
            {
                producto.Productos.Add(item);
            }

            return View(producto);
        }

        public JsonResult GetById(int idProducto)
        {
            ML.CatalogoProducto producto = BL.CatalogoProducto.GetById(idProducto);
            return Json(producto);
        }

        [HttpPost]
        public JsonResult Add(string descripcion)
        {
            return Json(BL.CatalogoProducto.Add(descripcion));
        }

        [HttpPost]
        public JsonResult Update(int idProducto, string descripcion)
        {
            return Json(BL.CatalogoProducto.Update(idProducto,descripcion));
        }
    }
}