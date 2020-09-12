using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Issue
    {
        private readonly string IssueEndpoint = ConfigurationManager.AppSettings["IssueEndpoint"];
        RestClient restClient;
        public Issue(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public string CreateIssue(string issueType)
        {
            var request = new RestRequest(IssueEndpoint);
            string body = "{\"fields\": {\"project\":{\"key\": \"DEMO\"},\"summary\": \"My Epic created from the API\",\"description\": \"Creating of an Epic using project keys and issue type names using the REST API\",\"issuetype\": {\"name\": \"" + issueType + "\"},\r\n\"customfield_10104\": \"MyEpic\"}}";
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            return restClient.Post(request).Content;
        }

    }
}
