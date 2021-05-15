using System.Security.Permissions;
using RA;
using TechTalk.SpecFlow;
using TrelloAutotests;

namespace TrelloSpecFlowTests.Steps
{
    [Binding]
    public class TrelloStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly TrelloEndpoints _trelloEndpoints;
        private string ListName;
        private string BoardId;
        private ResponseContext _responseContext;

        public TrelloStepDefinitions(ScenarioContext context)
        {
            _scenarioContext = context;
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

    }
}