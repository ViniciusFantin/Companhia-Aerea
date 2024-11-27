using System;
using System.Collections.Generic;

namespace companhia_aerea.Models;

public partial class Horario
{
    public int Id { get; set; }

    public int IdVoo { get; set; }

    public DateOnly? Data { get; set; }

    public TimeOnly? InicioHorario { get; set; }

    public TimeOnly? FinalHorario { get; set; }

    public virtual Voo IdVooNavigation { get; set; } = null!;
}
