using DrCaquiV1._2.Domains;

namespace DrCaquiV1._2.Interfaces
{
    public interface IPaiRepository
    {
        Pai Cadastrar(Pai pai);

        void Alterar(int id, Pai paiAtt);

        Pai BuscarPorId(int id);
    }
}
