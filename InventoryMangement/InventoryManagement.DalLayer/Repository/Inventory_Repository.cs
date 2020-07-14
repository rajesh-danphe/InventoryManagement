using InventoryManagement.ServerModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.DalLayer
{
  public class Inventory_Repository : IGenericRepository<InventoryItemModel>
  {
    public readonly InventoryDbContext _context;
    public Inventory_Repository(InventoryDbContext context)
    {
      _context = context;
    }
    public async Task<InventoryItemModel> Add(InventoryItemModel obj)
    {
      _context.Add(obj);
      await _context.SaveChangesAsync();
      return obj;
    }

    public async Task<InventoryItemModel> Delete(InventoryItemModel obj)
    {
      _context.Remove(obj);
      await _context.SaveChangesAsync();
      return obj;

    }

    public async Task<IQueryable<InventoryItemModel>> GetAll()
    {
      return await Task.Run(() => _context.inventoryItemModels.AsQueryable());
    }

    public async Task<IQueryable<InventoryItemModel>> GetAllById(object id)
    {
      return await Task.Run(() => _context.inventoryItemModels.Where(a => a.ItemId == (int)id).AsQueryable());
    }

    public async Task<InventoryItemModel> GetById(object id)
    {
      int ItemId = (int)id;
      return await _context.inventoryItemModels.FindAsync(ItemId);
    }

    public async Task<InventoryItemModel> Update(InventoryItemModel obj)
    {
      _context.Entry(obj).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return obj;
    }
  }
}
