using RA;
using Xunit;

namespace TrelloAutotests
{
    public class BoardsTest
    {
        private const string Url = "https://api.trello.com/1/members/me/boards";
        private const string Key = "02e70548844b228e4049bf79e2be606d";
        private const string Token = "f00409614b9c486c8306d15135d1adbb5eac32ede45fe97f2380dfb7124f8274";

        [Fact]
        public void GetAllBoard_ShouldReturnListOfBoards()
        {
            new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Get(Url + $"?key={Key}&token={Token}")
                .Then()
                .TestStatus("status", x => x == 200);
        }
        
        [Fact]
        public void GetNamesOfBoard_ShouldReturnListOfBoards()
        {
            const string field = "name";
            new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Get(Url + $"?fields={field},url&key={Key}&token={Token}")
                .Then()
                .TestStatus("status", x => x == 200);
        }
        
    }
}