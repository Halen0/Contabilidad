using System;
using System.Collections.Generic;

namespace Contabilidad.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Clave { get; set; }
}
