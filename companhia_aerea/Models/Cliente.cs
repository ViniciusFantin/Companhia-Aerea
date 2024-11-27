using System;
using System.Collections.Generic;

namespace companhia_aerea.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Endereco { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public int? NumVoos { get; set; }

    public virtual ICollection<Passageiro> Passageiros { get; set; } = new List<Passageiro>();
}
