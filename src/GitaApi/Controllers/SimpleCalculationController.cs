using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GitaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        public List<Employee> AllEmployees
        {
            get
            {
                Employee employee1 = new Employee();
                employee1.Id = 1;
                employee1.Name = "Fuady Rosma Hidayat";
                employee1.Salary = 5000;

                Employee employee2 = new Employee();
                employee2.Id = 2;
                employee2.Name = "Aprilia Gita Kencana";
                employee2.Salary = 7000;

                Employee employee3 = new Employee();
                employee3.Id = 3;
                employee3.Name = "Tenisa eka Putri";
                employee3.Salary = 7000;

                List<Employee> employees = new List<Employee>();
                employees.Add(employee1);
                employees.Add(employee2);
                employees.Add(employee3);

                return employees;
            }
        }

        [HttpGet]
        public string GetAllEmployees()
        {
            var hasil = JsonSerializer.Serialize(AllEmployees);
            return hasil;
        }

        [HttpGet]
        [Route("{nomor}")]
        public string GetEmployee(int nomor)
        {
            Employee selectedEmployee = null;

            foreach (var employee in AllEmployees)
            {
                if (employee.Id == nomor)
                {
                    selectedEmployee = employee;
                }
            }

            var hasil = JsonSerializer.Serialize(selectedEmployee);
            return hasil;
        }

        [HttpGet]
        [Route("json")]
        public string HelloJSON()
        {
            Employee employee = new Employee();
            employee.Name = "Fuady Rosma Hidayat";
            employee.Salary = 5000;

            var hasil = JsonSerializer.Serialize(employee);
            return hasil;
        }

        [HttpGet]
        [Route("xml")]
        public string HelloXML()
        {
            Employee employee = new Employee();
            employee.Name = "Fuady Rosma Hidayat";
            employee.Salary = 5000;

            XmlSerializer x = new XmlSerializer(employee.GetType());
            string hasil = string.Empty;

            using (StringWriter textWriter = new StringWriter())
            {
                x.Serialize(textWriter, employee);
                hasil = textWriter.ToString();
            }

            return hasil;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}