using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame.DataModels
{
    public class Question
    {
        public string title;
        public List<Answer> answers;

        public Question()
        {
            this.answers = new List<Answer>();
        }
    }
}
