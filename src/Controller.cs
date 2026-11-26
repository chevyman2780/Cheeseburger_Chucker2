using Microsoft.Xna.Framework.Input;

namespace Cheeseburger_Chucker2.src;

internal class Controller
{
    private KeyboardState _keyboardPrev = Keyboard.GetState();
    public bool ReadMoveInput(Keys key)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(key))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public bool ReadInput(Keys key)
    {
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(key) && _keyboardPrev.IsKeyUp(key))
        {
            _keyboardPrev = keyboardState;
            return true;
        } else
        {
            _keyboardPrev = keyboardState;
            return false;
        }
    }
}