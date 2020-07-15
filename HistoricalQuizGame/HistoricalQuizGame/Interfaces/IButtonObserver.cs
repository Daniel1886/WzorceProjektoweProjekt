using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public interface IButtonObserver
    {
        void OnSelect(Button btn);
    }
}
