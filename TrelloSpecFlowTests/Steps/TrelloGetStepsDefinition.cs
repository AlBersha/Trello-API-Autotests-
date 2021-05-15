using RA;
using TechTalk.SpecFlow;
using TrelloAutotests;

namespace TrelloSpecFlowTests.Steps
{
    [Binding]
    public class TrelloGetStepsDefinition
    {
        private ResponseContext _responseContext;
        private readonly TrelloEndpoints _trelloEndpoints;
        private string Name;

        public TrelloGetStepsDefinition()
        {
            _trelloEndpoints = new TrelloEndpoints();
        }
        
        [Given(@"the required field is ""(.*)""")]
        public void GivenTheRequiredFieldIs(string name)
        {
            Name = name;
        }

        [When(@"the function to get are executed")]
        public void WhenTheFunctionToGetAreExecuted()
        {
            _responseContext = _trelloEndpoints.GetBoardsWithParticularFields(Name);
        }

        [Then(@"the first name in the list is not null")]
        public void ThenTheFirstNameInTheListIsNotNull()
        {
            _responseContext
                .TestBody("name is not null", x => x[0].name != null)
                .Assert("name is not null");
        }

        [Then(@"the first name in the list is null")]
        public void ThenTheFirstNameInTheListIsNull()
        {
            _responseContext
                .TestBody("name is null", x => x[0].name == null)
                .Assert("name is null");
        }
    }
}