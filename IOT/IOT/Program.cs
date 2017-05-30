using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace IOT
{
    class Program
    {
        public class Watch
        {
            public int UserId { get; set; }

            public DateTime Date { get; set; }

            public DateTime StartExcerciseTime { get; set; }

            public DateTime FinishExcerciseTime { get; set; }

            public decimal AverageHeartbeat { get; set; }

            public float KaloriesBurnt { get; set; }
        }

        public class Motion
        {
            public int UserId { get; set; }

            public DateTime Date { get; set; }

            public DateTime Start { get; set; }

            public DateTime Finish { get; set; }

            public decimal KilometersWalked { get; set; }
        }

        public class Balance
        {
            public int UserId { get; set; }

            public DateTime Date { get; set; }

            public DateTime Start { get; set; }

            public DateTime Finish { get; set; }

            public string SessionEvaluation { get; set; }

            public decimal LeftWeightShift { get; set; }

            public decimal RightWeightShift { get; set; }

            public decimal FrontWeightShift { get; set; }

            public decimal BackWeightShift { get; set; }
        }

        private const string Url = "http://localhost:5100";

        static void Main()
        {
            using (var httpClient = new HttpClient())
            {
                var watchPost = new Watch
                {
                    UserId = 1,
                    Date = DateTime.UtcNow.AddDays(-1),
                    StartExcerciseTime = DateTime.UtcNow.AddDays(-1),
                    FinishExcerciseTime = DateTime.UtcNow.AddDays(-1).AddHours(-1),
                    AverageHeartbeat = 130,
                    KaloriesBurnt = 23000
                };
                var motionPost = new Motion
                {
                    UserId = 1,
                    Date = DateTime.UtcNow.AddDays(-1),
                    Start = DateTime.UtcNow.AddDays(-1),
                    Finish = DateTime.UtcNow.AddDays(-1).AddHours(-1),
                    KilometersWalked = 3
                };
                var balancePost = new Balance
                {
                    UserId = 1,
                    Date = DateTime.UtcNow.AddDays(-1),
                    Start = DateTime.UtcNow.AddDays(-1),
                    Finish = DateTime.UtcNow.AddDays(-1).AddHours(-1),
                    BackWeightShift = 1,
                    FrontWeightShift = 2,
                    RightWeightShift = 2,
                    LeftWeightShift = (decimal)3.5,
                    SessionEvaluation = "Good"
                };

                var serializedWatch = new StringContent(JsonConvert.SerializeObject(watchPost), Encoding.UTF8, "application/json");
                var serializedMotion = new StringContent(JsonConvert.SerializeObject(motionPost), Encoding.UTF8, "application/json");
                var serializedBalance = new StringContent(JsonConvert.SerializeObject(balancePost), Encoding.UTF8, "application/json");

                //httpClient.PostAsync(Url + "/api/watch", serializedWatch);
                //httpClient.PostAsync(Url + "/api/motion", serializedMotion);
                var test = httpClient.PostAsync(Url + "/api/balance", serializedBalance).Result;
            }
        }
    }
}