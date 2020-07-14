using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using InventoryManagement;
using InventoryManagement.DalLayer;
using System.Linq;
using InventoryManagement.ServerModel;

namespace InventoryManagement.Test
{
    public class UnitTest1
    {
        private string connString = "Data Source=DESKTOP-LP8KTQK\\SQLEXPRESS;Initial Catalog=InventoryManagement;Integrated Security=True";

        [Fact(Skip = "Currently Not Required")]
        public void Test1()
        {
            Assert.Equal(4, this.Add(2, 2));
        }
        public int Add(int x, int y)
        {
            return x + y;
        }
        [Fact]
        public async void TestGet()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>().UseSqlServer(connString).Options;

            using (var context = new InventoryDbContext(options))
            {

                var test = new Inventory_Repository(context);
                var result = await test.GetAll();
                Assert.NotEmpty(result);
                Assert.NotNull(result);
            }

        }

        [Theory(Skip = "Currently Not Required",DisplayName = "Get Items by Id")]
        [InlineData(2)]
        public async void TestGetById(int ItemId)
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>().UseSqlServer(connString).Options;
            using (var context = new InventoryDbContext(options))
            {

                var test = new Inventory_Repository(context);
                var result = await test.GetById(ItemId);
                Assert.NotNull(result);
                Assert.Contains("sasd", result.ItemName);

            }

        }
        [Theory(Skip = "Currently Not Required",DisplayName = "Get All Items by Id")]
        [InlineData(2)]
        public async void TestGetAllById(int ItemId)
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>().UseSqlServer(connString).Options;
            using (var context = new InventoryDbContext(options))
            {

                var test = new Inventory_Repository(context);
                var result = await test.GetAllById(ItemId);
                Assert.NotNull(result);
                Assert.Equal(1, result.Count());

            }

        }
        //Skip = "Already Add is Tested",
        [Theory(Skip = "Currently Not Required", DisplayName = "Add new Item in Inventory")]
        [InlineData("Sharpner")]
        public async void TestAdd(string expectedName)
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>().UseSqlServer(connString).Options;
            InventoryItemModel inventoryItem = new InventoryItemModel();
            using (var context = new InventoryDbContext(options))
            {


                inventoryItem.ItemName = "Sharpener";
                inventoryItem.ItemPrice = 10;
                inventoryItem.ItemDescription = "Only 2 piece is remaining";
                inventoryItem.CreatedDate = DateTime.Now;
                var test = new Inventory_Repository(context);
                await test.Add(inventoryItem);


            }

            using (var context = new InventoryDbContext(options))
            {

                var test = new Inventory_Repository(context);
                var result = await test.GetById(inventoryItem.ItemId);
                Assert.NotNull(result);
                Assert.Contains(expectedName, result.ItemName);

            }

        }
        [Theory(Skip = "Already Update is Tested", DisplayName = "Update Item in Inventory")]
        [InlineData("Brush")]
        public async void TestUpdate(string expectedName)
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>().UseSqlServer(connString).Options;
            InventoryItemModel inventoryItem = new InventoryItemModel();
            using (var context = new InventoryDbContext(options))
            {

                inventoryItem.ItemId = 12;
                inventoryItem.ItemName = "Brush";
                inventoryItem.ItemPrice = 12;
                inventoryItem.ItemDescription = "Only 7 piece is remaining";
                inventoryItem.LastUpdateDate = DateTime.Now;
                var test = new Inventory_Repository(context);
                await test.Update(inventoryItem);
            }

            using (var context = new InventoryDbContext(options))
            {
                var test = new Inventory_Repository(context);
                var result = await test.GetById(inventoryItem.ItemId);
                Assert.NotNull(result);
                Assert.Contains(expectedName, result.ItemName);
            }

        }
        [Fact(Skip = "Currently Not Required")]
        public async void TestDelete()
        {
            var options = new DbContextOptionsBuilder<InventoryDbContext>().UseSqlServer(connString).Options;
            InventoryItemModel inventoryItem = new InventoryItemModel();
            using (var context = new InventoryDbContext(options))
            {
                inventoryItem.ItemId = 12;
                inventoryItem.ItemName = "Brush";
                inventoryItem.ItemPrice = 12;
                inventoryItem.ItemDescription = "Only 7 piece is remaining";
                inventoryItem.CreatedDate = DateTime.Now;
                var test = new Inventory_Repository(context);
                await test.Delete(inventoryItem);
            }

            using (var context = new InventoryDbContext(options))
            {

                var test = new Inventory_Repository(context);
                var result = await test.GetById(inventoryItem.ItemId);
                Assert.Null(result);
            }

        }



    }
}
