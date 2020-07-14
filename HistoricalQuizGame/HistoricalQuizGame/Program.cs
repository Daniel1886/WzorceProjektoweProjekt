using System;
using System.Diagnostics;
using System.Threading;

namespace HistoricalQuizGame
{
    class Program
    {
        static void Main(string[] args)
        {
            InputManager input = InputManager.GetInstance();
         

            Stopwatch timer = new Stopwatch();
            timer.Start();

            UI _ui = new UI(75, 25);
            ButtonsEvents btnEvents = new ButtonsEvents(_ui);
            _ui.InitWindow();
            _ui.DrowWindow();

            Label question = new Label("Pierwsze pytanie Pierwsze pytaniePierwsze pytaniePierwsze  ?", new Vector2Int(2, 2));
            _ui.DrowLabel(question);

            Button button = new Button("a) W 2020 roku              (A/a)", new Vector2Int(4, 6));
            button.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            button.SetFocusColors(ConsoleColor.Green, ConsoleColor.White, ConsoleColor.DarkGreen);
            _ui.DrowButton(button);

            Button button2 = new Button("b) W 2020 roku efef    efef (B/b)", new Vector2Int(4, 10));
            button2.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            button2.SetFocusColors(ConsoleColor.Green, ConsoleColor.White, ConsoleColor.DarkGreen);
            _ui.DrowButton(button2);

            Button button3 = new Button("c) W 2020 roku reger        (C/c)", new Vector2Int(4, 14));
            button3.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            button3.SetFocusColors(ConsoleColor.Green, ConsoleColor.White, ConsoleColor.DarkGreen);
            _ui.DrowButton(button3);

            Button button4 = new Button("d) W 2020 roku reeeeeeeeeee (D/d)", new Vector2Int(4, 18));
            button4.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            button4.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            _ui.DrowButton(button4);

            Button nextButton = new Button(" Następne(N/n) ", new Vector2Int(58, 22),false);
            nextButton.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            nextButton.SetFocusColors(ConsoleColor.Green, ConsoleColor.White, ConsoleColor.DarkGreen);
            _ui.DrowButton(nextButton);

            btnEvents.AddButton(button);
            btnEvents.AddButton(button2);
            btnEvents.AddButton(button3);
            btnEvents.AddButton(button4);
            btnEvents.AddButton(nextButton);
            btnEvents.Previous();
            btnEvents.Next();
            _ui.Refresh();

            
            do
            {
                if (input.IsKeyDown(KeyCode.Enter))
                {                  
                    btnEvents.Previous();
                    _ui.Refresh();
                }else  if (input.IsKeyDown(KeyCode.Up))
                {
                    btnEvents.Previous();
                    _ui.Refresh();
                  
                }else if (input.IsKeyDown(KeyCode.Down))
                {
                    btnEvents.Next();
                   
                    _ui.Refresh();              
                }
               
            } while (true);

        }
    }
}
