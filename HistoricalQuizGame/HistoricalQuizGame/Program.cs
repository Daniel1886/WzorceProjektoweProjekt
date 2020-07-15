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
            DataManager dataManger = DataManager.GetInstance();
            GameManager gameManager = GameManager.GetInstance();

            gameManager.SetQuestions(dataManger.GetData());

            Stopwatch timer = new Stopwatch();
            timer.Start();

            UI _ui = new UI(75, 25);
            ButtonsEvents btnEvents = new ButtonsEvents(_ui);
            _ui.InitWindow();
            _ui.DrowWindow();

            Label question = new Label("", new Vector2Int(2, 2));
            _ui.DrowLabel(question);           
            
            Button button = new Button("", new Vector2Int(4, 6),ButtonTag.Answer);
            button.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            button.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            button.SetSelectColors(ConsoleColor.Cyan, ConsoleColor.Black, ConsoleColor.DarkCyan);
          
            Button button2 = new Button("", new Vector2Int(4, 10), ButtonTag.Answer);
            button2.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            button2.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            button2.SetSelectColors(ConsoleColor.Cyan, ConsoleColor.Black, ConsoleColor.DarkCyan);
            
            Button button3 = new Button("", new Vector2Int(4, 14), ButtonTag.Answer);
            button3.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            button3.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            button3.SetSelectColors(ConsoleColor.Cyan, ConsoleColor.Black, ConsoleColor.DarkCyan);
          
            Button button4 = new Button("", new Vector2Int(4, 18), ButtonTag.Answer);
            button4.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            button4.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            button4.SetSelectColors(ConsoleColor.Cyan, ConsoleColor.Black, ConsoleColor.DarkCyan);
           
            Button[] buttons = { button, button2, button3, button4 };

            Button nextButton = new Button(" Następne(N/n) ", new Vector2Int(58, 22), ButtonTag.Next);
            nextButton.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            nextButton.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            nextButton.SetSelectColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);


            Button startButton = new Button(" Rozpocznij ", new Vector2Int(32, 11), ButtonTag.Start);
            startButton.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            startButton.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            startButton.SetSelectColors(ConsoleColor.Cyan, ConsoleColor.Black, ConsoleColor.DarkCyan);
            Label about = new Label("    W grze poruszaj się używając strzałka do góry, na dół oraz                                ennter do zatwierdzania", new Vector2Int(2, 2));


            Button restartButton = new Button(" Spróbuj jescze raz ", new Vector2Int(32, 11), ButtonTag.Restart);
            restartButton.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            restartButton.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            restartButton.SetSelectColors(ConsoleColor.Cyan, ConsoleColor.Black, ConsoleColor.DarkCyan);

            Button endButton = new Button("       Koniec       ", new Vector2Int(32, 16), ButtonTag.Koniec);
            endButton.SetColors(ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.DarkBlue);
            endButton.SetFocusColors(ConsoleColor.Green, ConsoleColor.Black, ConsoleColor.DarkGreen);
            endButton.SetSelectColors(ConsoleColor.Cyan, ConsoleColor.Black, ConsoleColor.DarkCyan);
            Label endLabel = new Label("Twój wynik to :", new Vector2Int(2, 2));

            btnEvents.AddButton(nextButton);
            btnEvents.Previous();
            btnEvents.Next();

            button.Subscribe(gameManager);
            button2.Subscribe(gameManager);
            button3.Subscribe(gameManager);
            button4.Subscribe(gameManager);
            nextButton.Subscribe(gameManager);
            startButton.Subscribe(gameManager);
            restartButton.Subscribe(gameManager);
            endButton.Subscribe(gameManager);

            _ui.Refresh();

            
            do
            {
                if (gameManager.refresh)
                {
                    switch (gameManager.acutalView)
                    {
                        case ViewType.Start:
                            btnEvents.Clear();
                            btnEvents.AddButton(startButton);                       
                            _ui.InitWindow();
                            _ui.DrowWindow();

                            _ui.DrowLabel(about);
                            _ui.DrowButton(startButton);
                            btnEvents.SelectBtn(0);
                            btnEvents.FocusBtn(0);
                            _ui.Refresh();
                            gameManager.refresh = false;
                            break;
                        case ViewType.Game:
                            btnEvents.Clear();
                            btnEvents.AddButton(button);
                            btnEvents.AddButton(button2);
                            btnEvents.AddButton(button3);
                            btnEvents.AddButton(button4);
                            btnEvents.AddButton(nextButton);
                            var q = gameManager.GetCurrentQuestion();
                            btnEvents.SelectBtn(0);
                            btnEvents.FocusBtn(0);

                            _ui.InitWindow();
                            _ui.DrowWindow();

                            question.text = q.title;
                            _ui.DrowLabel(question);

                            int index = 0;
                            foreach (var a in q.answers)
                            {
                                buttons[index].text = a.title;
                                _ui.DrowButton(buttons[index]);
                                index += 1;
                            }
                            _ui.DrowButton(nextButton);
                            _ui.Refresh();
                            gameManager.refresh = false;
                            break;
                        case ViewType.End:
                            btnEvents.Clear();
                            btnEvents.AddButton(restartButton);
                            btnEvents.SelectBtn(0);
                            btnEvents.FocusBtn(0);
                            btnEvents.AddButton(endButton);
                            endLabel.text = "Twój wynik to : " + gameManager.GetPointsString();
                            _ui.InitWindow();
                            _ui.DrowWindow();

                            _ui.DrowLabel(endLabel);
                            _ui.DrowButton(restartButton);
                            _ui.DrowButton(endButton);

                            _ui.Refresh();
                            gameManager.refresh = false;
                            break;
                    }
                  
                }
                if (input.IsKeyDown(KeyCode.Enter))
                {
                    btnEvents.SelectCurrentBtn();
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
               
            } while (!gameManager.end);

        }
    }
}
