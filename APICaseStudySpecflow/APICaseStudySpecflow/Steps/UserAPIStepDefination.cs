using APICaseStudySpecflow.Actions;
using APICaseStudySpecflow.Modals;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace APICaseStudySpecflow.Steps
{
    [Binding]
     public class UserAPIStepDefination
      {
        private readonly ScenarioContext _scenarioContext;
        public UserAPIStepDefination(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }
        ActionClass ac = new ActionClass();

        [Given(@"user creates a Get Request for list of all user API (.*)")]
        public void GivenUserCreatesAGetRequestForListOfAllUserAPI(string path)
        {
            ac.createGetRequest(path);
        }

        [When(@"user hit the API")]
        public void WhenUserHitTheAPI()
        {
            var response = ac.getAPIResponse();
            _scenarioContext.Add("StatusCode", response.StatusCode);
            _scenarioContext.Add("Content", response.Content);
        }

        [Then(@"The API should return 200 OK")]
        public void ThenTheAPIShouldReturnOK()
        {
          Assert.IsTrue(_scenarioContext.Get<HttpStatusCode>("StatusCode") == HttpStatusCode.OK,"The reaponse for current user list rquest failed with status code  ->" + _scenarioContext.Get<HttpStatusCode>("StatusCode"));
        }

        [Then(@"verify ""(.*)"" is a valid user")]
        public void ThenVerifyIsAValidUser(string username)
        {
            var responseofAPi = _scenarioContext.Get<string>("Content");
            var userData = JsonConvert.DeserializeObject<Root>(responseofAPi).data.ToList();
            var names = userData.Select(e => e.first_name + " " + e.last_name);
            Assert.IsTrue(names.Contains(username), username + " not found in the user names list response");
        }

        [Given(@"user creates a Get Request for single API for user (.*)")]
        public void GivenUserCreatesAGetRequestForSingleAPIForUser(string userID)
        {
            ac.createGetRequestforSingleUser(userID);
        }

        [Given(@"user creates a Post Request for new user API (.*)")]
        public void GivenUserCreatesAPostRequestForNewUser(string path)
        {
            ac.createPostRequest(path);
        }
        [Then(@"The post API should return 201 OK")]
        public void ThenThePostAPIShouldReturnOK()
        {
            Assert.IsTrue(_scenarioContext.Get<HttpStatusCode>("StatusCode") == HttpStatusCode.Created, "The reaponse for post api falied with status code  ->" + _scenarioContext.Get<HttpStatusCode>("StatusCode"));
        }

        [Given(@"user creates a Put Request for updating existing user API (.*)")]
        public void GivenUserCreatesAPutRequestForUpdatingExistingUser(string path)
        {
            ac.createPutRequest(path);
        }
        [Given(@"user creates a Patch Request for updating existing user API (.*)")]
        public void GivenUserCreatesAPatchRequestForUpdatingExistingUser(string path)
        {
            ac.createPatchRequest(path);
        }

    }
}
