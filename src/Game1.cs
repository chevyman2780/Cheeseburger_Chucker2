using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cheeseburger_Chucker2.src;

internal class Game1 : Game
{
    private readonly GraphicsDeviceManager _GDM;

    private AssetManager _assetManager;

    private Controller _controller;

    private Player _player1;

    public Game1()
    {
        _GDM = new(this)
        {
            PreferredBackBufferWidth = 1280,
            PreferredBackBufferHeight = 720,
            IsFullScreen = false,
            SynchronizeWithVerticalRetrace = true
        };
    }

    protected override void Initialize()
    {
        _assetManager = new();

        _controller = new();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _assetManager.LoadTextures(GraphicsDevice);

        _player1 = new(_assetManager);
        
        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        double dt = gameTime.ElapsedGameTime.TotalSeconds;

        _player1.Update(_controller, dt, Window.ClientBounds.Width, Window.ClientBounds.Height);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _assetManager.batch.Begin();

        _player1.Draw(_assetManager);

        _assetManager.batch.End();
        
        base.Draw(gameTime);
    }
}