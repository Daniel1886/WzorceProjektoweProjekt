using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame.Interfaces
{
    public interface IButtonObservable
    {
        void Subscribe(IButtonObserver observer);
        void UnSubscribe(IButtonObserver observer);
    }
}
