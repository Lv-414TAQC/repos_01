using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace Rest414Test
{
    public class RestResult
    {
        public string content { get; set; }

        public override string ToString()
        {
            return "Deserialized Content: " + content;
        }
    }

    //[TestClass]
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    public class RestTest1
    {
        //[TestMethod]
        [Test]
        public void TestMethod1()
        {
            // Common
            string url = "http://localhost:8080";
            var client = new RestClient(url);
            JsonDeserializer deserial = new JsonDeserializer();
            //
            // Login
            var request = new RestRequest("/login", Method.POST);
            request.AddParameter("name", "admin");          // Save parameters to body
            request.AddParameter("password", "qwerty");
            //
            IRestResponse response = client.Execute(request);
            //var content = response.Content;
            //Console.WriteLine("Login content: " + content);
            //
            // Deserialize
            var obj = deserial.Deserialize<RestResult>(response);
            //Console.WriteLine("\nDeserialize content, TOKEN: " + obj);
            string token = obj.content;
            //Assert is Logined
            //
            // Change Tokenlifetime
            request = new RestRequest("/tokenlifetime", Method.PUT);
            request.AddParameter("token", token);
            request.AddParameter("time", "700000");
            response = client.Execute(request);
            //string content = response.Content;
            //Console.WriteLine("Update Tokenlifetime content: " + content);
            //
            obj = deserial.Deserialize<RestResult>(response);
            Assert.AreEqual("true", obj.content.ToLower());
            //
            request = new RestRequest("/tokenlifetime", Method.GET);
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Assert.AreEqual("700000", obj.content.ToLower());
            //
            // addItem
            request = new RestRequest("/item/{index}", Method.POST);
            request.AddParameter("item", "hahaha");          // Save parameters to body
            request.AddParameter("token", token);
            request.AddUrlSegment("index", "1");
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Console.WriteLine("***addItem " + obj);
            //
            // getUserItem
            request = new RestRequest("/item/{index}/user/{name}?token=" + token, Method.GET);
            request.AddUrlSegment("index", "1");
            request.AddUrlSegment("name", "admin");
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Console.WriteLine("***getUserItem " + obj);
            //
            request = new RestRequest("/logout", Method.POST);
            request.AddParameter("name", "admin");          // Save parameters to body
            request.AddParameter("token", token);
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Assert.AreEqual("true", obj.content.ToLower());
        }
    }
}
