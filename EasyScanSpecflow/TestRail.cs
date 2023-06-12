using EasyScanSpecflow.StepLogging;
using Gurock.TestRail;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow
{
    public class TestRail
    {
        public static APIClient Client { get; set; }
        public static JObject CreatedTestRunResponse { get; set; }

        public static void InitializeTestRail()
        {
            Client = new APIClient(Config.testrailConfiguration["url"])
            {
                User = Config.testrailConfiguration["username"],
                Password = Config.testrailConfiguration["authenticationKey"]
            };
        }
        private static void CreateTestRun()
        {
            Dictionary<string, object> testRun = new Dictionary<string, object>()
            {
                { "suite_id", 322}, // Smoke tests suite id 322
                { "name", "Smoke tests"},
                { "include_all", true }
            };

            CreatedTestRunResponse = (JObject)Client.SendPost("add_run/29", testRun); // EasyScan project id 29
        }
    }
}
