// using Divergic.Logging.Xunit;
// using Xunit;
// using Xunit.Abstractions;
// using Microsoft.Extensions.Logging;
//
// namespace TrelloAutotests
// {
//     public class CardsTest
//     {
//         // private readonly ITestOutputHelper _testOutputHelper;
//         private readonly ILogger _logger;
//         public CardsTest(ITestOutputHelper testOutputHelper)
//         {
//             var factory = LogFactory.Create(testOutputHelper);
//             // _testOutputHelper = testOutputHelper;
//             _logger = factory.CreateLogger(nameof(TrelloEndpoints));
//         }
//
//         [Fact]
//         public void CreateCardInsideExistingList_ShouldReturnNewCard()
//         {
//             // var services = new ServiceCollection()
//             //     .AddLogging((builder) => builder.AddXUnit(TestOutputHelper))
//             //     .AddSingleton<TrelloEndpoints>();
//             //
//             // var trelloEndpoints = services
//             //     .BuildServiceProvider()
//             //     .GetRequiredService<TrelloEndpoints>();
//
//             var trelloEndpoints = new TrelloEndpoints(_logger);
//             
//             var listId = "60981703c97b4a7aa03edd9f"; // Exams preparation list
//             var cardName = "Pay attention to compiler labs";
//             
//            trelloEndpoints.CreateCard(listId, cardName)
//                 .TestStatus("status", x => x == 200);
//             
//         }
//     }
//     
// }