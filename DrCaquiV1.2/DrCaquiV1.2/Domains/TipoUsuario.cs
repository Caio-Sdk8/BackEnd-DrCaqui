using System;
using System.Collections.Generic;

namespace DrCaquiV1._2.Domains;

public partial class TipoUsuario
{
    public byte IdTipoUsuario { get; set; }

    public string NomeTipo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
