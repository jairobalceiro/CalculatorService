using CalculatorService.Model;
using CalculatorService.Server.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;


namespace CalculatorService.Client
{
    class Program
    {
        private static readonly string url = "https://localhost:5001/";
        public Program()
        {

            
        }

        /// <summary>
        /// Cliente para el servicio api/calculator/add
        /// </summary>
        /// <param name="Addends"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        static async Task Add(List<int> Addends, string trackingId)
        {
            var addPost = new AddDto() {
                Addends = Addends
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if(!string.IsNullOrEmpty(trackingId))
                client.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/calculator/add", addPost);
                if (responsePost.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                   // Console.WriteLine(responsePost.Content.ReadAsStringAsync().Result);
                    Sums sum = JsonConvert.DeserializeObject<Sums>(responsePost.Content.ReadAsStringAsync().Result);
                    Console.WriteLine(string.Format("Sum:{0}",sum.Sum));
                }
            }
        }

        static async Task Sub(SubDto sub, string trackingId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(trackingId))
                    client.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/calculator/sub", sub);
                if (responsePost.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    // Console.WriteLine(responsePost.Content.ReadAsStringAsync().Result);
                    Sub difference = JsonConvert.DeserializeObject<Sub>(responsePost.Content.ReadAsStringAsync().Result);
                    Console.WriteLine(string.Format("Difference: {0}", difference.Difference));
                }
            }
        }

        static async Task Mult(MultDto multdto, string trackingId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(trackingId))
                    client.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/calculator/mult", multdto);
                if (responsePost.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    // Console.WriteLine(responsePost.Content.ReadAsStringAsync().Result);
                    Mult mult = JsonConvert.DeserializeObject<Mult>(responsePost.Content.ReadAsStringAsync().Result);
                    Console.WriteLine(string.Format("Product: {0}", mult.Product));
                }
            }
        }

        static async Task Div(DivDto divdto, string trackingId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(trackingId))
                    client.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/calculator/div", divdto);
                if (responsePost.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    // Console.WriteLine(responsePost.Content.ReadAsStringAsync().Result);
                    Div div = JsonConvert.DeserializeObject<Div>(responsePost.Content.ReadAsStringAsync().Result);
                    Console.WriteLine(string.Format("Quotient: {0}", div.Quotient));
                    Console.WriteLine(string.Format("Remainder: {0}", div.Remainder));
                }
            }
        }

        static async Task Sqrt(SqrtDto sqrtdto, string trackingId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(trackingId))
                    client.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/calculator/sqrt", sqrtdto);
                if (responsePost.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    // Console.WriteLine(responsePost.Content.ReadAsStringAsync().Result);
                    Sqrt sqrt = JsonConvert.DeserializeObject<Sqrt>(responsePost.Content.ReadAsStringAsync().Result);
                    Console.WriteLine(string.Format("Square: {0}", sqrt.Square));
                }
            }
        }

        static async Task Query(QueryDto queryDto)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               
                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/journal/query", queryDto);
                if (responsePost.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    // Console.WriteLine(responsePost.Content.ReadAsStringAsync().Result);
                    List<Operations> operations = JsonConvert.DeserializeObject<List<Operations>>(responsePost.Content.ReadAsStringAsync().Result);
                    foreach(Operations operation in operations)
                    {
                        Console.WriteLine(string.Format("Operation: {0} , Calculation : {1}, Date : {2}", operation.Operation, operation.Calculation,operation.Date));

                    }
                }
            }
        }


        static void Main(string[] args)
        {
            string trackingId = "1143326479";
            List<int> Addends = new List<int>();
            Addends.Add(3);
            Addends.Add(3);
            Addends.Add(2);
            SubDto subdto = new SubDto()
            {
                Minuend = 5,
                Subtrahend = 3
            };

            List<int> Factors = new List<int>();
            Factors.Add(8);
            Factors.Add(3);
            Factors.Add(2);

            MultDto multdto = new MultDto()
            {
                Factors = Factors
            };
            DivDto divdto = new DivDto()
            {
                Dividend = 4,
                Divisor = 2
            };
            SqrtDto sqrtdto = new SqrtDto()
            {
                Number = 6
            };
            QueryDto queryDto = new QueryDto()
            {
                 Id= trackingId
            };
            Add(Addends, trackingId).Wait();
            Sub(subdto, trackingId).Wait();
            Mult(multdto, trackingId).Wait();
            Div(divdto, trackingId).Wait();
            Sqrt(sqrtdto, trackingId).Wait();
            Query(queryDto).Wait();

            Console.Read();

        }
    }
}
