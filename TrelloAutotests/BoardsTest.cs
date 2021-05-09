using System;
using RA;
using Xunit;
// using Microsoft.Extensions.Configuration;

namespace TrelloAutotests
{
    public class BoardsTest
    {   

        [Fact]
        public void GetAllBoard_ShouldReturnListOfBoards()
        {
            new RestAssured()
                .Given()
                .Header("Content-Type", "application/json")
                .When()
                .Get(Configs.BaseUri + Configs.BoardsUrl + $"?key={Configs.Key}&token={Configs.Token}")
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
                .Get(Configs.BaseUri + Configs.BoardsUrl + $"?fields={field},url&key={Configs.Key}&token={Configs.Token}")
                .Then()
                .TestStatus("status", x => x == 200);
        }
    }
}