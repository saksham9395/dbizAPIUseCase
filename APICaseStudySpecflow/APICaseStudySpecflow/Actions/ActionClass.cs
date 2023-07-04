using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace APICaseStudySpecflow.Actions
{
    public class ActionClass
    {
        IRestClient client;
        IRestRequest request;
        public void createGetRequest(string path)
        {
            client = new RestClient("https://reqres.in/");
            request = new RestRequest(path, Method.GET);
            request.AddParameter("page", 2);
            request.AddHeader("content-type", "application/json");
        }

        public IRestResponse getAPIResponse()
        {
            return client.Execute(request);
        }

        public void createGetRequestforSingleUser(string userID)
        {
            client = new RestClient("https://reqres.in/");
            request = new RestRequest("api/users/"+userID, Method.GET);
            request.AddHeader("content-type", "application/json");
        }

        public void createPostRequest(string path)
        {
            client = new RestClient("https://reqres.in/");
            request = new RestRequest(path, Method.POST);
            request.AddHeader("content-type", "application/json");
            var obj = new
            {
                name = "Test User",
                job = "admin"
            };

            var jsonStringNewtonsoft = JsonConvert.SerializeObject(obj);
            request.AddBody(jsonStringNewtonsoft);
        }

        public void createPutRequest(string path)
        {
            client = new RestClient("https://reqres.in/");
            request = new RestRequest(path, Method.PUT);
            request.AddHeader("content-type", "application/json");
            var obj = new
            {
                name = "Test User",
                job = "admin_updated"
            };

            var jsonStringNewtonsoft = JsonConvert.SerializeObject(obj);
            request.AddBody(jsonStringNewtonsoft);
        }

        public void createPatchRequest(string path)
        {
            client = new RestClient("https://reqres.in/");
            request = new RestRequest(path, Method.PATCH);
            request.AddHeader("content-type", "application/json");
            var obj = new
            {
                name = "Test User",
                job = "admin_updated_patch"
            };

            var jsonStringNewtonsoft = JsonConvert.SerializeObject(obj);
            request.AddBody(jsonStringNewtonsoft);
        }


    }
}
