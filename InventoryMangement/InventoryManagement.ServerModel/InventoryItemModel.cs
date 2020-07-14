using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.ServerModel
{
  public class InventoryItemModel
  {
    [Key]
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public decimal ItemPrice { get; set; }
    public string ItemIMG { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastUpdateDate { get; set; }
  }
}
