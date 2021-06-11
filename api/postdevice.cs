using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Device.Function
{
    public static class postdevice
    {
        [FunctionName("postdevice")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "PostDevice")] HttpRequest req,
            [CosmosDB(
                databaseName: "Devices",
                collectionName: "Devices",
                ConnectionStringSetting = "CosmosDbConnectionString")]IAsyncCollector<dynamic> documentsOut,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

          string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
          dynamic data = JsonConvert.DeserializeObject(requestBody);
            string date = DateTime.Now.ToShortDateString();

          await documentsOut.AddAsync(new
            {
                // create a random ID
                DeviceId = System.Guid.NewGuid().ToString(),
                Devicename = data.name,
                DeviceType = data.DeviceType,
                RequestedDate = date,
                CompletedDate = "",
                ApproximateAmount = data.ApproximateAmount,
                ActualAmount = data.ActualAmount,
                Status = data.Status
            });

            return new OkResult();
        }
    }
}
