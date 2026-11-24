using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cheeseburger_Chucker2
{ 
    internal class Game1 : Game
    {
        private readonly GraphicsDeviceManager _GDM;

        private readonly Controller _controller;

        private readonly AssetManager _assetManager;

        private readonly Player1 _player;

        private readonly FPS_Handler _fpsManager;

        private SpriteBatch _spriteBatch = null!;

        public Game1()
        {
            _GDM = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1280,
                PreferredBackBufferHeight = 720,
                IsFullScreen = false,
                SynchronizeWithVerticalRetrace = false,
            };

            IsFixedTimeStep = false;

            _assetManager = new();
            _controller = new();
            _player = new();
            _fpsManager = new();
        }



        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _assetManager.LoadTextures(GraphicsDevice);

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            _spriteBatch.Dispose();
            _assetManager.UnloadTextures();

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            double dt = gameTime.ElapsedGameTime.TotalSeconds;

            _player.Move(_controller, dt);

            _fpsManager.WriteFPS(dt);
    
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _player.Draw(_spriteBatch, _assetManager);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
