using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class HighScore
    {
        public HighScore()
        {

                
        }
        public string Name { get; set; }
        public int HighScoreRanking { get; set; }
        public int HighScorePoints { get; set; }
     
       
        

        public List<HighScore> HighScoreObj = new List<HighScore>();
        private List<HighScore> RevisedHighScoreObj = new List<HighScore>();

        public bool HighScoreIsChanged = false;
        public string inComingJson;

        public void BuildNewHighscore()
        {
            string name1 = HighScoreObj[0].Name;
            string name2 = HighScoreObj[1].Name;
            string name3 = HighScoreObj[2].Name;
            int rank1 = 1;
            int rank2 = 2;
            int rank3 = 3;
            int score1 = HighScoreObj[0].HighScorePoints;
            int score2 = HighScoreObj[1].HighScorePoints;
            int score3 = HighScoreObj[2].HighScorePoints;
            HighScore p1 = new HighScore()
            {
                Name = name1,
                HighScorePoints = score1,
                HighScoreRanking = rank1
            };
            HighScore p2 = new HighScore()
            {
                Name = name2,
                HighScorePoints = score2,
                HighScoreRanking = rank2

            };
            HighScore p3 = new HighScore()
            {
                Name = name3,
                HighScorePoints = score3,
                HighScoreRanking = rank3

            };
            RevisedHighScoreObj.Add(p1);
            RevisedHighScoreObj.Add(p2);
            RevisedHighScoreObj.Add(p3);
            WriteHighScoreToMyJson();


        }
    
        public void CheckRankingVsOthers(HighScore _score)
        {
            ReadHighScoreFromMyJson();
            for (int i=0; i < HighScoreObj.Count; i++)
            {
                if (_score.HighScorePoints > HighScoreObj[i].HighScorePoints)
                {
                    _score.HighScoreRanking = HighScoreObj[i].HighScoreRanking;
                    HighScoreObj.Insert(i, _score);
                    HighScoreObj.RemoveAt(3);
                    HighScoreIsChanged = true;
                    BuildNewHighscore();
                    break;
                }
            }
            
           
        }

        public void ReadHighScoreFromMyJson()
        {
            
            using (WebClient wc = new WebClient())
            {
                inComingJson = wc.DownloadString("https://api.myjson.com/bins/n4z5");
                var highScoreObj = JsonConvert.DeserializeObject<List<HighScore>>(inComingJson);
                for (int i = 0; i<highScoreObj.Count; i++)
                {
                    HighScoreObj.Add(highScoreObj[i]);
                  
                }
              
             
                
            }

        }

        public void WriteHighScoreToMyJson()
        {
            // detta var det enda sättet jag kunde hitta på stackoverflow som inte ger dig self referencing loop
            // men det fuckar verkligen upp hur json strängen formateras efter det:...... vill ju inte att den ska se ut på något 
            // annat sätt en den gör just nu på https://api.myjson.com/bins/n4z5
            // man kan inte editera den online men jag har en annan fil som nollställer den typ.
            // Gör det inte åt mig utan förklara vad hjag fuckat upp referserna till listorna..... tycker ju att det är rätt men 
            // det lär det ju inte vara =) 
            //

            //tack för en grym helg bror
            // string json = JsonConvert.SerializeObject(HighScoreObj, Formatting.Indented, new JsonSerializerSettings
            // {
            //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            // });
            string json = JsonConvert.SerializeObject(RevisedHighScoreObj);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.myjson.com/bins/n4z5");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {


                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

           var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
           using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
           {
              var result = streamReader.ReadToEnd();
           }

        }


        /// <summary>
        /// För att skriva ut highscore vid död
        /// </summary>
        public void PostHighScoreOnDeath()
        {
            
            for (int i =0; i<HighScoreObj.Count; i++)
            {
                Console.SetCursorPosition(15, 15 + i);
                Console.WriteLine(HighScoreObj[i].HighScoreRanking +". "+HighScoreObj[i].Name + "       Score : " +HighScoreObj[i].HighScorePoints);
              
            }
           

            
        }
    }
}
