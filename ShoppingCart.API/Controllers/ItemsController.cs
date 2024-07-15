using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.API.Data;
using ShoppingCart.API.Entities;
using ShoppingCart.API.Interfaces;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
		private readonly IItem itemRepository;

		public ItemsController( IItem itemRepository)
        {
			this.itemRepository = itemRepository;
		}

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await itemRepository.GetItems();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item?>> GetItem(int id)
        {
            var item = await itemRepository.GetItem(id);

            if(item is null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
			if (id != item.Id)
			{
				return BadRequest();
			}

            var updatedItem = await itemRepository.UpdateItem(item);

            return Ok(updatedItem);
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            await itemRepository.CreateItem(item);

            return Created();
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
                var item = await itemRepository.DeleteItem(id);
                if (item == null)
                {
                    return NotFound();
                }

                return NoContent();
        }
    }
}
