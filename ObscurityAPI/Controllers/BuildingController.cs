using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObscurityAPI.Models;
using ObscurityAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ObscurityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private ObscurityContext _entities;

        public BuildingController() => _entities = new ObscurityContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingViewModel>>> Get(int worldId)
        {
            var buildings = await _entities.Buildings
                .Where(x => x.WorldId == worldId)
                .Select(x => new BuildingViewModel()
                {
                    Id = x.Id,
                    XPosition = (float)x.Xposition,
                    YPosition = (float)x.Yposition,
                    ZPosition = (float)x.Zposition,
                    Rotation = (float)x.Rotation,
                    Owner = x.Owner,
                    TypeId = x.TypeId,
                    Storage = x.Storage != null ? new StorageViewModel() { IsLocked = x.Storage.IsLocked } : new StorageViewModel(),
                    Lightning = x.Lightning != null ? new LightningViewModel() { Fuel = x.Lightning.Fuel } : new LightningViewModel(),
                    WorldId = x.WorldId
                }).ToListAsync();

            return buildings.ToArray();
        }

        [HttpPost]
        public async Task<ActionResult> Post(BuildingViewModel buildingViewModel)
        {
            _entities.Buildings.Add(new Building()
            {
                Owner = buildingViewModel.Owner,
                Xposition = buildingViewModel.XPosition,
                Yposition = buildingViewModel.YPosition,
                Zposition = buildingViewModel.ZPosition,
                Rotation = buildingViewModel.Rotation,
                TypeId = buildingViewModel.TypeId,
                Lightning = buildingViewModel.Lightning.Id != -1 ? new Lightning() { Fuel = buildingViewModel.Lightning.Fuel } : null,
                Storage = buildingViewModel.Storage.Id != -1 ? new Storage() { IsLocked = buildingViewModel.Storage.IsLocked } : null,
                WorldId = buildingViewModel.WorldId
            });

            await _entities.SaveChangesAsync();
            return Ok();
        }
    }
}