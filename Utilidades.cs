using System;

namespace demo
{
    public class Producto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int ProveedorId { get; set; }
    }

    public class Proveedor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
