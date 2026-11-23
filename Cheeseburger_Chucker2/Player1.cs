using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cheeseburger_Chucker2
{
    internal class Player1
    {
        private Vector2 _Position;
        private Vector2 _Velocity;
        private readonly string _playerTexture = "newJaspser";

        private readonly float _playerSpeed = 300f;

        public void Move(Controller controller, double dt)
        {
            if (controller.ReadMoveInput(Keys.D)) { _Velocity.X = 1; }
            if (controller.ReadMoveInput(Keys.A)) { _Velocity.X = -1; }

            if (controller.ReadMoveInput(Keys.S)) { _Velocity.Y = 1; }
            if (controller.ReadMoveInput(Keys.W)) { _Velocity.Y = -1; }

            if (!controller.ReadMoveInput(Keys.D) && !controller.ReadMoveInput(Keys.A)) { _Velocity.X = 0; }
            if (!controller.ReadMoveInput(Keys.S) && !controller.ReadMoveInput(Keys.W)) { _Velocity.Y = 0; }

            if (_Velocity != Vector2.Zero)
            {
                _Velocity = Vector2.Normalize(_Velocity);
            }

            _Position.X += _Velocity.X * _playerSpeed * (float)dt;
            _Position.Y += _Velocity.Y * _playerSpeed * (float)dt;
        }

        public void Draw(SpriteBatch _spriteBatch, AssetManager assetManager)
        {
            Texture2D texture = assetManager.GetTexture(_playerTexture);
            _spriteBatch.Draw(texture, _Position, Color.White);
        }
    }
}
