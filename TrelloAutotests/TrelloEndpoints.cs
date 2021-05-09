using Microsoft.Extensions.Logging;
using RA;

namespace TrelloAutotests
{
    public class TrelloEndpoints
    {
        private readonly ILogger _logger;
        
        public TrelloEndpoints(ILogger logger)
        {
            _logger = logger;
        }
        
        public ResponseContext CreateCard(string listId, string cardName)
        {
            var result = new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Post(Configs.BaseUri + Configs.CardsUrl +
                      $"?key={Configs.Key}&token={Configs.Token}&idList={listId}&name={cardName}")
                .Then();
            
            _logger.LogInformation(result.Retrieve(x => x).ToString());
            return result;
        }
    }
}