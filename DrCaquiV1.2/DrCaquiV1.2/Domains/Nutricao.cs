using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class Nutricao
{
    public int IdCrianca { get; set; }

    public int? IdMae { get; set; }

    public string Suplemento { get; set; } = null!;

    [JsonIgnore]
    public virtual Mae? IdMaeNavigation { get; set; }
}
