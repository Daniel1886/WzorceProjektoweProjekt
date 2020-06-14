using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public class Button:UIElement
    {      
        public string text;
        public Button(string text, Vector2Int pos)
        {
            this.position = pos;
            this.text = text;
        }
    }
}
