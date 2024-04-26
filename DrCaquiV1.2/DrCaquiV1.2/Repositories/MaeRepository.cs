using BCrypt.Net;
using DrCaquiV1._2.Domains;
using DrCaquiV1._2.Interfaces;
using DrCaquiV1._2.Services;

namespace DrCaquiV1._2.Repositories
{
    public class MaeRepository : IMaeRepository
    {
        DrCaquiDbContext ctx = new DrCaquiDbContext();
        Criptografia crypt = new Criptografia();

        public void Alterar(int id, Mae maeAtt)
        {
            Mae attBanco = BuscarPorId(id);

            if (maeAtt.CpfMae != null)
            {
                attBanco.CpfMae = crypt.Encrypt(maeAtt.CpfMae);
            }
            if (maeAtt.IdUsuario != null)
            {
                attBanco.IdUsuario = maeAtt.IdUsuario;
            }
            if (maeAtt.IdEndereco != null)
            {
                attBanco.IdEndereco = maeAtt.IdEndereco;
            }
            if (maeAtt.Gravidez != null)
            {
                attBanco.Gravidez = maeAtt.Gravidez;
            }
            if (maeAtt.Zs1 != null)
            {
                attBanco.Zs1 = maeAtt.Zs1;
            }
            if (maeAtt.A53 != null)
            {
                attBanco.A53 = maeAtt.A53;
            }
            if (maeAtt.B18 != null)
            {
                attBanco.B18 = maeAtt.B18;
            }
            if (maeAtt.B58 != null)
            {
                attBanco.B58 = maeAtt.B58;
            }

            ctx.Maes.Update(attBanco);
            ctx.SaveChanges();
        }

        public Mae BuscarPorId(int id)
        {
            Mae maeBusc = ctx.Maes.FirstOrDefault(u => u.IdMae == id);
            maeBusc.CpfMae = crypt.Decrypt(maeBusc.CpfMae);
            return maeBusc;
        }

        public Mae Cadastrar(Mae mae)
        {
            mae.CpfMae = crypt.Encrypt(mae.CpfMae);

            ctx.Maes.Add(mae);
            ctx.SaveChanges();

            return ctx.Maes.FirstOrDefault(u => u.CpfMae == mae.CpfMae);
        }
    }
}
