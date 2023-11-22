using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http.Headers;

namespace ConsoleClient1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            RestClient client = new RestClient();
            RestRequest req1 = new RestRequest("https://localhost:7186/api/Name/authenticate",Method.Post);
            req1.AddJsonBody(new
            {
                username = "test1",
                password="password1"
            });
            var response1 = client.Execute(req1);
            var token = response1.Content.Trim('"');
            Console.WriteLine(response1.Content);

            RestRequest req2 = new RestRequest("https://localhost:7186/api/Name", Method.Get);
            client.AddDefaultHeader("Authorization",$"Bearer {token}");
            var response2=client.Execute(req2).Content;
            Console.WriteLine(response2);


            Console.ReadLine();
        }
    }
}