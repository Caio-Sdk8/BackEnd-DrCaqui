using DrCaquiV1._2.Domains;

namespace DrCaquiV1._2.Interfaces
{
    public interface IMaeRepository
    {
        Mae Cadastrar(Mae Mae);

        void Alterar(int id, Mae MaeAtt);

        Mae BuscarPorId(int id);
    }
}
