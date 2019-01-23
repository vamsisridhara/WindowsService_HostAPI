using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace APIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(GetStringAsync);
            t.Start();

            Task t1 = new Task(PostFileInfoAsync);
            t1.Start();

            Task t2 = new Task(PostTrackingNumberAsync);
            t2.Start();
            Console.WriteLine("Results...");
            Console.ReadLine();
        }
        static async void PostFileInfoAsync()
        {
            string url = "http://localhost:8080/Values/FileInfo";
            Models.File fileinfo = new Models.File
            {
                meterId = "1234567890",
                name = "Rate/Discount",
                startDate = DateTime.Now.AddDays(-30),
                endDate = DateTime.Now.AddDays(300),
                type = 4,
                status = 0,
                systemId = "ALMFC01"
            };
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.PostAsJsonAsync<Models.File>(url, fileinfo))
            using (HttpContent content = response.Content)
            {
                var result = await content.ReadAsStringAsync();
                Console.WriteLine("File Info Reuslt: " + result);
            }
        }
        static async void PostTrackingNumberAsync()
        {
            string url = "http://localhost:8080/Values/TrackingNumber";
            Models.TrackingNumber trackingnumberinfo = new Models.TrackingNumber
            {
                meterId = "1234567890",
                rangeStart = "1000001",
                rangeEnd = "1009999",
                nextNumber = "1000010",
                type = 0,
                status = 0,
                systemId = "ALMFC01"
            };
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.PostAsJsonAsync<Models.TrackingNumber>(url, trackingnumberinfo))
            using (HttpContent content = response.Content)
            {
                var result = await content.ReadAsStringAsync();
                Console.WriteLine("Tracking Number Result: " + result );
            }
        }

        static async void GetStringAsync()
        {
            string url = "http://localhost:8080/Values/GetString/1";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                var result = await content.ReadAsStringAsync();
                Console.WriteLine("Get String Async Result:" + result);
            }
        }
       
    }
}
