using System;
using System.Collections.Generic;

namespace companhia_aerea.Models;

public partial class Voo
{
    public int Id { get; set; }

    public int IdAeronave { get; set; }

    public int IdAeroportoOrigem { get; set; }

    public int IdAeroportoDestino { get; set; }

    public DateTime? Saida { get; set; }

    public DateTime? PrevisaoChegada { get; set; }

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Aeronave IdAeronaveNavigation { get; set; } = null!;

    public virtual Aeroporto IdAeroportoDestinoNavigation { get; set; } = null!;

    public virtual Aeroporto IdAeroportoOrigemNavigation { get; set; } = null!;

    public virtual ICollection<Passageiro> Passageiros { get; set; } = new List<Passageiro>();
}
