using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class Pai
{
    public int IdPai { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdEndereco { get; set; }

    public string CpfPai { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Crianca> Criancas { get; set; } = new List<Crianca>();
    [JsonIgnore]
    public virtual Endereco? IdEnderecoNavigation { get; set; }
    [JsonIgnore]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
