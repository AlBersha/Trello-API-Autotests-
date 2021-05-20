using Xunit;

namespace TrelloAutotests
{
    public class TrelloTest
    {   
        private readonly TrelloEndpoints _trelloEndpoints;
        public TrelloTest()
        {
            _trelloEndpoints = new TrelloEndpoints();
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
                .TestBody("name is null", x => x[0].name == null)
                .Assert("name is null");
                // .TestBody("name not null", x => x[0].name != null)
                // .Assert("name not null");
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
                .TestBody("name changed", x => x.id == listId && x.name == listName)
                .Assert("name changed");
        }

        [Fact]
        public void CreateCardInsideExistingList_ShouldReturnNewCard()
        {

            var listId = "60981703c97b4a7aa03edd9f"; // Exams preparation list
            var cardName = "Pay attention to compiler labs";

            _trelloEndpoints.CreateCard(listId, cardName)
                .TestBody("check name", x => x.name == cardName)
                .Assert("check name");

        }
    }
}