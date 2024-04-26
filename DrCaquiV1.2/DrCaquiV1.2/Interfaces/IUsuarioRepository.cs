using DrCaquiV1._2.Domains;

namespace DrCaquiV1._2.Interfaces
{
    public interface IUsuarioRepository
    {

        Usuario Login(string login, string senha);

        Usuario Cadastrar(Usuario usuario);

        void Alterar(int id, Usuario usuarioAtt);

        Usuario BuscarPorId(int id);

    }
}
