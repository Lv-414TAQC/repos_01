using System;
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

    [TestFixture]
    public class RestTest1
    {
        [Test]
        public void TestMethod1()
        {
            string url = "http://localhost:8080";
            var client = new RestClient(url);
            JsonDeserializer deserial = new JsonDeserializer();
            //reset
            var request = new RestRequest("/reset", Method.GET);
            IRestResponse response = client.Execute(request);
            //
            //login as admin
            request = new RestRequest("/login", Method.POST);
            request.AddParameter("name", "admin");          
            request.AddParameter("password", "qwerty");
            response = client.Execute(request);
            var obj = deserial.Deserialize<RestResult>(response);
            string token = obj.content;
            Console.WriteLine("TOKEN =" + token);
            Assert.IsTrue(token.Length == 32);
            //
            //create new user
            request = new RestRequest("/user", Method.POST);
            request.AddParameter("token", token);
            request.AddParameter("name", "dima");
            request.AddParameter("password", "dima1");
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Console.WriteLine(obj);
            Assert.AreEqual("true", obj.content.ToLower());
            //
            // getAllUsers
            request = new RestRequest("/users", Method.GET);
            request.AddParameter("token", token);
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Console.WriteLine("ALL Users: " + obj.content);
            Assert.IsTrue(obj.content.Contains("dima"));
            //
            //log out admin
            request = new RestRequest("/logout", Method.POST);
            request.AddParameter("name", "admin");
            request.AddParameter("token", token);
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Console.WriteLine("Logout = " +obj );
            Assert.AreEqual("true", obj.content.ToLower());
            //
            //  Login as dima
            request = new RestRequest("/login", Method.POST);
            request.AddParameter("name", "dima");
            request.AddParameter("password", "dima1");
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            token = obj.content;
            Console.WriteLine("Login as dima = "+token);
            Assert.IsTrue(token.Length == 32);
            //
            //change password
            request = new RestRequest("/user", Method.PUT);
            request.AddParameter("token", token);
            request.AddParameter("oldpassword", "dima1");
            request.AddParameter("newpassword", "dima12");
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Console.WriteLine("Change password = " + obj.content);
            Assert.IsTrue(obj.content.ToLower().Contains("true"));
            //
            // logout dima
            request = new RestRequest("/logout", Method.POST);
            request.AddParameter("name", "dima");          
            request.AddParameter("token", token);
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Assert.AreEqual("true", obj.content.ToLower());
            //
            //Login with new password
            request = new RestRequest("/login", Method.POST);
            request.AddParameter("name", "dima");
            request.AddParameter("password", "dima12");
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            token = obj.content;
            Console.WriteLine("Token After changing password = " + token);
            Assert.IsTrue(token.Length == 32);
            //
            // logout dima
            request = new RestRequest("/logout", Method.POST);
            request.AddParameter("name", "dima");          
            request.AddParameter("token", token);
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Assert.AreEqual("true", obj.content.ToLower());
            //
            //  Login as admin
            request = new RestRequest("/login", Method.POST);
            request.AddParameter("name", "admin");          
            request.AddParameter("password", "qwerty");
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            token = obj.content;
            Assert.IsTrue(token.Length == 32);
            //
            //remove user
            request = new RestRequest("/user", Method.DELETE);
            request.AddParameter("token", token);
            request.AddParameter("name", "dima");
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Console.WriteLine(obj.content.ToLower());
            Assert.AreEqual("true", obj.content.ToLower());
            //
            // getAllUsers
            request = new RestRequest("/users", Method.GET);
            request.AddParameter("token", token);
            response = client.Execute(request);
            obj = deserial.Deserialize<RestResult>(response);
            Console.WriteLine("ALL Users2: " + obj.content);
            Assert.IsTrue(!obj.content.Contains("dima"));               
            //
            
        }
    }
}
