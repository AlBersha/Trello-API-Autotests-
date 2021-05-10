using RA;

namespace TrelloAutotests
{
    public class TrelloEndpoints
    {
        public ResponseContext GetAllBoards()
        {
            return new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Get(Configs.BaseUri + Configs.BoardsUrl + $"?key={Configs.Key}&token={Configs.Token}")
                .Then();
        }

        public ResponseContext GetBoardsWithParticularFields(string field)
        {
            return new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Get(Configs.BaseUri + Configs.BoardsUrl +
                     $"?fields={field},url&key={Configs.Key}&token={Configs.Token}")
                .Then();
        }
        
        public ResponseContext CreateList(string boardId, string listName)
        {
            return new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Post(Configs.BaseUri + Configs.ListsUrl +
                      $"?key={Configs.Key}&token={Configs.Token}&name={listName}&idBoard={boardId}")
                .Then();
        }

        public ResponseContext UpdateExistingList(string listId, string listName)
        {
            return new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Put(Configs.BaseUri + Configs.ListsUrl +
                     $"/{listId}?key={Configs.Key}&token={Configs.Token}&name={listName}")
                .Then();
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
            
            return result;
        }
    }
}