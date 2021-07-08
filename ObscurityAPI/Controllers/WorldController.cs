using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class WorldController : ControllerBase
    {
        private ObscurityContext _entities;

        public WorldController() => _entities = new ObscurityContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldViewModel>>> Get()
        {
            var result = await _entities.Worlds.Select(x => new WorldViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                PlayerNames = x.Players.Select(x => x.Name).ToArray()
            }).ToListAsync();

            return result.ToArray();
        }

        [HttpPost]
        public async Task<ActionResult> Post(string name)
        {
            await _entities.Worlds.AddAsync(new World() { Name = name });
            
            await _entities.SaveChangesAsync();
            return Ok();
        }
    }
}
