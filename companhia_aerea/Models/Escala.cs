using System;
using System.Collections.Generic;

namespace companhia_aerea.Models;

public partial class Escala
{
    public int Id { get; set; }

    public int IdVoo { get; set; }

    public int IdAeroporto { get; set; }

    public DateTime? Saida { get; set; }

    public virtual Aeroporto IdAeroportoNavigation { get; set; } = null!;

    public virtual Voo IdVooNavigation { get; set; } = null!;
}
