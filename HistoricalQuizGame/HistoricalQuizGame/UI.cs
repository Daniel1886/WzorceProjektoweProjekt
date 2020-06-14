using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public class UI
    {
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }

        private char[,] matrix;
        public UI(int windowWidth,int windowHeight)
        {
            this.WindowHeight = windowHeight;
            this.WindowWidth = windowWidth;
            matrix = new char[this.WindowWidth, this.WindowHeight];            
        }
        public void InitWindow()
        {
            for (int y = 0; y < WindowHeight; y++)
            {
                for (int x = 0; x < WindowWidth; x++)
                {
                    matrix[x, y] = ' ';
                }
            }
        }
        public void Refresh()
        {
            Console.Clear();
            for (int y = 0; y < WindowHeight; y++)
            {
                for (int x = 0; x < WindowWidth; x++)
                {
                    Console.Write(matrix[x, y]);
                }
                Console.Write("\n");
            }
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
                    
                    matrix[lineRange, lines] = t[i];
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
                
                matrix[lineRange - 1, lines -1] = '|';
                matrix[lineRange -1 , lines] = '|';
                matrix[lineRange - 1, lines + 1] = '|';

                for (int i = 0; i < t.Length; i++)
                {

                    matrix[lineRange , lines - 1] = '=';
                    matrix[lineRange , lines] = t[i];
                    matrix[lineRange, lines + 1] = '=';                 

                    lineRange += 1;
                    if (lineRange >= WindowWidth)
                        break;
                                    
                }
                matrix[lineRange , lines - 1] = '|';
                matrix[lineRange, lines] = '|';
                matrix[lineRange , lines + 1] = '|';



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
                        matrix[x, y] = '=';
                    }
                    if (y == WindowHeight - 1 )
                    {
                        matrix[x, y] = '=';
                    }
                    if(x == 0)
                    {
                        matrix[x, y] = '|';
                        
                    }
                    if (x == WindowWidth - 1)
                    {
                        matrix[x, y] = '|';
                    }
                    Console.Write(matrix[x, y]);

                }
                Console.Write("\n");
            }
        }
    }
}
