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
        public string HighScoreRanking { get; set; }
        public int HighScorePoints { get; set; }
     
       
        

        public List<HighScore> HighScoreObj = new List<HighScore>();
        
        public bool HighScoreIsChanged = false;
        public string inComingJson;

    
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
            string json = JsonConvert.SerializeObject(HighScoreObj, Formatting.Indented, new JsonSerializerSettings
            {
                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            
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
