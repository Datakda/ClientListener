using ClientListener.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientListener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        IHubContext<ChatHub> hubContext;
        public UpdateController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpPost]
        public async Task UpdateAsync(RandomDouble json) 
        {

          
            var rnd = json.result.ToString();

            await hubContext.Clients.All.SendAsync("Send",rnd);




        }

    }
}
