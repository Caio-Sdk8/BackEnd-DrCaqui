using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class Crianca
{
    public int IdCrianca { get; set; }

    public int? IdMae { get; set; }

    public int? IdPai { get; set; }

    public byte? IdRaca { get; set; }

    public string NomeCrianca { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public string CpfCrianca { get; set; } = null!;

    public string MunicipioNascimento { get; set; } = null!;

    public byte[] Sexo { get; set; } = null!;

    public byte[] Ortolani { get; set; } = null!;

    public byte[] ReflexoVermelho { get; set; } = null!;

    public byte[] Pezinho { get; set; } = null!;

    public byte[] TriagemAuditiva { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Exame> Exames { get; set; } = new List<Exame>();
    [JsonIgnore]
    public virtual Mae? IdMaeNavigation { get; set; }
    [JsonIgnore]
    public virtual Pai? IdPaiNavigation { get; set; }
    [JsonIgnore]
    public virtual Raca? IdRacaNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<MarcoCrianca> MarcoCriancas { get; set; } = new List<MarcoCrianca>();
    [JsonIgnore]
    public virtual ICollection<MedAntropometrica> MedAntropometricas { get; set; } = new List<MedAntropometrica>();
}
