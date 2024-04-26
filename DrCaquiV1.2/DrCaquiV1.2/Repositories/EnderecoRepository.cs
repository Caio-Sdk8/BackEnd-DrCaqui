using DrCaquiV1._2.Domains;
using DrCaquiV1._2.Services;

namespace DrCaquiV1._2.Repositories
{
    public class EnderecoRepository
    {
        DrCaquiDbContext ctx = new DrCaquiDbContext();

        public void Alterar(int id, Endereco enderecoAtt)
        {
            Endereco attBanco = BuscarPorId(id);

            if (enderecoAtt.Rua != null)
            {
                attBanco.Rua = enderecoAtt.Rua;
            }
            if (enderecoAtt.Numero != 0)
            {
                attBanco.Numero = enderecoAtt.Numero;
            }
            if (enderecoAtt.Bairro != null)
            {
                attBanco.Bairro = enderecoAtt.Bairro;
            }
            if (enderecoAtt.Cidade != null)
            {
                attBanco.Cidade = enderecoAtt.Cidade;
            }

            ctx.Enderecos.Update(attBanco);
            ctx.SaveChanges();
        }

        public Endereco BuscarPorId(int id)
        {
            Endereco enderecoBusc = ctx.Enderecos.FirstOrDefault(u => u.IdEndereco == id);
            return enderecoBusc;
        }

        public Endereco Cadastrar(Endereco endereco)
        {
            ctx.Enderecos.Add(endereco);
            ctx.SaveChanges();
            Endereco enderecoBusc = ctx.Enderecos.FirstOrDefault(u => u.Numero == endereco.Numero && u.Rua == endereco.Rua);
            return enderecoBusc;
        }
    }
}
