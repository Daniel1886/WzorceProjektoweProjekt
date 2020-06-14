using System;

namespace HistoricalQuizGame
{
    class Program
    {
        static void Main(string[] args)
        {
            UI _ui = new UI(50, 20);
            _ui.InitWindow();
            _ui.DrowWindow();

            Label question = new Label("Pierwsze pytanie Pierwsze pytaniePierwsze pytaniePierwsze  ?", new Vector2Int(1, 1));
            _ui.DrowLabel(question);
            
            Button button = new Button("a) W 2020 roku", new Vector2Int(4, 16));
            _ui.DrowButton(button);
            
            Button nextButton = new Button(" Następne(N/n) ", new Vector2Int(33, 17));
            _ui.DrowButton(nextButton);
            
            _ui.Refresh();

        }
    }
}
