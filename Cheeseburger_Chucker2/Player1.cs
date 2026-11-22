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
        private Vector2 Position;
        private Vector2 Velocity;
        private readonly string PlayerTexture = "newJaspser";

        public void Move(Controller controller, double dt)
        {
            if (controller.ReadMoveInput(Keys.D)) { Velocity.X = 300f * (float)dt; }
            if (controller.ReadMoveInput(Keys.A)) { Velocity.X = -300f * (float)dt; }

            if (controller.ReadMoveInput(Keys.S)) { Velocity.Y = 300f * (float)dt; }
            if (controller.ReadMoveInput(Keys.W)) { Velocity.Y = -300f * (float)dt; }

            if (!controller.ReadMoveInput(Keys.D) && !controller.ReadMoveInput(Keys.A)) { Velocity.X = 0; }
            if (!controller.ReadMoveInput(Keys.S) && !controller.ReadMoveInput(Keys.W)) { Velocity.Y = 0; }

            if (Velocity != Vector2.Zero)
            {
                Vector2.Normalize(Velocity);
            }

            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
        }

        public void Draw(SpriteBatch _spriteBatch, AssetManager assetManager)
        {
            Texture2D texture = assetManager.GetTexture(PlayerTexture);
            _spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
