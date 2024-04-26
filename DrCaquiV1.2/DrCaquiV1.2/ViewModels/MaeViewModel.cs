namespace DrCaquiV1._2.ViewModels
{
    public class MaeViewModel
    {
        public string NomeUsuario { get; set; } = null!;

        public string CpfMae { get; set; } = null!;

        public byte[] Gravidez { get; set; } = null!;

        public byte[] Zs1 { get; set; } = null!;

        public byte[] A53 { get; set; } = null!;

        public byte[] B18 { get; set; } = null!;

        public byte[] B58 { get; set; } = null!;

        public string Cidade { get; set; } = null!;

        public string Bairro { get; set; } = null!;

        public string Rua { get; set; } = null!;

        public short Numero { get; set; }
    }
}
