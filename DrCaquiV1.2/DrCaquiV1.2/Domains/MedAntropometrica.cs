using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class MedAntropometrica
{
    public int IdMed { get; set; }

    public int? IdCrianca { get; set; }

    public DateOnly DataMed { get; set; }

    public byte Idade { get; set; }

    public decimal Peso { get; set; }

    public decimal Estatura { get; set; }

    public decimal PerimetroCefalico { get; set; }

    public decimal Imc { get; set; }

    [JsonIgnore]
    public virtual Crianca? IdCriancaNavigation { get; set; }
}
