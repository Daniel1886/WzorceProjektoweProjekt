using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
   
    class ButtonsEvents
    {
        private List<Button> buttons;
        int currentSelected = 0;
        public UI _ui;
        public ButtonsEvents(UI _ui)
        {
            this._ui = _ui;
            this.buttons = new List<Button>();
        }
        public void AddButton(Button btn)
        {
            this.buttons.Add(btn);
        }
        private void Reset()
        {
            foreach(var btn in buttons)
            {
                btn.Unfocus();
                _ui.DrowButton(btn);
            }
        }
        public void Next()
        {
            Reset();
            if (this.buttons.Count > currentSelected + 1)
                currentSelected += 1;
            else currentSelected = 0;

            this.buttons[currentSelected].Focus();
            _ui.DrowButton(this.buttons[currentSelected]);
        }
        public Button Previous()
        {
            Reset();         
            if (currentSelected - 1 >= 0)
                currentSelected -= 1;
            else currentSelected = this.buttons.Count - 1;
            this.buttons[currentSelected].Focus();
            _ui.DrowButton(this.buttons[currentSelected]);
            return this.buttons[currentSelected];
        }
    }
}
