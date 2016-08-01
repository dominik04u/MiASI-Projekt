using Newtonsoft.Json.Linq;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication1
{
    class Program
    {
        static async Task RunAsync()
        {
            Uri geturi = new Uri("https://api.github.com/users/kapicel");
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            HttpResponseMessage response;
            var content = "";


            string requestBodyData = "";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8082/activiti-rest/service/repository/deployments/20");
            webRequest.Method = "GET";
            //webRequest.ContentType = "";
            webRequest.Timeout = 1000 * 60;

            //CredentialCache setCredential = new CredentialCache();
            //setCredential.Add(new Uri(requestUrl), "Basic", new NetworkCredential("kermit", "kermit"));
            //webRequest.Credentials = setCredential;
            webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes("kermit" + ":" + "kermit")));
            if (requestBodyData != null)
            {
                Console.WriteLine(requestBodyData);
                //webRequest.ContentLength = requestBodyData.Length;
                //Stream dataStream = webRequest.GetRequestStream();
                //dataStream.Write(requestBodyData, 0, requestBodyData.Length);
                //dataStream.Close();
            }
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();



            try
            {
                var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
                var user = await github.User.Get("kapicel");
                Console.WriteLine(user.Login);
                
            }
            catch(HttpRequestException re)
            {
                Console.WriteLine(re.Message);
            }
            
            Console.WriteLine("1");
            JObject results = JObject.Parse(content);
            string cos = "weeeeee";

            Console.WriteLine(cos);
        }
        static void Main(string[] args)
        {
            RunAsync();
            Console.ReadKey();
        }
    }
}