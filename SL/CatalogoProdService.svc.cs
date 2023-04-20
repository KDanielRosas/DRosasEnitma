using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CatalogoProdService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CatalogoProdService.svc or CatalogoProdService.svc.cs at the Solution Explorer and start debugging.
    public class CatalogoProdService : ICatalogoProdService
    {
        public List<ML.CatalogoProducto> GetAll()
        {
            List<ML.CatalogoProducto> list = BL.CatalogoProducto.GetAll();

            return list;
        }//GetAll

        public bool Add(string descripcion)
        {
            return BL.CatalogoProducto.Add(descripcion);
        }//Add
    }
}
