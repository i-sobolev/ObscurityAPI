using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObscurityAPI.Models;
using ObscurityAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObscurityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private ObscurityContext _entities;

        public PlayerController() => _entities = new ObscurityContext();

        [HttpPost]
        public async Task<ActionResult<PlayerViewModel>> Post(string name)
        {
            var newPlayer = await _entities.Players.AddAsync(new Player() { Name = name, World = _entities.Worlds.FirstOrDefault() });

            await _entities.SaveChangesAsync();

            return new ObjectResult(new PlayerViewModel() 
            {
                Id = newPlayer.Entity.Id, 
                Name = newPlayer.Entity.Name,
                WorldId = newPlayer.Entity.World.Id
            });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int playerId, string name)
        {
            _entities.Players.First(x => x.Id == playerId).Name = name;

            await _entities.SaveChangesAsync();

            return Ok();
        }
    }
}
