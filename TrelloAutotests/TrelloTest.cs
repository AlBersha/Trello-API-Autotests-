using Divergic.Logging.Xunit;
using Microsoft.Extensions.Logging;
using RA;
using Xunit;
using Xunit.Abstractions;

namespace TrelloAutotests
{
    public class TrelloTest
    {   
        // private readonly ITestOutputHelper _testOutputHelper;
        private readonly ILogger _logger;
        private TrelloEndpoints _trelloEndpoints;
        public TrelloTest(ITestOutputHelper testOutputHelper)
        {
            var factory = LogFactory.Create(testOutputHelper);
            // _testOutputHelper = testOutputHelper;
            _logger = factory.CreateLogger(nameof(TrelloEndpoints));
            _trelloEndpoints = new TrelloEndpoints(_logger);
        }


        [Fact]
        public void GetAllBoard_ShouldReturnListOfBoards()
        {
            _trelloEndpoints.GetAllBoards()
                .TestStatus("status", x => x == 200);
        }
        
        [Fact]
        public void GetNamesOfBoard_ShouldReturnListOfBoards()
        {
            const string field = "name";
           _trelloEndpoints.GetBoardsWithParticularFields(field)
                .TestStatus("status", x => x == 200);
        }
        
        [Fact]
        public void CreateList_ShouldReturnNewList()
        {
            var boardId = "5dd85a7f8f92ff62c8a4fcd8"; // Daily tasks board
            var listName = "Exams preparation";
            _trelloEndpoints.CreateList(boardId, listName)
                .TestStatus("status", x => x == 200);
        }
        
        [Fact]
        public void UpdateExistingList_ShouldReturnUpdatedList()
        {
            var listId = "60981703c97b4a7aa03edd9f";
            var listName = "Exams preparation 2021";
            _trelloEndpoints.UpdateExistingList(listId, listName)
                .TestStatus("status", x => x == 200);
        }

        [Fact]
        public void CreateCardInsideExistingList_ShouldReturnNewCard()
        {
            // var services = new ServiceCollection()
            //     .AddLogging((builder) => builder.AddXUnit(TestOutputHelper))
            //     .AddSingleton<TrelloEndpoints>();
            //
            // var trelloEndpoints = services
            //     .BuildServiceProvider()
            //     .GetRequiredService<TrelloEndpoints>();

            var trelloEndpoints = new TrelloEndpoints(_logger);
            
            var listId = "60981703c97b4a7aa03edd9f"; // Exams preparation list
            var cardName = "Pay attention to compiler labs";
            
            trelloEndpoints.CreateCard(listId, cardName)
                .TestStatus("status", x => x == 200);
            
        }

    }
}