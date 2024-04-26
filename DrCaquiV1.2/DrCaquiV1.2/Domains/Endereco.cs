using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class Endereco
{
    public int IdEndereco { get; set; }

    public string Cidade { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public short Numero { get; set; }

    [JsonIgnore]
    public virtual ICollection<Mae> Maes { get; set; } = new List<Mae>();
    [JsonIgnore]
    public virtual ICollection<Pai> Pais { get; set; } = new List<Pai>();
}
