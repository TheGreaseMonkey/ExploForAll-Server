using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExploForAll.Server.Controllers
{
    public class PingController : ControllerBase
    {
        [Route("/Ping")]
        public async Task<string> Ping()
        {
            return "Pong";
        }
    }
}
