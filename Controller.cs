using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cheeseburger_Chucker2
{
    internal class Controller
    {
        private KeyboardState _keyboardPrev = new();

        public bool ReadMoveInput(Keys key)
        {
            KeyboardState keyboardCur = Keyboard.GetState();

            if (keyboardCur.IsKeyDown(key))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
