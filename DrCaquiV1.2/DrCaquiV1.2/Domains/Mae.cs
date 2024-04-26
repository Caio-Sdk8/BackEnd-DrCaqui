using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class Mae
{
    public int IdMae { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdEndereco { get; set; }

    public string CpfMae { get; set; } = null!;

    public byte[] Gravidez { get; set; } = null!;

    public byte[] Zs1 { get; set; } = null!;

    public byte[] A53 { get; set; } = null!;

    public byte[] B18 { get; set; } = null!;

    public byte[] B58 { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Crianca> Criancas { get; set; } = new List<Crianca>();
    [JsonIgnore]
    public virtual Endereco? IdEnderecoNavigation { get; set; }
    [JsonIgnore]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Nutricao> Nutricaos { get; set; } = new List<Nutricao>();
}
