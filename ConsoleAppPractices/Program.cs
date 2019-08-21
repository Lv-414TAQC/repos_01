using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPractices
{
    public class A11
    {
        public void m1()
        {
            Console.WriteLine("Class Name: " + this.GetType().ToString());
        }
    }

    public class B22 : A11
    {
        public void m2()
        {
            m1();
        }
    }

    // For RestSharp
    public class RestResult
    {
        public string content { get; set; }

        public override string ToString()
        {
            return "Deserialized Content: " + content;
        }
    }

    // For Newtonsoft.Json
    public class RestResult2
    {
        [JsonProperty("content")]
        public string Answer { get; set; }

        public override string ToString()
        {
            return "class RestResult2.ToString(): " + Answer;
        }
    }

    public class RestResultOrgsDotnetReposArray
    {
        public string html_url { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return "class RestResultOrgsDotnetReposArray.ToString():"
                + "\nhtml_url: " + html_url
                + "\ndescription: " + description;
        }
    }

    public class RestResultOrgsDotnetReposArray2
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        public string MyInfo { get; set; } = "Running";

        public override string ToString()
        {
            return "class RestResultOrgsDotnetReposArray.ToString():"
                + "\nlogin: " + Description
                + "\nemail: " + HtmlUrl
                + "\nMyInfo: " + MyInfo;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Use Constructor
            //User user = new User("firstname01",  "lastname01",
            //     "email01",  "telephone01",  "address101",
            //     "city01",  "postcode01",  "country01",
            //     "region01",  "password01", true);
            //Console.WriteLine("email = " + user.Email);
            //
            // 2. Default Constructor and Setters
            //User user = new User();
            //user.SetFirstname("firstname02");
            //user.SetLastname("lastname02");
            //user.SetEmail("email02");
            //user.SetTelephone("telephone02");
            //user.SetAddress1("address102");
            //user.SetCity("city02");
            //user.SetPostcode("postcode02");
            //user.SetCountry("country02");
            //user.SetRegionState("region02");
            //user.SetPassword("password02");
            //user.SetSubscribe(true);
            //user.SetFax("fax02");
            //user.SetCompany("company02");
            //user.SetAddress2("address202");
            //Console.WriteLine("email = " + user.Email);
            //
            // 3. Add Fluent Interface
            //User user = new User()
            //    .SetFirstname("firstname03")
            //    .SetLastname("lastname03")
            //    .SetEmail("email03")
            //    .SetTelephone("telephone03")
            //    .SetAddress1("address103")
            //    .SetCity("city03")
            //    .SetPostcode("postcode03")
            //    .SetCountry("country03")
            //    .SetRegionState("region03")
            //    .SetPassword("password03")
            //    .SetSubscribe(true)
            //    .SetFax("fax03")
            //    .SetCompany("company03")
            //    .SetAddress2("address203");
            //Console.WriteLine("email = " + user.Email);
            //
            // 4. Add Static Factory
            //User user = User.Get()
            //    .SetFirstname("firstname04")
            //    .SetLastname("lastname04")
            //    .SetEmail("email04")
            //    .SetTelephone("telephone04")
            //    .SetAddress1("address104")
            //    .SetCity("city04")
            //    .SetPostcode("postcode04")
            //    .SetCountry("country04")
            //    .SetRegionState("region04")
            //    .SetPassword("password04")
            //    .SetSubscribe(true)
            //    .SetFax("fax04")
            //    .SetCompany("company04")
            //    .SetAddress2("address204");
            //Console.WriteLine("email = " + user.Email);
            //
            // 5. Add Builder
            //User user = User.Get()
            //    .SetFirstname("firstname05")
            //    .SetLastname("lastname05")
            //    .SetEmail("email05")
            //    .SetTelephone("telephone05")
            //    .SetAddress1("address105")
            //    .SetCity("city05")
            //    .SetPostcode("postcode05")
            //    .SetCountry("country05")
            //    .SetRegionState("regionState05")
            //    .SetPassword("password05")
            //    .SetSubscribe(true)
            //    .SetCompany("Company05")
            //    .Build();
            //Console.WriteLine("email = " + user.SetEmail("")); // Runtime Error
            //Console.WriteLine("email = " + user.Email);
            //
            // 6. Dependency Inversion
            //IUser user = User.Get()
            //     .SetFirstname("firstname06")
            //     .SetLastname("lastname06")
            //     .SetEmail("email06")
            //     .SetTelephone("telephone06")
            //     .SetAddress1("address106")
            //     .SetCity("city06")
            //     .SetPostcode("postcode06")
            //     .SetCountry("country06")
            //     .SetRegionState("regionState06")
            //     .SetPassword("password06")
            //     .SetSubscribe(true)
            //     .SetCompany("Company06")
            //     .Build();
            //Console.WriteLine("email = " + user.SetEmail(""));        // Compile Error
            //Console.WriteLine("email = " + ((User)user).SetEmail(""));  // Code Smell
            //Console.WriteLine("email = " + user.Email);
            //
            // 7. Singleton
            // 8. Repository
            //IUser user = UserRepository.Get()
            //    .Registered();
            //Console.WriteLine("email = " + user.Email);
            //
            // ===========================================================================
            // WebClient
            //string url = "https://api.github.com/orgs/dotnet/repos";
            // GET
            //string url = "http://localhost:8080/";
            // POST
            //string url = "http://localhost:8080/login?name=admin&password=qwerty";
            //using (var webClient = new WebClient())
            //{
            //    webClient.Headers["User-Agent"] =
            //        "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
            //        "(compatible; MSIE 6.0; Windows NT 5.1; " +
            //        ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            //    webClient.Headers["Cache-Control"] = "no-cache";
            // GET
            //var response = webClient.DownloadString(url);
            //
            // Post // Error
            //var pars = new NameValueCollection();
            //pars.Add("format", "json");
            //var response = webClient.UploadValues(url, "POST", pars);
            //
            //Console.WriteLine("response: " + response);
            //}
            //
            // ===========================================================================
            // HttpClient //Method GET
            //string url = "https://api.github.com/orgs/dotnet/repos";
            //string urlParameters = "";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            // Add an Accept header for JSON format. 
            //client.DefaultRequestHeaders.Accept.Add(
            //                new MediaTypeWithQualityHeaderValue("application/json"));
            // List data response. 
            //HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            //HttpResponseMessage response = client.GetAsync(url).Result;
            //
            // Blocking call! 
            //if (response.IsSuccessStatusCode)
            //{
            // Parse the response body. Blocking! 
            //    var result = response.Content
            //        .ReadAsStringAsync().Result;
            //    Console.WriteLine("result" + result);
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode,
            //        response.ReasonPhrase);
            //}
            //
            //
            // ===========================================================================
            // (HttpWebRequest)WebRequest
            //string url = "https://api.github.com/orgs/dotnet/repos";
            //string data = "";
            //string data = "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW"+"------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"token\"\r\n\r\n6N4K0Y4GEWV8IGPJZXOQS3I613VKVSZE\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"item\"\r\n\r\nhahaha43\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--";
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET"; // DO NOT USE request.GetRequestStream()
            //request.Method = "POST";
            //            request.Method = "DELETE";
            //request.Method = "PUT";
            //request.Headers["content-type"]="multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW";
            //request.ContentType = "application/json";
            // BODY of request
            //request.ContentLength = data.Length;
            //using (Stream webStream = request.GetRequestStream())
            //{
            //    using (StreamWriter requestWriter =
            //        new StreamWriter(webStream, System.Text.Encoding.ASCII))
            //    {
            //        requestWriter.Write(data);
            //    }
            //}
            //
            //try
            //{
            //    WebResponse webResponse = request.GetResponse();
            //    using (Stream webStream = webResponse.GetResponseStream())
            //    {
            //        if (webStream != null)
            //        {
            //            using (StreamReader responseReader = new StreamReader(webStream))
            //            {
            //                string response = responseReader.ReadToEnd();
            //                Console.WriteLine("response: " + response);
            //            }
            //        }
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.Out.WriteLine("-----------------");
            //    Console.Out.WriteLine(e.Message);
            //}
            //
            // ===========================================================================
            // RestClient
            //string url = "http://localhost:51266/";
            string url = "https://api.github.com/";
            //string url = "https://api.github.com/orgs/dotnet/repos";
            var client = new RestClient(url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest("orgs/dotnet/repos", Method.GET);
            //
            //  var request = new RestRequest("item/124?token=UDN2A0FQA0L48O2SR4CW49SWOE6IBIDE&item=SUPER_ITEM_10", Method.POST);
            //var request = new RestRequest("item/125", Method.POST);
            //var request = new RestRequest("item/125", Method.PUT);
            //var request = new RestRequest("item/125", Method.DELETE);
            //var request = new RestRequest("/items", Method.GET);
            //
            //var request = new RestRequest("api/home/123", Method.GET);
            //var request = new RestRequest("api/home/123", Method.POST);
            //var request = new RestRequest("api/home/123", Method.DELETE);
            //var request = new RestRequest("api/home/123", Method.PUT);
            //
            //request.AddParameter("token", "1OANO7DXBRZXC2EGB1A8OHA6N47EUL34");
            //request.AddParameter("item", "SUPER_ITEM_101_new");
            //
            //request.AddParameter("name", "value");
            // adds to POST or URL querystring based on Method
            //request.AddUrlSegment("id", "123");
            // replaces matching token in request.Resource
            // easily add HTTP Headers
            //request.AddHeader("header", "value");
            // add files to upload (works with compatible verbs)
            //request.AddFile(path);
            // execute the request
            IRestResponse response = client.Execute(request);
            //var content = response.Content;
            //Console.WriteLine("content: " + content);
            //
            JsonDeserializer deserial = new JsonDeserializer();
            //var obj = deserial.Deserialize<List<RestResultOrgsDotnetReposArray>>(response);
            var obj = JsonConvert.DeserializeObject<List<RestResultOrgsDotnetReposArray2>>(response.Content);
            foreach (RestResultOrgsDotnetReposArray2 current in obj)
            {
                Console.WriteLine("\nDeserialize content: " + current);
            }

            //
            // raw content as string
            // or automatically deserialize result
            // return content type is sniffed
            // but can be explicitly set via RestClient.AddHandler();
            //
            //RestResponse<Person> response2 = client.Execute<Person>(request);
            //var name = response2.Data.Name;
            // easy async support
            //client.ExecuteAsync(request, response => {
            //    Console.WriteLine(response.Content);
            //});
            // async with deserialization
            //var asyncHandle = client.ExecuteAsync<Person>(request, response => {
            //    Console.WriteLine(response.Data.Name);
            //});
            // abort the request on demand
            //asyncHandle.Abort();
            //
            // ===========================================================================
            // RestClient
            //
            //Login
            //string url = "http://localhost:8080";
            //var client = new RestClient(url);
            //var request = new RestRequest("/login", Method.POST);
            //request.AddParameter("name", "admin");          // Save parameters to body
            //request.AddParameter("password", "qwerty");
            //
            //IRestResponse response = client.Execute(request);
            //var content = response.Content;
            //Console.WriteLine("Login content: " + content);
            //
            // Deserialize
            //JsonDeserializer deserial = new JsonDeserializer();
            //var obj = deserial.Deserialize<RestResult>(response);
            //Console.WriteLine("\nDeserialize content, TOKEN: " + obj);
            //string token = obj.content;
            //
            // Change Tokenlifetime
            //string url = "http://localhost:8080";
            //var client = new RestClient(url);
            //Console.WriteLine("NEW request");
            //request = new RestRequest("/tokenlifetime", Method.PUT);
            //request.AddParameter("token", token);
            //request.AddParameter("time", "900000");
            //response = client.Execute(request);
            //string content = response.Content;
            //Console.WriteLine("Update Tokenlifetime content: " + content);
            //
            //var obj2 = deserial.Deserialize<RestResult>(response);
            //var obj2 = JsonConvert.DeserializeObject<RestResult2>(response.Content);
            //Console.WriteLine("\nDeserialize content, Update Lifetime: " + obj2);
            //
            B22 b22 = new B22();
            b22.m2();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("Path = " + path);
            //
            Console.WriteLine("done");
        }
    }
}
