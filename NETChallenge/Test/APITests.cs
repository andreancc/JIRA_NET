using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;
using ClassLibrary1;
using System;

namespace JiraAutomation
{
    [TestFixture]
    public class APITests
    {
       
        private readonly string BaseUrl = "http://localhost:8080";
        private readonly string ConfigUsername = "andreancc";
        private readonly string ConfigPassword = "andreancc";




        RestClient restClient;

        [SetUp]
        public void setUp()
        {
            restClient = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(ConfigUsername, ConfigPassword),
            };
        }

        [Test]
        public void ANewEpicIsCreatedUsingTheAPI()
        {
            var issue = new Issue(restClient);
            Console.WriteLine(issue.CreateIssue("Epic"));
        }
    }
}
