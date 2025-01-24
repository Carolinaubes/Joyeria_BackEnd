

using lib_aplicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_aplicaciones.Implementaciones
{
    public class ProductoAplicacion : IProductoAplicacion
    {
        private IProductoRepositorio? iProductoRepositorio = null;

        //Metodo constructor: Recibe el objeto por inyeccion de dependecias
        public ProductoAplicacion(IProductoRepositorio iProductoRepositorio)
        {
            this.iProductoRepositorio = iProductoRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iProductoRepositorio!.Configurar(string_conexion);
        }

        public Producto Borrar(Producto entidad)
        {
            if (entidad == null || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            if (entidad.Id == 0)
            {
                throw new Exception("lbNoSeGuardo");
            }

            entidad = iProductoRepositorio!.Borrar(entidad);
            return entidad;
        }

        public List<Producto> Buscar(Producto entidad)
        {
            Expression<Func<Producto, bool>> condiciones = null;

            //Solo se puede buscar por el nombre del Producto
            condiciones = x => x.Nombre!.Contains(entidad.Nombre);

            return iProductoRepositorio!.Buscar(condiciones);
        }

        public Producto Guardar(Producto entidad)
        {
            if (entidad == null || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            if (entidad.Id != 0)
            {
                throw new Exception("lbYaSeGuardo");
            }

            entidad = iProductoRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Producto> Listar()
        {
            return iProductoRepositorio!.Listar();
        }

        public Producto Modificar(Producto entidad)
        {
            if (entidad == null || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            if (entidad.Id == 0)
            {
                throw new Exception("lbNoSeGuardo");
            }

            entidad = iProductoRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}
