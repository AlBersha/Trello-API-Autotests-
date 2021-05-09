using RA;
using Xunit;

namespace TrelloAutotests
{
    public class ListsTest
    {
        private const string Url = "https://api.trello.com/1/lists";
        private const string Key = "02e70548844b228e4049bf79e2be606d";
        private const string Token = "f00409614b9c486c8306d15135d1adbb5eac32ede45fe97f2380dfb7124f8274";

        
        [Fact]
        public void CreateNewLists_ShouldReturnNewList()
        {
            var boardId = "5dd85a7f8f92ff62c8a4fcd8"; // Daily tasks board
            var listName = "Exams preparation";
            new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Post(Url + $"?key={Key}&token={Token}&name={listName}&idBoard={boardId}")
                .Then()
                .TestStatus("status", x => x == 200);
        }
    }
}