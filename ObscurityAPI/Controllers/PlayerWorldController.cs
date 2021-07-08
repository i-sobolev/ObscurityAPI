using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObscurityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerWorldController : ControllerBase
    {
        private ObscurityContext _entities;

        public PlayerWorldController() => _entities = new ObscurityContext();
        
        [HttpPut]
        public async Task<ActionResult> Put(int playerId, int worldId)
        {
            _entities.Players.Where(x => x.Id == playerId)
                .FirstOrDefaultAsync()
                .Result.WorldId = worldId;
            
            await _entities.SaveChangesAsync();
            return new ObjectResult(worldId);
        }
    }
}
