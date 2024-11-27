using System;
using System.Collections.Generic;

namespace companhia_aerea.Models;

public partial class Poltrona
{
    public int Id { get; set; }

    public int IdAeronave { get; set; }

    public bool? Disponivel { get; set; }

    public string? Localizacao { get; set; }

    public virtual Aeronave IdAeronaveNavigation { get; set; } = null!;

    public virtual ICollection<Passageiro> Passageiros { get; set; } = new List<Passageiro>();
}
