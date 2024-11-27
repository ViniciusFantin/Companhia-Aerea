using System;
using System.Collections.Generic;

namespace companhia_aerea.Models;

public partial class Aeroporto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Rua { get; set; }

    public int? Numero { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual ICollection<Voo> VooIdAeroportoDestinoNavigations { get; set; } = new List<Voo>();

    public virtual ICollection<Voo> VooIdAeroportoOrigemNavigations { get; set; } = new List<Voo>();
}
