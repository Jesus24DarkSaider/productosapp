using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductoES.Models;
using ProductoES.Repository;

namespace ProductoES.Controllers
{
    public class ProveedorController : ApiController
    {
        [System.Web.Http.Route("es/proveedor/v1")]
        [System.Web.Http.HttpGet]
        public ProveedorResponse consultarProveedor()
        {
            ProveedorResponse response = new ProveedorResponse();
            RespuestaType respuestaType = new RespuestaType();
            try
            {
                using (dbproductos db = new dbproductos())
                {
                    var proveedores = db.Database.SqlQuery<ProveedorModels>
                        ("SPlistarProveedores").ToList();
                    response.listaProveedores = proveedores;
                    respuestaType.Codigo = 200;
                    respuestaType.Descripcion = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                respuestaType.Codigo = 500;
                respuestaType.Descripcion = ex.ToString();
            }
            response.respuesta = respuestaType;
            return response;
        }
    }
}