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
    private InventoryDbContext inventoryDbContext;
    public InventoryController(InventoryDbContext inventoryDbContext_)
    {
      inventoryDbContext = inventoryDbContext_;
    }

    // GET: api/Inventory/
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        IQueryable<InventoryItemModel> inventoryItems = await Task.Run(() => inventoryDbContext.inventoryItemModels.AsQueryable());
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
        await inventoryDbContext.AddAsync(inventoryItem);
        await inventoryDbContext.SaveChangesAsync();

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
        InventoryItemModel updateItem = inventoryDbContext.inventoryItemModels.Where(a => a.ItemId == inventoryItem.ItemId).FirstOrDefault();
        updateItem.ItemDescription = inventoryItem.ItemDescription;
        updateItem.ItemIMG = inventoryItem.ItemIMG;
        updateItem.ItemName = inventoryItem.ItemName;
        updateItem.ItemPrice = inventoryItem.ItemPrice;
        updateItem.LastUpdateDate = inventoryItem.LastUpdateDate;
        inventoryDbContext.Update(updateItem);
        inventoryDbContext.Entry(updateItem).State = EntityState.Modified;
        await inventoryDbContext.SaveChangesAsync();

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
        InventoryItemModel updateItem = inventoryDbContext.inventoryItemModels.Where(a => a.ItemId == ItemId).FirstOrDefault();
        inventoryDbContext.Remove(updateItem);
        await inventoryDbContext.SaveChangesAsync();

        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
