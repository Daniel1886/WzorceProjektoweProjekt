using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public class Button:UIElement
    {      
        public string text;
        public ConsoleColor borderColor;
        public ConsoleColor textColor;
        public ConsoleColor backgroundColor;
        public Button(string text, Vector2Int pos)
        {
            this.position = pos;
            this.text = text;
            this.borderColor = ConsoleColor.Black;
            this.borderColor = ConsoleColor.Black;
            this.textColor = ConsoleColor.White;
        }
        public void  SetColors(ConsoleColor backgroundColor, ConsoleColor textColor, ConsoleColor borderColor)
        {
            this.backgroundColor = backgroundColor;
            this.textColor = textColor;
            this.borderColor = borderColor;
        }
    }
}
