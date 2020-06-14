using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    public class UIElement
    {
        public Vector2Int position;

        public UIElement()
        {
            this.position = new Vector2Int(0, 0);
        }
        public UIElement(Vector2Int position)
        {
            this.position = position;
        }
    }
}
