using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
   
    class ButtonsEvents
    {
        private List<Button> buttons;
        int currentSelected = 0;
        Button lastSelectedBtn;
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
        public void Clear()
        {
            buttons.Clear();
            currentSelected = 0;
            lastSelectedBtn = null;
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
        public void Previous()
        {
            Reset();         
            if (currentSelected - 1 >= 0)
                currentSelected -= 1;
            else currentSelected = this.buttons.Count - 1;
            this.buttons[currentSelected].Focus();
            _ui.DrowButton(this.buttons[currentSelected]);
        }
        public void SelectBtn(int index)
        {
            if (this.buttons[index].IsSelectable())
            {
                if (lastSelectedBtn != null)
                {
                    lastSelectedBtn.Deselect();
                    _ui.DrowButton(lastSelectedBtn);
                }
                lastSelectedBtn = this.buttons[index];
                lastSelectedBtn.Select();
                _ui.DrowButton(lastSelectedBtn);
            }
        }
        public void FocusBtn(int index)
        {         
            Reset();
            this.buttons[currentSelected].Focus();
            _ui.DrowButton(this.buttons[index]);
        }
        public void SelectCurrentBtn()
        {
            if (this.buttons[currentSelected].IsSelectable())
            {
                if (lastSelectedBtn != null)
                {
                    lastSelectedBtn.Deselect();
                    _ui.DrowButton(lastSelectedBtn);
                }
                lastSelectedBtn = this.buttons[currentSelected];          
                lastSelectedBtn.Select();
                _ui.DrowButton(lastSelectedBtn);
            }       
        }
    }
}
