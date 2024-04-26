using DrCaquiV1._2.Domains;
using DrCaquiV1._2.Services;

namespace DrCaquiV1._2.Repositories
{
    public class PaiRepository
    {
        DrCaquiDbContext ctx = new DrCaquiDbContext();
        Criptografia crypt = new Criptografia();

        public void Alterar(int id, Pai PaiAtt)
        {
            Pai attBanco = BuscarPorId(id);

            if (PaiAtt.CpfPai != null)
            {
                attBanco.CpfPai = crypt.Encrypt(PaiAtt.CpfPai);
            }
            if (PaiAtt.IdUsuario != null)
            {
                attBanco.IdUsuario = PaiAtt.IdUsuario;
            }
            if (PaiAtt.IdEndereco != null)
            {
                attBanco.IdEndereco = PaiAtt.IdEndereco;
            }

            ctx.Pais.Update(attBanco);
            ctx.SaveChanges();
        }

        public Pai BuscarPorId(int id)
        {
            Pai paiBusc = ctx.Pais.FirstOrDefault(u => u.IdPai == id);
            paiBusc.CpfPai = crypt.Decrypt(paiBusc.CpfPai);
            return paiBusc;
        }

        public Pai Cadastrar(Pai pai)
        {
            pai.CpfPai = crypt.Encrypt(pai.CpfPai);

            ctx.Pais.Add(pai);
            ctx.SaveChanges();

            return ctx.Pais.FirstOrDefault(u => u.CpfPai == pai.CpfPai);
        }
    }
}
