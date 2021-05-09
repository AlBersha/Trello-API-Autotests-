using RA;
using Xunit;

namespace TrelloAutotests
{
    public class ListsTest
    {

        [Fact]
        public void CreateLists_ShouldReturnNewList()
        {
            var boardId = "5dd85a7f8f92ff62c8a4fcd8"; // Daily tasks board
            var listName = "Exams preparation";
            new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Post(Configs.BaseUri + Configs.ListsUrl + $"?key={Configs.Key}&token={Configs.Token}&name={listName}&idBoard={boardId}")
                .Then()
                .TestStatus("status", x => x == 200);
        }
        
        [Fact]
        public void UpdateExistingLists_ShouldReturnUpdatedList()
        {
            var listId = "60981703c97b4a7aa03edd9f";
            var listName = "Exams preparation 2021";
            new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Put(Configs.BaseUri + Configs.ListsUrl + $"/{listId}?key={Configs.Key}&token={Configs.Token}&name={listName}")
                .Then()
                .TestStatus("status", x => x == 200);
        }
        
    }
}