using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Producto
    {
        [Key] public int Id { get; set; } //Clave primaria
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        //Método para validar que los datos recibidos no esten vacios
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Descripcion) ||
                Precio <= 0)
                return false;
            return true;
        }
    }
}
