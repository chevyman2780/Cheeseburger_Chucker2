using Microsoft.Xna.Framework.Input;

namespace Cheeseburger_Chucker2.src;

internal class Controller
{
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
}