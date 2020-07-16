using HistoricalQuizGame.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public enum ViewType
    {
        Start,
        Game,
        End
    }
    class GameManager:IButtonObserver
    {
        private List<Question> questions;
        private int current;
        private int points = 0;
        private bool corectSelected = false;
        public bool refresh = true;
        public bool end = false;
        public bool canNext = false;
        
        public ViewType acutalView = ViewType.Start;
        private GameManager() {
            this.questions = new List<Question>();
            current = 0;       
        }
        private static GameManager _instance;
        public static GameManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }


        public void AddQuestion(Question q)
        {
            this.questions.Add(q);
        }
        public void SetQuestions(List<Question> questions)
        {
            this.questions = questions;
        }

        public Question GetCurrentQuestion()
        {
            return this.questions[current];
        }

        public string GetPointsString()
        {
            return this.points + " na " + this.questions.Count;
        }
        public void OnSelect(Button btn)
        {
            if(btn.tag == ButtonTag.Next)
            {
                canNext = false;
                if (corectSelected)
                {
                    points += 1;
                }
                current += 1;
                if (current >= this.questions.Count)
                {
                    acutalView = ViewType.End;
                }
                refresh = true;
            }
            if (btn.tag == ButtonTag.Start)
            {
                acutalView = ViewType.Game;
                refresh = true;
            }
            if(btn.tag == ButtonTag.Restart)
            {
                points = 0;
                current = 0;
                acutalView = ViewType.Game;
                refresh = true;
            }
            if (btn.tag == ButtonTag.Koniec)
            {
                current = 0;
                end = true;
                refresh = true;
            }
            if(btn.tag == ButtonTag.Answer)
            {
                canNext = true;
                refresh = true;
                var q = this.questions[current];
                foreach(var a in q.answers) 
                {
                    if(a.title == btn.text)
                    {
                        
                        this.corectSelected = a.isCorrect;
                        break;
                    }
                    else
                    {
                        this.corectSelected = false;
                    }
                }
            }
        }
    }
}
