using System;
using System.Collections.Generic;

namespace Veterinaria.Models
{
    public partial class Comidum
    {
        public string IdComida { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Cantidad { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
