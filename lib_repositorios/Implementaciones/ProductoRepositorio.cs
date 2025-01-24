
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private Conexion? conexion = null;

        //Metodo constructor: Recibe los objetos por inyección de dependencias
        public ProductoRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        //Metodo para configurar el stringConexion de la conexion
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public Producto Borrar(Producto entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios(); //Confirmar los cambios en la db
            return entidad;
        }

        public List<Producto> Buscar(Expression<Func<Producto, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Producto Guardar(Producto entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios(); //Confirmar los cambios en la db
            return entidad;
        }

        public List<Producto> Listar()
        {
            return Buscar(x => x != null);
        }

        public Producto Modificar(Producto entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios(); //Confirmar los cambios en la db
            return entidad;
        }
    }
}
