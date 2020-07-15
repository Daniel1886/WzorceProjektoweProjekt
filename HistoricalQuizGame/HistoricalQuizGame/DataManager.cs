using HistoricalQuizGame.DataModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HistoricalQuizGame
{
    class DataManager
    {
        private DataManager() { }
        private static DataManager _instance;
        public static DataManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }
        public List<Question> GetData()
        {
            List<Question> questions = new List<Question>();
            using (StreamReader file = File.OpenText(@"data.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                questions = serializer.Deserialize<List<Question>>(reader);
            }
            return questions;
        }
        public void SeedData()
        {
            Question q1 = new Question();
            q1.title = "W którym roku urodził się Kazimierz III Wielki?";
            Answer q1a1 = new Answer();
            q1a1.title = "1310";
            q1a1.isCorrect = true;
            Answer q1a2 = new Answer();
            q1a2.title = "1410";
            q1a2.isCorrect = false;
            Answer q1a3 = new Answer();
            q1a3.title = "1210";
            q1a3.isCorrect = false;
            Answer q1a4 = new Answer();
            q1a4.title = "1430";
            q1a4.isCorrect = false;
            q1.answers.Add(q1a1);
            q1.answers.Add(q1a2);
            q1.answers.Add(q1a3);
            q1.answers.Add(q1a4);

            Question q2 = new Question();
            q2.title = "Kiedy wybuchła II wojna światowa?";
            Answer q2a1 = new Answer();
            q2a1.title = "1 wrzesień 1939";
            q2a1.isCorrect = true;
            Answer q2a2 = new Answer();
            q2a2.title = "1 sierpień 1939";
            q2a2.isCorrect = false;
            Answer q2a3 = new Answer();
            q2a3.title = "31 sierpień 1939";
            q2a3.isCorrect = false;
            Answer q2a4 = new Answer();
            q2a4.title = "31 wrzesień 1939";
            q2a4.isCorrect = false;
            q2.answers.Add(q2a1);
            q2.answers.Add(q2a2);
            q2.answers.Add(q2a3);
            q2.answers.Add(q2a4);

            Question q3 = new Question();
            q3.title = "W którym roku odbył się chrzest Polski?";
            Answer q4a1 = new Answer();
            q4a1.title = "966";
            q4a1.isCorrect = true;
            Answer q4a2 = new Answer();
            q4a2.title = "950";
            q4a2.isCorrect = false;
            Answer q4a3 = new Answer();
            q4a3.title = "699";
            q4a3.isCorrect = false;
            Answer q4a4 = new Answer();
            q4a4.title = "650";
            q4a4.isCorrect = false;
            q3.answers.Add(q4a1);
            q3.answers.Add(q4a2);
            q3.answers.Add(q4a3);
            q3.answers.Add(q4a4);

            List<Question> questions = new List<Question>();
            questions.Add(q1);
            questions.Add(q2);
            questions.Add(q3);


            using (StreamWriter file = File.CreateText(@"data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();                        
                serializer.Serialize(file, questions);
            }
        }
    }
}
