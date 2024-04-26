using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class Raca
{
    public byte IdRaca { get; set; }

    public string Raca1 { get; set; } = null!;

    public virtual ICollection<Crianca> Criancas { get; set; } = new List<Crianca>();
}
