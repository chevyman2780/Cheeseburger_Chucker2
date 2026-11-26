using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;

namespace Cheeseburger_Chucker2.src;

internal class Player
{
    private Vector2 _Position;
    private Vector2 _Direction;

    private readonly float _playerSpeed = 300f;

    private string _facing;

    private readonly string _playerTextureName = "player";
    private Texture2D _playerTexture;
    private readonly int _playerWidth;
    private readonly int _playerHeight;

    private Weapon _playerWeapon;

    public Player(AssetManager _assetManager)
    {
        _playerTexture = _assetManager.GetTexture(_playerTextureName);

        _playerWidth = _playerTexture.Width;
        _playerHeight = _playerTexture.Height;

        _playerWeapon = new(_assetManager, "burger");
    }

    private void CheckBounds(int _windowWidth, int _windowHeight)
    {
        if (_Position.X + _playerWidth > _windowWidth)
        {
            _Position.X = _windowWidth - _playerWidth;
        } else if (_Position.X < 0)
        {
            _Position.X = 0;
        }

        if (_Position.Y + _playerHeight > _windowHeight)
        {
            _Position.Y = _windowHeight - _playerHeight;
        } else if (_Position.Y < 0)
        {
            _Position.Y = 0;
        }
    }

    private void Move(Controller _controller, double dt)
    {
        _Direction = Vector2.Zero;

        if (_controller.ReadMoveInput(Keys.D))
        {
            _Direction.X = 1;
            _facing = "RIGHT";
        }
        if (_controller.ReadMoveInput(Keys.A))
        {
            _Direction.X = -1;
            _facing = "LEFT";
        }
        if (_controller.ReadMoveInput(Keys.S)) { _Direction.Y = 1; }
        if (_controller.ReadMoveInput(Keys.W)) { _Direction.Y = -1; }

        if (_Direction != Vector2.Zero)
        {
            _Direction = Vector2.Normalize(_Direction);
        }

        _Position.X += _Direction.X * _playerSpeed * (float)dt;
        _Position.Y += _Direction.Y * _playerSpeed * (float)dt;
    }

    public void Update(Controller _controller, double dt, int _windowWidth, int _windowHeight, AssetManager _assetManager)
    {
        Move(_controller, dt);
        CheckBounds(_windowWidth, _windowHeight);

        _playerWeapon.EquippedWeapon(_controller, _assetManager, "burger", _Position, _Direction, dt, _facing);
    }

    public void Draw(AssetManager _assetManager)
    {
        _assetManager.batch.Draw(_playerTexture, _Position, Color.White);
        _playerWeapon.Draw_Weapon(_assetManager);
    }
}