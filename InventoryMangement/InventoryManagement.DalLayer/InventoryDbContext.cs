using InventoryManagement.ServerModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryManagement.DalLayer
{
    public class InventoryDbContext:DbContext
    {

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
        
    }
    public DbSet<InventoryItemModel> inventoryItemModels { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<InventoryItemModel>().ToTable("tbl_InventoryItems");
     
    }
  }
}
