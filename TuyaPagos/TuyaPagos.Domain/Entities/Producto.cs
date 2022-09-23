﻿namespace TuyaPagos.Domain.Entities
{
    public class Producto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long Precio { get; set; }
        public int PorcentajeImpuesto { get; set; }
    }
}
