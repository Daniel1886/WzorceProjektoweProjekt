using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public class Button:UIElement
    {      
        public string text;
        private bool selectable;
        public ConsoleColor borderColor;
        public ConsoleColor textColor;
        public ConsoleColor backgroundColor;

        public ConsoleColor focusBorderColor;
        public ConsoleColor focusTextColor;
        public ConsoleColor focusBackgroundColor;

        private ConsoleColor selectBorderColor;
        private ConsoleColor selectTextColor;
        private ConsoleColor selectBackgroundColor;

        private ConsoleColor defaultBorderColor;
        private ConsoleColor defaultTextColor;
        private ConsoleColor defaultBackgroundColor;


        public Button(string text, Vector2Int pos )
        {
            this.position = pos;
            this.text = text;
            this.borderColor = ConsoleColor.Black;
            this.borderColor = ConsoleColor.Black;
            this.textColor = ConsoleColor.White;
            this.selectable = true;
        }
        public Button(string text, Vector2Int pos,bool selectable)
        {
            this.position = pos;
            this.text = text;
            this.borderColor = ConsoleColor.Black;
            this.borderColor = ConsoleColor.Black;
            this.textColor = ConsoleColor.White;
            this.selectable = this.selectable;
        }
        public void  SetColors(ConsoleColor backgroundColor, ConsoleColor textColor, ConsoleColor borderColor)
        {
            this.backgroundColor = backgroundColor;
            this.textColor = textColor;
            this.borderColor = borderColor;

            this.defaultBackgroundColor = backgroundColor;
            this.defaultTextColor = textColor;
            this.defaultBorderColor = borderColor;
        }
        public void SetFocusColors(ConsoleColor backgroundColor, ConsoleColor textColor, ConsoleColor borderColor)
        {
            this.focusBackgroundColor = backgroundColor;
            this.focusTextColor = textColor;
            this.focusBorderColor = borderColor;
        }
        public void Focus()
        {
            this.backgroundColor = this.focusBackgroundColor;
            this.borderColor = this.focusBorderColor;
            this.textColor = this.focusTextColor; 
        }
        public void Unfocus()
        {
            this.backgroundColor = this.defaultBackgroundColor;
            this.borderColor = this.defaultBorderColor;
            this.textColor = this.defaultTextColor;
        }
    }
}
