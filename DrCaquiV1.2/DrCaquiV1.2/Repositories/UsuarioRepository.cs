using DrCaquiV1._2.Domains;
using DrCaquiV1._2.Interfaces;
using BCrypt.Net;
using System.ComponentModel;
using System.Text;
using System.Security.Cryptography;
using DrCaquiV1._2.Services;

namespace DrCaquiV1._2.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        DrCaquiDbContext ctx = new DrCaquiDbContext();
        Criptografia crypt = new Criptografia();

        public void Alterar(int id, Usuario usuarioAtt)
        {
            Usuario attBanco = BuscarPorId(id);
            if(usuarioAtt.IdTipoUsuario != null)
            {
                attBanco.IdTipoUsuario = usuarioAtt.IdTipoUsuario;
            }
            if (usuarioAtt.NomeUsuario != null)
            {
                attBanco.NomeUsuario = crypt.Encrypt(usuarioAtt.NomeUsuario);
            }
            if (usuarioAtt.Login != null)
            {
                attBanco.Login = BCrypt.Net.BCrypt.HashPassword(usuarioAtt.Login);
            }
            if (usuarioAtt.Senha != null)
            {
                attBanco.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioAtt.Senha);
            }

            ctx.Usuarios.Update(attBanco);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            //Utilização de "HashPassword" mesmo em campos que não são senha pois o "HashString" é dito como obsoleto pelo c#
            usuario.Login = BCrypt.Net.BCrypt.HashPassword(usuario.Login);
            usuario.NomeUsuario = crypt.Encrypt(usuario.NomeUsuario);
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();

            return ctx.Usuarios.FirstOrDefault(u => u.Login == usuario.Login);
        }

        public Usuario Login(string login, string senha)
        {
            List<Usuario> lista = new List<Usuario>();
            lista = ctx.Usuarios.ToList();

            Usuario userLogin = new Usuario();
            foreach (var item in lista)
            {
                bool user = BCrypt.Net.BCrypt.Verify(login, item.Login);
                if (user)
                {
                    userLogin = item;
                }
            }

            if (userLogin != null) {
                bool senhaCrrt = BCrypt.Net.BCrypt.Verify(senha, userLogin.Senha);

                if (senhaCrrt)
                {
                    userLogin.NomeUsuario = crypt.Decrypt(userLogin.NomeUsuario);
                    return userLogin;
                }
                else{
                    throw new Exception("Senha Incorreta");
                }
            }
            else
            {
                throw new Exception("Usuario não encontrado");
            }
        }
    }
}
