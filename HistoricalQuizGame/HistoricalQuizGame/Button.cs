using HistoricalQuizGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public enum ButtonTag
    {
        Next,
        Answer,
        Start,
        Restart,
        Koniec
    }
    public class Button:UIElement, IButtonObservable
    {      
        public string text;
        private bool selectable;
        private bool isSelected;
        private bool isFocus;

        private List<IButtonObserver> observers = new List<IButtonObserver>();
        public ButtonTag tag;
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


        public Button(string text, Vector2Int pos,ButtonTag tag )
        {
            this.position = pos;
            this.text = text;
            this.borderColor = ConsoleColor.Black;
            this.borderColor = ConsoleColor.Black;
            this.textColor = ConsoleColor.White;
            this.selectable = true;
            this.tag = tag;
        }
        public Button(string text, Vector2Int pos,bool selectable,ButtonTag tag)
        {
            this.position = pos;
            this.text = text;
            this.borderColor = ConsoleColor.Black;
            this.borderColor = ConsoleColor.Black;
            this.textColor = ConsoleColor.White;
            this.selectable = this.selectable;
            this.tag = tag;
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
        public void SetSelectColors(ConsoleColor backgroundColor, ConsoleColor textColor, ConsoleColor borderColor)
        {
            this.selectBackgroundColor = backgroundColor;
            this.selectTextColor = textColor;
            this.selectBorderColor = borderColor;
        }
        public void SetFocusColors(ConsoleColor backgroundColor, ConsoleColor textColor, ConsoleColor borderColor)
        {
            this.focusBackgroundColor = backgroundColor;
            this.focusTextColor = textColor;
            this.focusBorderColor = borderColor;
        }
        public void SetText(string text)
        {
            this.text = text;
        }
        public void Select()
        {
            isSelected = true;
            if (!isFocus)
            {
                this.backgroundColor = this.selectBackgroundColor;
                this.borderColor = this.selectBorderColor;
                this.textColor = this.selectTextColor;
            }
            foreach (var o in observers)
            {
                o.OnSelect(this);
            }
        }
        public void Deselect()
        {
            isSelected = false;
            if (!isFocus)
            {
                this.backgroundColor = this.defaultBackgroundColor;
                this.borderColor = this.defaultBorderColor;
                this.textColor = this.defaultTextColor;
            }
            else
            {
                this.backgroundColor = this.focusBackgroundColor;
                this.borderColor = this.focusBorderColor;
                this.textColor = this.focusTextColor;
            }           
        }
        public void Focus()
        {
            this.isFocus = true;
            this.backgroundColor = this.focusBackgroundColor;
            this.borderColor = this.focusBorderColor;
            this.textColor = this.focusTextColor; 
        }
        public void Unfocus()
        {
            this.isFocus = false;
            if (!isSelected)
            {
                this.backgroundColor = this.defaultBackgroundColor;
                this.borderColor = this.defaultBorderColor;
                this.textColor = this.defaultTextColor;
            }
            else
            {
                this.backgroundColor = this.selectBackgroundColor;
                this.borderColor = this.selectBorderColor;
                this.textColor = this.selectTextColor;
            }

        }      
        public bool IsSelectable()
        {
            return selectable;
        }

        public void Subscribe(IButtonObserver observer)
        {
            this.observers.Add(observer);
        }

        public void UnSubscribe(IButtonObserver observer)
        {
            this.observers.Remove(observer);
        }
    }
}
