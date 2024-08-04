using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IoTDevice
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ServerUrl = "https://localhost:7010/api/temperature";

        static async Task Main(string[] args)
        {
            while (true)
            {
                double temperature = GenerateTemperature();
                await SendTemperatureAsync(temperature);
                Console.WriteLine($"Sent temperature: {temperature}");
                await Task.Delay(5000); //Waits for 5 seconds before sending the next reading
            }
        }

        static double GenerateTemperature()
        {
            Random rand = new Random();
            return Math.Round(rand.NextDouble() * 50 - 10, 2); // Generates a temperature between -10 and 40
        }

        static async Task SendTemperatureAsync(double temperature)
        {
            var data = new
            {
                Value = temperature,
                Timestamp = DateTime.Now
            };

            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(ServerUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
