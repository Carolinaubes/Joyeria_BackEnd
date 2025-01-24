using asp_servicios.Nucleo;
using lib_aplicaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using lib_entidades.Modelos;
using Microsoft.AspNetCore.Cors;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[EnableCors("*")] esto es para dar acceso a cualquier servidor externo que quiera entrar al API
    public class ProductoController : ControllerBase
    {
        private IProductoAplicacion? iProductoAplicacion = null;

        //Metodo constructor del controller
        public ProductoController(IProductoAplicacion iProductoAplicacion)
        {
            this.iProductoAplicacion = iProductoAplicacion;
        }

        //Metodo que recibe el body de la solicitud
        private Dictionary<string, object> ObtenerDatos()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = new StreamReader(Request.Body).ReadToEnd().ToString(); //Lee el body, que deberia contener al bearer
                if (string.IsNullOrEmpty(datos))
                    datos = "{}";
                return JsonConversor.ConvertirAObjeto(datos); //Convierte el json en un diccionario
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return respuesta;
            }
        }

        [HttpPost(Name = "Listar")]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos(); //Obtiene el cuerpo de la solicitud
                this.iProductoAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));

                respuesta["Entidades"] = this.iProductoAplicacion!.Listar(); //lista de las entidades
                respuesta["Respuesta"] = "OK"; //Estado de la respueta
                respuesta["Fecha"] = DateTime.Now.ToString(); //Fecha de ejecución

                return JsonConversor.ConvertirAString(respuesta); //Convierto el objeto (diccionario) en un String
            } catch (Exception e)
            {
                respuesta["Error"] = e.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta); //Convierto el objeto (diccionario) en un String
            }
        }

        [HttpPost(Name = "Buscar")]
        public string Buscar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos(); //Obtiene el cuerpo de la solicitud
                if (datos == null) //REVISAR ESTO: COMO VALIDO SI UN DICCIONARIO ESTA VACIO O NO
                {
                    respuesta["Error"] = "lbFaltaDatosEnLaSolicitud";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                //La solicitud envia un json con la clave "Entidad", lo convierto a string y luego a objeto
                var entidad = JsonConversor.ConvertirAObjeto<Producto>(JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iProductoAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));

                respuesta["Entidades"] = this.iProductoAplicacion!.Buscar(entidad);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                return JsonConversor.ConvertirAString(respuesta);

            } catch (Exception e)
            {
                respuesta["Error"] = e.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta); //Convierto el objeto (diccionario) en un String
            }
        }

        [HttpPost(Name = "Borrar")]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();//Obtiene el cuerpo de la solicitud
                if (datos == null) //REVISAR ESTO: COMO VALIDO SI UN DICCIONARIO ESTA VACIO O NO
                {
                    respuesta["Error"] = "lbFaltaDatosEnLaSolicitud";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                //La solicitud envia un json con la clave "Entidad", lo convierto a string y luego a objeto
                var entidad = JsonConversor.ConvertirAObjeto<Producto>(JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iProductoAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));

                entidad = this.iProductoAplicacion!.Borrar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception e)
            {
                respuesta["Error"] = e.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost(Name = "Guardar")]
        public string Guardar() //NO FUNCIONA
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();//Obtiene el cuerpo de la solicitud
                if (datos == null) //REVISAR ESTO: COMO VALIDO SI UN DICCIONARIO ESTA VACIO O NO
                {
                    respuesta["Error"] = "lbFaltaDatosEnLaSolicitud";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                //La solicitud envia un json con la clave "Entidad", lo convierto a string y luego a objeto
                var entidad = JsonConversor.ConvertirAObjeto<Producto>(JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iProductoAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));

                entidad = this.iProductoAplicacion!.Guardar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception e)
            {
                respuesta["Error"] = e.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost(Name = "Modificar")]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();//Obtiene el cuerpo de la solicitud
                if (datos == null) //REVISAR ESTO: COMO VALIDO SI UN DICCIONARIO ESTA VACIO O NO
                {
                    respuesta["Error"] = "lbFaltaDatosEnLaSolicitud";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                //La solicitud envia un json con la clave "Entidad", lo convierto a string y luego a objeto
                var entidad = JsonConversor.ConvertirAObjeto<Producto>(JsonConversor.ConvertirAString(datos["Entidad"]));
                this.iProductoAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));

                entidad = this.iProductoAplicacion!.Modificar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();

                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception e)
            {
                respuesta["Error"] = e.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}
