using System;
using System.Collections.Generic;

namespace companhia_aerea.Models;

public partial class Aeronave
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public int? Poltronas { get; set; }

    public string? Modelo { get; set; }

    public virtual ICollection<Poltrona> PoltronasNavigation { get; set; } = new List<Poltrona>();

    public virtual ICollection<Voo> Voos { get; set; } = new List<Voo>();
}
