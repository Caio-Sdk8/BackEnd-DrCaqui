using DrCaquiV1._2.Domains;

namespace DrCaquiV1._2.Interfaces
{
    public interface IEnderecoRepository
    {
        Endereco Cadastrar(Endereco endereco);

        void Alterar(int id, Endereco enderecoAtt);

        Endereco BuscarPorId(int id);
    }
}
