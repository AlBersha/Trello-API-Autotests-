using RA;
using TechTalk.SpecFlow;
using TrelloAutotests;

namespace TrelloSpecFlowTests.Steps
{
    [Binding]
    public class TrelloUpdateStepDefinitions
    {
        private readonly TrelloEndpoints _trelloEndpoints;
        private string ListName;
        private string BoardId;
        private string ListId;
        private string CardName;
        private ResponseContext _responseContext;

        public TrelloUpdateStepDefinitions()
        {
            _trelloEndpoints = new TrelloEndpoints();
        }


        [Given(@"the name of list is ""(.*)""")]
        public void GivenTheNameOfBoardIs(string listName)
        {
            ListName = listName;
        }

        [Given(@"the board id is ""(.*)""")]
        public void GivenTheBoardIdIs(string boardId)
        {
            BoardId = boardId;
        }

        [When(@"the function are executed")]
        public void WhenTheFunctionAreExecuted()
        {
            _responseContext = _trelloEndpoints.CreateList(BoardId, ListName);
        }

        [Then(@"the board is created")]
        public void ThenTheBoardIsCreated()
        {
            _responseContext
                .TestStatus("status", x => x == 200)
                .Assert("status");
        }

        [Given(@"the list id is ""(.*)""")]
        public void GivenTheListIdIs(string listId)
        {
            ListId = listId;
        }
        
        
        [Given(@"the desired list name is ""(.*)""")]
        public void GivenTheDesiredListNameIs(string listName)
        {
            ListName = listName;
        }

        [When(@"the function to update are executed")]
        public void WhenTheFunctionToUpdateAreExecuted()
        {
            _responseContext = _trelloEndpoints.UpdateExistingList(ListId, ListName);
        }

        [Then(@"the new list name is right")]
        public void ThenTheNewNameIsRight()
        {
            _responseContext
                .TestBody("name changed", x => x.id == ListId && x.name == ListName)
                .Assert("name changed");
        }

        [Given(@"the desired card name is ""(.*)""")]
        public void GivenTheDesiredCardNameIs(string cardName)
        {
            CardName = cardName;
        }
        
        [When(@"the function to create card are executed")]
        public void WhenTheFunctionToCreateCardAreExecuted()
        {
            _responseContext = _trelloEndpoints.CreateCard(ListId, CardName);
        }

        [Then(@"the new card name is right")]
        public void ThenTheNewCardNameIsRight()
        {
            _responseContext
                .TestBody("check name", x => x.name == CardName)
                .Assert("check name");
        }
    }
}