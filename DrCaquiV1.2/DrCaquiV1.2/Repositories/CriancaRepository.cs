using BCrypt.Net;
using DrCaquiV1._2.Domains;
using DrCaquiV1._2.Interfaces;
using DrCaquiV1._2.Services;
using DrCaquiV1._2.ViewModels;

namespace DrCaquiV1._2.Repositories
{
    public class CriancaRepository : ICriancaRepository
    {
        UsuarioRepository urepo = new UsuarioRepository();
        EnderecoRepository erepo = new EnderecoRepository();
        PaiRepository pairepo = new PaiRepository();
        MaeRepository maerepo = new MaeRepository();
        DrCaquiDbContext ctx = new DrCaquiDbContext();
        Criptografia crypt = new Criptografia();

        public void Alterar(int id, Crianca criancaAtt)
        {
            Crianca attBanco = BuscarPorId(id);

            if (criancaAtt.CpfCrianca != null)
            {
                attBanco.CpfCrianca = crypt.Encrypt(criancaAtt.CpfCrianca);
            }
            if (criancaAtt.NomeCrianca != null)
            {
                attBanco.NomeCrianca = crypt.Encrypt(criancaAtt.NomeCrianca);
            }
            if (criancaAtt.IdRaca != null)
            {
                attBanco.IdRaca = criancaAtt.IdRaca;
            }
            if (criancaAtt.IdMae != null)
            {
                attBanco.IdMae = criancaAtt.IdMae;
            }
            if (criancaAtt.IdPai != null)
            {
                attBanco.IdPai = criancaAtt.IdPai;
            }
            if (criancaAtt.DataNascimento != null)
            {
                attBanco.DataNascimento = criancaAtt.DataNascimento;
            }
            if (criancaAtt.MunicipioNascimento != null)
            {
                attBanco.MunicipioNascimento = criancaAtt.MunicipioNascimento;
            }
            if (criancaAtt.Ortolani != null)
            {
                attBanco.Ortolani = criancaAtt.Ortolani;
            }
            if (criancaAtt.Pezinho != null)
            {
                attBanco.Pezinho = criancaAtt.Pezinho;
            }
            if (criancaAtt.ReflexoVermelho != null)
            {
                attBanco.ReflexoVermelho = criancaAtt.ReflexoVermelho;
            }
            if (criancaAtt.Sexo != null)
            {
                attBanco.Sexo = criancaAtt.Sexo;
            }
            if (criancaAtt.TriagemAuditiva != null)
            {
                attBanco.TriagemAuditiva = criancaAtt.TriagemAuditiva;
            }

            ctx.Criancas.Update(attBanco);
            ctx.SaveChanges();
        }

        public Crianca BuscarPorCpf(string cpf)
        {
            Crianca criancaBusc = ctx.Criancas.FirstOrDefault(u => crypt.Decrypt(u.CpfCrianca) == cpf);
            criancaBusc.CpfCrianca = crypt.Decrypt(criancaBusc.CpfCrianca);
            criancaBusc.NomeCrianca = crypt.Decrypt(criancaBusc.NomeCrianca);
            return criancaBusc;
        }

        public Crianca BuscarPorId(int id)
        {
            Crianca criancaBusc = ctx.Criancas.FirstOrDefault(u => u.IdCrianca == id);
            criancaBusc.CpfCrianca = crypt.Decrypt(criancaBusc.CpfCrianca);
            criancaBusc.NomeCrianca = crypt.Decrypt(criancaBusc.NomeCrianca);
            return criancaBusc;
        }

        public void Cadastrar(Crianca crianca, MaeViewModel maeJson, PaiViewModel paiJson)
        {
            Usuario maeUser = new Usuario();
            Usuario paiUser = new Usuario();
            Mae mae = new Mae();
            Pai pai = new Pai();
            Endereco endResp = new Endereco();

            maeUser.IdTipoUsuario = 2;
            maeUser.Login = maeJson.CpfMae;
            maeUser.NomeUsuario = maeJson.NomeUsuario;
            maeUser.Senha = crianca.DataNascimento.ToString() + "@" + crianca.NomeCrianca;

            mae.IdUsuario = urepo.Cadastrar(maeUser).IdUsuario;

            paiUser.IdTipoUsuario = 2;
            paiUser.Login = paiJson.CpfPai;
            paiUser.NomeUsuario = paiJson.NomeUsuario;
            paiUser.Senha = crianca.DataNascimento.ToString() + "@" + crianca.NomeCrianca;

            pai.IdUsuario = urepo.Cadastrar(paiUser).IdUsuario;

            if (paiJson.Cidade == maeJson.Cidade && paiJson.Rua == maeJson.Rua && paiJson.Bairro == maeJson.Bairro && paiJson.Numero == maeJson.Numero)
            {
                endResp.Numero = maeJson.Numero;
                endResp.Rua = maeJson.Rua;
                endResp.Bairro = maeJson.Bairro;
                endResp.Cidade = maeJson.Cidade;

                mae.IdEndereco =erepo.Cadastrar(endResp).IdEndereco;
                pai.IdEndereco = erepo.Cadastrar(endResp).IdEndereco;
            }
            else
            {
                endResp.Numero = maeJson.Numero;
                endResp.Rua = maeJson.Rua;
                endResp.Bairro = maeJson.Bairro;
                endResp.Cidade = maeJson.Cidade;

                mae.IdEndereco = erepo.Cadastrar(endResp).IdEndereco;

                endResp.Numero = paiJson.Numero;
                endResp.Rua = paiJson.Rua;
                endResp.Bairro = paiJson.Bairro;
                endResp.Cidade = paiJson.Cidade;

                pai.IdEndereco = erepo.Cadastrar(endResp).IdEndereco;
            }

            pai.CpfPai = paiJson.CpfPai;

            mae.CpfMae= maeJson.CpfMae;
            mae.Gravidez = maeJson.Gravidez;
            mae.A53 = maeJson.A53;
            mae.Zs1 = maeJson.Zs1;
            mae.B18 = maeJson.B18;
            mae.B58 = maeJson.B58;

            crianca.IdPai = pairepo.Cadastrar(pai).IdPai;
            crianca.IdMae = maerepo.Cadastrar(mae).IdMae;
            crianca.CpfCrianca = crypt.Encrypt(crianca.CpfCrianca);
            crianca.NomeCrianca = crypt.Encrypt(crianca.NomeCrianca);

            ctx.Criancas.Add(crianca);
            ctx.SaveChanges();
        }
    }
}
