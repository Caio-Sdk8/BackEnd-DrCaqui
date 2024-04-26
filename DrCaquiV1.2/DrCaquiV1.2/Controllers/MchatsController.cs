using DrCaquiV1._2.Domains;
using DrCaquiV1._2.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrCaquiV1._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MchatsController : ControllerBase
    {
        private readonly IMchatRepository _MchatRepository;

        public MchatsController(IMchatRepository mchatRepository)
        {
            _MchatRepository = mchatRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_MchatRepository.ListarMchats());
        }
    }
}
