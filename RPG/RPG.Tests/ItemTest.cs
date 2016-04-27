using RPG.Models;
using Xunit;

namespace ToDoList.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetNameTest()
        {
            //Arrange
            var item = new Item();
            item.ItemName = "Sword";
            //Act
            var result = item.ItemName;

            //Assert
            Assert.Equal("Sword", result);
        }
    }
}