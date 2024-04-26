using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class Mchat
{
    public byte IdMchat { get; set; }

    public string Marco { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public byte IdadeLimit { get; set; }

    public virtual ICollection<MarcoCrianca> MarcoCriancas { get; set; } = new List<MarcoCrianca>();
}
