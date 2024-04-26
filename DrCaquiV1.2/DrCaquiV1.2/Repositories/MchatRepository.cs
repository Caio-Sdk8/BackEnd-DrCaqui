using DrCaquiV1._2.Domains;
using DrCaquiV1._2.Interfaces;

namespace DrCaquiV1._2.Repositories
{
    public class MchatRepository : IMchatRepository
    {
        DrCaquiDbContext ctx = new DrCaquiDbContext();
        public List<Mchat> ListarMchats()
        {
            return ctx.Mchats.ToList();
        }
    }
}
