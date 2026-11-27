using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;

namespace Cheeseburger_Chucker2.src;

internal class Player : Character
{
    public override string Tag => "player";
    protected override float _movementSpeed => 150;
    public override int MaxHealth => 100;

    private readonly Controller _controller;
    private Rectangle _window;

    private string _facing;

    public Player(AssetManager assetManager, Controller controller, Rectangle window)
    {
        _controller = controller;
        _window = window;

        Health = MaxHealth;
        Width = assetManager.GetTextureWidth(Tag);
        Height = assetManager.GetTextureHeight(Tag);
    }

    public override void Update(double dt)
    {
        ProcessInput(_controller, dt);
        CheckBounds(_window);
        UpdateEffects(dt);
    }

    public void OnWindowResize(Rectangle window)
    {
        _window = window;
    }

    private void CheckBounds(Rectangle window)
    {
        float x = MathHelper.Clamp(Position.X, 0, window.Width - Width);
        float y = MathHelper.Clamp(Position.Y, 0, window.Height - Height);
        Position = new Vector2(x, y);
    }

    private void ProcessInput(Controller controller, double dt)
    {
        Vector2 direction = Vector2.Zero;

        if (controller.ReadMoveInput(Keys.D))
        {
            direction.X = 1;
            _facing = "RIGHT";
        }
        if (controller.ReadMoveInput(Keys.A))
        {
            direction.X = -1;
            _facing = "LEFT";
        }
        if (controller.ReadMoveInput(Keys.S)) {
            direction.Y = 1;
        }
        if (controller.ReadMoveInput(Keys.W)) {
            direction.Y = -1;
        }

        if (direction == Vector2.Zero) return;

        float speedMultiplier = 1;
        if (HasEffect(StatusEffect.Speedboost)) speedMultiplier = 2;
        Position += direction * _movementSpeed * (float)dt * speedMultiplier;

        if (_facing == "LEFT")
        {
            _flippedHorizontally = true;
        }
        else if (_facing == "RIGHT")
        {
            _flippedHorizontally = false;
        }


        if (controller.ReadMoveInput(Keys.Space))
        {
            // do weapon stuff
        }
    }
}