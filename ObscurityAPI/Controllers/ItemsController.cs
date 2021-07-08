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
    public class ItemsController : ControllerBase
    {
        private ObscurityContext _entities;

        public ItemsController() => _entities = new ObscurityContext();

        [HttpGet]
        public async Task<ActionResult<ItemViewModel>> Get(int storageId)
        {
            var items = await _entities.Items
                .Where(x => x.StorageId == storageId)
                .Select(x => new ItemViewModel()
                {
                    Id = x.Id,
                    StorageId = x.StorageId,
                    TypeId = x.TypeId,
                    Resource = x.Resource != null ? new ResourceViewModel() { Id = x.Resource.Id, Amount = x.Resource.Amount } : new ResourceViewModel()
                }).ToListAsync();

            return new ObjectResult(items.ToArray());
        }

        [HttpPost]
        public async Task<ActionResult> Post(ItemViewModel ItemViewModel)
        {
            _entities.Items.Add(new Item()
            {
                StorageId = ItemViewModel.StorageId,
                TypeId = ItemViewModel.TypeId,
                Resource = ItemViewModel.Resource.Id != -1 ? new Resource() { Amount = ItemViewModel.Resource.Amount } : null,
            });

            await _entities.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int itemId)
        {
            var a = _entities.Resources.Where(x => x.Id == itemId);

            if (a.ToList().Count != 0)
                _entities.Resources.Remove(_entities.Resources.First(x => x.Id == itemId));

            _entities.Items.Remove(_entities.Items.First(x => x.Id == itemId));


            await _entities.SaveChangesAsync();
            return Ok();
        }
    }
}
