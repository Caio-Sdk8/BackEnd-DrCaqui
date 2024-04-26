using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DrCaquiV1._2.Domains;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public byte? IdTipoUsuario { get; set; }

    public string NomeUsuario { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Exame> Exames { get; set; } = new List<Exame>();
    [JsonIgnore]
    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Mae> Maes { get; set; } = new List<Mae>();
    [JsonIgnore]
    public virtual ICollection<Pai> Pais { get; set; } = new List<Pai>();
}
