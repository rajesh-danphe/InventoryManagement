using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.DalLayer;
using InventoryManagement.ServerModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryMangement.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InventoryController : ControllerBase
  {
    private IGenericRepository<InventoryItemModel> _genericRepository;
    public InventoryController(IGenericRepository<InventoryItemModel> genericRepository)
    {
      _genericRepository = genericRepository;
    }

    // GET: api/Inventory/
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        IQueryable<InventoryItemModel> inventoryItems = await _genericRepository.GetAll();
        return Ok(inventoryItems.ToList());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }

    }

    // POST: api/Inventory
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InventoryItemModel inventoryItem)
    {
      try
      {
        inventoryItem.CreatedDate = DateTime.Now;
        await _genericRepository.Add(inventoryItem);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    // PUT: api/Inventory/
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] InventoryItemModel inventoryItem)
    {
      try
      {
        inventoryItem.LastUpdateDate = DateTime.Now;
        await _genericRepository.Update(inventoryItem);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{ItemId}")]
    public async Task<IActionResult> Delete(int ItemId)
    {
      try
      {
        InventoryItemModel updateItem = await _genericRepository.GetById(ItemId);
        await _genericRepository.Delete(updateItem);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
