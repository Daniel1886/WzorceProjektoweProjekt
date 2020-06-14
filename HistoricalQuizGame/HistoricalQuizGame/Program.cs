using System;

namespace HistoricalQuizGame
{
    class Program
    {
        static void Main(string[] args)
        {
            UI _ui = new UI(75, 25);
            _ui.InitWindow();
            _ui.DrowWindow();

            Label question = new Label("Pierwsze pytanie Pierwsze pytaniePierwsze pytaniePierwsze  ?", new Vector2Int(2, 2));
            _ui.DrowLabel(question);
            
            Button button = new Button("a) W 2020 roku              (A/a)", new Vector2Int(4, 6));
            button.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            _ui.DrowButton(button);

            Button button2 = new Button("b) W 2020 roku efef    efef (B/b)", new Vector2Int(4, 10));
            button2.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            _ui.DrowButton(button2);

            Button button3 = new Button("c) W 2020 roku reger        (C/c)", new Vector2Int(4, 14));
            button3.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            _ui.DrowButton(button3);

            Button button4 = new Button("d) W 2020 roku reeeeeeeeeee (D/d)", new Vector2Int(4, 18));
            button4.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            _ui.DrowButton(button4);

            Button nextButton = new Button(" Następne(N/n) ", new Vector2Int(58, 22));
            nextButton.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            _ui.DrowButton(nextButton);
            
            _ui.Refresh();

        }
    }
}
