using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CatalogoProducto
    {
        public static List<ML.CatalogoProducto> GetAll()
        {
            List<ML.CatalogoProducto> list = new List<ML.CatalogoProducto>();

            try
            {
                using (DL.DRosasEnitmaDBEntities context = new DL.DRosasEnitmaDBEntities())
                {
                    var query = context.sp_GetAllCatalogoProd().ToList();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.CatalogoProducto producto = new ML.CatalogoProducto();
                            producto.IdProducto = item.IdProducto;
                            producto.Descripcion = item.Descripcion;
                            producto.IdUsuario = item.IdUsuario.Value;
                            producto.FechaCreacion = item.FechaCreacion.Value;

                            list.Add(producto);
                        }                                               
                    }
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return list;
        }//GetAll

        public static ML.CatalogoProducto GetById(int idProducto)
        {
            using (DL.DRosasEnitmaDBEntities context = new DL.DRosasEnitmaDBEntities())
            {
                var query = context.sp_GetByIdCatalogoProd(idProducto).FirstOrDefault();

                if (query != null)
                {
                    ML.CatalogoProducto producto = new ML.CatalogoProducto();
                    producto.IdProducto = query.IdProducto;
                    producto.Descripcion = query.Descripcion;
                    producto.FechaCreacion = query.FechaCreacion.Value;
                    producto.IdUsuario = query.IdUsuario.Value;

                    return producto;
                }
                else
                {
                    return null;
                }
            }
        }//GetById

        public static bool Add(string descripcion)
        {
            try
            {
                using (DL.DRosasEnitmaDBEntities context = new DL.DRosasEnitmaDBEntities())
                {
                    int query = context.sp_InsCatalogoProd(descripcion);

                    return query > 0;

                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }//Add

        public static bool Update(int idProducto, string descripcion)
        {
            using (DL.DRosasEnitmaDBEntities context = new DL.DRosasEnitmaDBEntities())
            {
                int query = context.sp_UpdCatalogoProd(idProducto, descripcion);

                return query > 0;
            }
        }//Update
    }
}
