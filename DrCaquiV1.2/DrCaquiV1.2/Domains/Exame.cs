using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class Exame
{
    public int IdExame { get; set; }

    public int? IdCrianca { get; set; }

    public int? IdUsuario { get; set; }

    public string TituloExame { get; set; } = null!;

    public string DescricaoExame { get; set; } = null!;

    [JsonIgnore]
    public virtual Crianca? IdCriancaNavigation { get; set; }
    [JsonIgnore]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
