using System;
using System.Collections.Generic;
using System.Text;

namespace HistoricalQuizGame
{
    internal enum KeyCode : int
    {
        Enter = 0x0D,
        Left = 0x25,
        Up = 0x26,
        Down = 0x28       
    }
    internal class InputManager
    {
        private InputManager() { }
        private static InputManager _instance;
        public static InputManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InputManager();
            }
            return _instance;
        }
        private const int KeyPressed = 0x8000;
        private bool isKeyPressed = false;

        public bool IsKeyDown(KeyCode key)
        {     
            
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }
        public bool IsKeyUp(KeyCode key)
        {          
            if (IsKeyDown(key))
            {            
                isKeyPressed = true;
            }else if (isKeyPressed)
            {
               
                isKeyPressed = false;
                return true;
            }                  
            return false;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    }
}
