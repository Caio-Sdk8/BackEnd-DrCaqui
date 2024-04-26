using DrCaquiV1._2.Domains;
using DrCaquiV1._2.ViewModels;

namespace DrCaquiV1._2.Interfaces
{
    public interface ICriancaRepository
    {
        void Cadastrar(Crianca crianca, MaeViewModel mae, PaiViewModel pai);

        void Alterar(int id, Crianca criancaAtt);

        Crianca BuscarPorId(int id);

        Crianca BuscarPorCpf(string cpf);
    }
}
