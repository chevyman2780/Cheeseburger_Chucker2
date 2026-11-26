using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class Player
{
    private Vector2 _Position;
    private Vector2 _Direction;

    private readonly float _playerSpeed = 300f;

    private readonly string _playerTexture = "player";

    private void Move(Controller _controller, double dt)
    {
        _Direction = Vector2.Zero;
        
        if (_controller.ReadMoveInput(Keys.D)) { _Direction.X = 1; }
        if (_controller.ReadMoveInput(Keys.A)) { _Direction.X = -1; }
        if (_controller.ReadMoveInput(Keys.S)) { _Direction.Y = 1; }
        if (_controller.ReadMoveInput(Keys.W)) { _Direction.Y = -1; }

        if (_Direction != Vector2.Zero)
        {
            _Direction = Vector2.Normalize(_Direction);
        }

        _Position.X += _Direction.X * _playerSpeed * (float)dt;
        _Position.Y += _Direction.Y * _playerSpeed * (float)dt;
    }

    public void Update(Controller _controller, double dt)
    {
        Move(_controller, dt);
    }

    public void Draw(AssetManager _assetManager)
    {
        Texture2D texture = _assetManager.GetTexture(_playerTexture);

        _assetManager.batch.Draw(texture, _Position, Color.White);
    }
}