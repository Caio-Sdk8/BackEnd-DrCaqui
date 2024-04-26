using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class MarcoCrianca
{
    public int IdMarcoCrianca { get; set; }

    public int? IdCrianca { get; set; }

    public byte? IdMchat { get; set; }

    public short IdadeCrianca { get; set; }

    [JsonIgnore]
    public virtual Crianca? IdCriancaNavigation { get; set; }
    [JsonIgnore]
    public virtual Mchat? IdMchatNavigation { get; set; }
}
