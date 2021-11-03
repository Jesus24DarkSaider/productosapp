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
    public class CategoriaController : ApiController
    {
        [System.Web.Http.Route("es/categoria/v1")]
        [System.Web.Http.HttpGet]
        public CategoriaResponse consultarCategorias()
        {
            CategoriaResponse response = new CategoriaResponse();
            RespuestaType respuestaType = new RespuestaType();
            try
            {
                using (dbproductos db = new dbproductos())
                {
                    var listadoCategoria = db.Database.SqlQuery<CategoriaModels>
                        ("SPlistarCategorias").ToList();
                    response.listadoCategorias = listadoCategoria;
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
