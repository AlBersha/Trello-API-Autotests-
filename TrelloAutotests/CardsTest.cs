using System;
using RA;
using Xunit;
using Xunit.Abstractions;

namespace TrelloAutotests
{
    public class CardsTest
    {
        private const string Url = "https://api.trello.com/1/cards";
        private const string Key = "02e70548844b228e4049bf79e2be606d";
        private const string Token = "f00409614b9c486c8306d15135d1adbb5eac32ede45fe97f2380dfb7124f8274";
        
        private readonly ITestOutputHelper _testOutputHelper;
        public CardsTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void CreateCardInsideExistingList_ShouldReturnNewCard()
        {
            var listId = "60981703c97b4a7aa03edd9f"; // Exams preparation board
            var cardName = "Pay attention to compiler labs";
            
            var response = new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Post(Url + $"?key={Key}&token={Token}&idList={listId}&name={cardName}")
                .Then()
                .TestStatus("status", x => x == 200);
            
            Console.WriteLine(response.Retrieve(x => x));
        }
    }
}