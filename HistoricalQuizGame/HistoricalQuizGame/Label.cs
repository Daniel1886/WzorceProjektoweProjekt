using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public class Label : UIElement
    {
        public string text;
        public ConsoleColor textColor;
        public Label(string text,Vector2Int pos)
        {
            this.position = pos;
            this.text = text;
        }
    }
}
