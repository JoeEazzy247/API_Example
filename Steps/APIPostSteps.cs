using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_testing.Steps
{
    [Binding]
    public class PostSteps
    {
        RestClient client;
        RestRequest request;
        IRestResponse response;

        [Given(@"I have access to regres\.in site")]
        public void GivenIHaveAccessToRegres_InSite()
        {
            client = new RestClient("https://reqres.in/api/users");
            client.Timeout = -1;
        }

        [When(@"I enter new user details")]
        public void WhenIEnterNewUserDetails()
        {
            request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", "__cfduid=dc0778ef75f28d819b594e2d3c4c6b95c1592899691");
            request.AddParameter("text/plain", "", ParameterType.RequestBody);
            response = client.Execute(request);
            
        }
        
        [Then(@"I should see status ""(.*)""")]
        public void ThenIShouldSeeStatusOK(string p0)
        {
            Console.WriteLine(p0);
            Console.WriteLine(response.Content.Contains("id"));
            Console.WriteLine(response.StatusCode.ToString() == "Created");
            Console.WriteLine(response.Content.ToString());
        }
    }
}
