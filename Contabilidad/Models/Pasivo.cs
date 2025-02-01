using System;
using System.Collections.Generic;

namespace Contabilidad.Models;

public partial class Pasivo
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Monto { get; set; }
}
