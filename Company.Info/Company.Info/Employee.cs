using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Company.info.Data;
using Company.info.Data.DbModels;
using System.Collections.Generic;

namespace Company.Info
{
    public class Employee
    {
        [FunctionName("GetEmployee")]
        public IActionResult GetEmployee(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "GetEmployee")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            string lname = data.lname;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name} {lname}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("GetStudent")]
        public IActionResult GetStudent(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetStudent")] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            CompanyData student = new CompanyData();
            List<TblStudent> tblstudents = student.GetStudentDetails();

            return new OkObjectResult(tblstudents);
        }
        [FunctionName("GetStudentDetails")]
        public IActionResult GetStudentDetails(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetStudentDetails")] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            String id = req.Query["Id"];

            CompanyData student = new CompanyData();
            TblStudent tblStudent = student.GetStudentById(int.Parse(id));

            return new OkObjectResult(tblStudent);
        }

        [FunctionName("InsertStudent")]
        public IActionResult InsertStudent(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get","post", Route = "InsertStudent")] HttpRequest req,
          ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            TblStudent stdata = JsonConvert.DeserializeObject<TblStudent>(requestBody);

            CompanyData student = new CompanyData();
            int studentId = student.InsertStudent(stdata);

            return new OkObjectResult(studentId);
        }
    }
}
