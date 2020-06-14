using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public class UI
    {
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }

        private MatrixNode[,] matrix;
        public UI(int windowWidth,int windowHeight)
        {
            this.WindowHeight = windowHeight;
            this.WindowWidth = windowWidth;
            matrix = new MatrixNode[this.WindowWidth, this.WindowHeight];            
        }
        public void InitWindow()
        {
            for (int y = 0; y < WindowHeight; y++)
            {
                for (int x = 0; x < WindowWidth; x++)
                {
                    matrix[x, y] = new MatrixNode(' ');
                }
            }
        }
        public void Refresh()
        {
            Console.Clear();
            Console.ResetColor();
            for (int y = 0; y < WindowHeight; y++)
            {
                for (int x = 0; x < WindowWidth; x++)
                {
                    Console.ForegroundColor = matrix[x, y].textColor;
                    Console.BackgroundColor = matrix[x, y].backgroundColor;
                    Console.Write(matrix[x, y].sign);
                }
                Console.Write("\n");
            }
            Console.ResetColor();
        }
        public void DrowWindow()
        {
            DrowMainWindowFrame();
        }

        public void DrowLabel(Label label)
        {
            string t = label.text;
            Vector2Int p = label.position;
            int lineRange = p.x;
            int lines = p.y;
            if (p.x >= 1 && p.x < WindowWidth -1 && p.y >= 1 && p.y < WindowHeight - 1 )
            {
                for(int i = 0; i < t.Length; i++)
                {
                    
                    matrix[lineRange, lines].sign = t[i];
                    lineRange += 1;
                    if(lineRange >= WindowWidth -1 )
                    {
                        lines += 1;
                        if(lines >= WindowHeight -1 )
                        {
                            break;
                        }
                        lineRange = p.x;
                    }
                }                
            }
        }
        public void DrowButton(Button button)
        {
            string t = button.text;
            Vector2Int p = button.position;
            int lineRange = p.x;
            int lines = p.y;
            if (p.x >= 1 && p.x < WindowWidth - 1 && p.y >= 1 && p.y < WindowHeight - 1)
            {
                
                matrix[lineRange - 1, lines -1].sign = ' ';
                matrix[lineRange - 1, lines - 1].backgroundColor = button.borderColor;

                matrix[lineRange -1 , lines].sign = ' ';
                matrix[lineRange - 1, lines].backgroundColor = button.borderColor;

                matrix[lineRange - 1, lines + 1].sign = ' ';
                matrix[lineRange - 1, lines + 1].backgroundColor = button.borderColor;

                for (int i = 0; i < t.Length; i++)
                {

                    matrix[lineRange , lines - 1].sign = ' ';
                    matrix[lineRange, lines - 1].backgroundColor = button.borderColor;

                    matrix[lineRange , lines].sign = t[i];
                    matrix[lineRange, lines].textColor = button.textColor;
                    matrix[lineRange, lines].backgroundColor = button.backgroundColor;


                    matrix[lineRange, lines + 1].sign = ' ';
                    matrix[lineRange, lines + 1].backgroundColor = button.borderColor;

                    lineRange += 1;
                    if (lineRange >= WindowWidth)
                        break;
                                    
                }
                matrix[lineRange , lines - 1].sign = ' ';
                matrix[lineRange, lines - 1].backgroundColor = button.borderColor;

                matrix[lineRange, lines].sign = ' ';
                matrix[lineRange, lines].backgroundColor = button.borderColor;

                matrix[lineRange , lines + 1].sign = ' ';
                matrix[lineRange, lines + 1].backgroundColor = button.borderColor;



            }
        }
        private void DrowMainWindowFrame()
        {
            for (int y = 0; y < WindowHeight; y++)
            {
                for (int x = 0; x < WindowWidth; x++)
                {
                    if (y == 0)
                    {
                        matrix[x, y].sign = ' ';
                        matrix[x, y].backgroundColor = ConsoleColor.DarkYellow;
                    }
                    if (y == WindowHeight - 1 )
                    {
                        matrix[x, y].sign = ' ';
                        matrix[x, y].backgroundColor = ConsoleColor.DarkYellow;
                    }
                    if(x == 0)
                    {
                        matrix[x, y].sign = ' ';
                        matrix[x, y].backgroundColor = ConsoleColor.DarkYellow;

                    }
                    if (x == WindowWidth - 1)
                    {
                        matrix[x, y].sign = ' ';
                        matrix[x, y].backgroundColor = ConsoleColor.DarkYellow;
                    }
                   
                }              
            }
        }
    }
}
