using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitaClientConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var gitaApiClient = new HttpClient();

            var response = await gitaApiClient.GetAsync("https://localhost:9494/api/employees");
            var hasilJSON = await response.Content.ReadAsStringAsync();

            var employees = JsonSerializer.Deserialize<List<Employee>>(hasilJSON);

            foreach (var employee in employees)
            {
                Console.WriteLine("=======================");
                Console.WriteLine("Nama: "  + employee.Name);
                Console.WriteLine("Gaji: "  + employee.Salary);
                Console.WriteLine("-----------------------");
            }
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}