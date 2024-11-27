using System;
using System.Collections.Generic;

namespace companhia_aerea.Models;

public partial class Passageiro
{
    public int IdCliente { get; set; }

    public int IdVoo { get; set; }

    public int? Passagem { get; set; }

    public int IdPoltrona { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Poltrona IdPoltronaNavigation { get; set; } = null!;

    public virtual Voo IdVooNavigation { get; set; } = null!;
}
