
using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_aplicaciones.Interfaces
{
    public interface IProductoAplicacion
    {
        void Configurar(string string_conexion);
        List<Producto> Listar();
        List<Producto> Buscar(Producto entidad);
        Producto Guardar(Producto entidad);
        Producto Modificar(Producto entidad);
        Producto Borrar(Producto entidad);
    }
}
