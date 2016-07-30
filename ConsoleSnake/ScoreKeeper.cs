using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using ConsoleSnake.Model;

namespace ConsoleSnake
{
    class ScoreKeeper
    {
        public int CurrentScore = 0;
        private const string JsonStoreUrl = "https://api.myjson.com/bins/2x7dr";
        private const int NumberOfSavedScores = 5;
        public bool IsNewHighScore()
        {
            var list = GetHighScores();
            return list.Min(s => s.Score) < CurrentScore;
        }

        public List<HighScore> GetHighScores()
        {
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(JsonStoreUrl);
                var highScores = JsonConvert.DeserializeObject<List<HighScore>>(json);
                return highScores.OrderByDescending(x => x.Score).Take(NumberOfSavedScores).ToList();
            }
        }

        internal void AddNewHighScore(HighScore highScore)
        {
            var list = GetHighScores();
            list.Add(highScore);

            PostHighScores(list);
        }

        private void PostHighScores(List<HighScore> list)
        {
            string json = JsonConvert.SerializeObject(list);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(JsonStoreUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
