using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cheeseburger_Chucker2.src;

internal class Game1 : Game
{
    private readonly GraphicsDeviceManager _GDM;

    private readonly AssetManager _assetManager;

    public Game1()
    {
        _GDM = new(this)
        {
            PreferredBackBufferWidth = 1280,
            PreferredBackBufferHeight = 720,
            IsFullScreen = false,
            SynchronizeWithVerticalRetrace = true
        };

        _assetManager = new();
    }
    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _assetManager.LoadTextures(GraphicsDevice);
        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _assetManager.batch.Begin();
        _assetManager.batch.Draw(_assetManager.GetTexture("player"), Vector2.Zero, Color.White);
        _assetManager.batch.End();
        base.Draw(gameTime);
    }
}