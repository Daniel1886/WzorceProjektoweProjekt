using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public class MatrixNode
    {
        public char sign;
        public ConsoleColor textColor;
        public ConsoleColor backgroundColor;

        public MatrixNode(char sign)
        {
            this.textColor = ConsoleColor.White;
            this.backgroundColor = ConsoleColor.Black;
            this.sign = sign;
        }
        public MatrixNode(ConsoleColor textColor, ConsoleColor backgroundColor,char sign)
        {
            this.textColor = textColor;
            this.backgroundColor = backgroundColor;
            this.sign = sign;
        }
    }
}
