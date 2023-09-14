using System;
using System.Collections.Generic;

namespace Veterinaria.Models
{
    public partial class Dueño
    {
        public string Iddueños { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
    }
}
