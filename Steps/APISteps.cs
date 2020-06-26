using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using TechTalk.SpecFlow.Assist;

namespace API_testing.Steps
{
    [Binding]
    public class APISteps
    {
        RestClient client;
        RestRequest request;
        IRestResponse response;
       
        [Given(@"I have access to regres\.in")]
        public void GivenIHaveAccessToRegres_In()
        {
            client = new RestClient("https://reqres.in/api/users?page=2");
            client.Timeout = -1;
        }
        
        [When(@"I request for all users")]
        public void WhenIRequestForAllUsers()
        {
            request = new RestRequest(Method.GET);
            response = client.Execute(request);            
        }
        
        [Then(@"I should see list of users")]
        public void ThenIShouldSeeListOfUsers()
        {
            Assert.That(response.StatusCode.ToString() == "OK");
            Assert.That(response.Content.Length > 0);
            Assert.That(response.IsSuccessful.ToString() == "True");
            Assert.That(response.Content.Contains("Michael"));
            Console.WriteLine(response.Content.ToString());
        }

        [Given(@"I have access to regres\.in ""(.*)""")]
        public void GivenIHaveAccessToRegres_In(string url2)
        {
            client = new RestClient(url2);
            client.Timeout = -1;
        }

        [When(@"I request for a users")]
        public void WhenIRequestForAUsers()
        {
            request = new RestRequest(Method.GET);
            //request = new RestRequest(Method.POST);
            //request.AddHeader("Authorisation", "Basic fgsdjhsdjsdidj");
            //request.AlwaysMultipartFormData = true;
            response = client.Execute(request);  
        }

        [Then(@"I should see the user")]
        public void ThenIShouldSeeTheUser()
        {
            Assert.That(response.StatusCode.ToString() == "OK");
            Assert.That(response.Content.Length > 0);
            Assert.That(response.Content.Contains("janet.weaver@reqres.in"));
            Console.WriteLine(response.Content);
        }
        [Then(@"the result should contain ""(.*)""")]
        public void ThenTheResultShouldContain(string name)
        {
            Assert.That(response.Content.Contains(name));
        }

        [Then(@"the result should contain (.*)")]
        public void ThenTheResultShouldContain(string name, Table table)
        {
            var user = table.CreateInstance<details>();
            string username = user.name;
            Assert.That(response.Content.Contains(username));
        }

    }

    internal class details
    {
        public string name { get; set; }
    }
}
