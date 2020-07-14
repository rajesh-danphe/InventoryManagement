using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using InventoryManagement.DalLayer;

namespace InventoryManagement.Test
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      Assert.Equal(4, this.Add(2, 2));
    }
    public int Add(int x, int y)
    {
      return x + y;
    }
    //[Theory(DisplayName ="Get Items List")]
    //[InlineData("Test")]
    public async void TestGet()
    {
      var options = new DbContextOptionsBuilder<InventoryDbContext>()
                       .UseInMemoryDatabase(databaseName: "TestInventoryDB").Options;

      using(var context = new InventoryDbContext(options))
      {
        //var r1 = new InventoryList
        //{
        //  Name = "Rajesh"
        //};
      }

    }

 
  }
}
