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

    private TankEnemy _tankEnemy; // enemy test, delete later

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
        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnClientSizeChanged; // subscribe to window resize event

        base.Initialize();
    }

    private void OnClientSizeChanged(object sender, EventArgs e)
    {
        int newWidth = Window.ClientBounds.Width;
        int newHeight = Window.ClientBounds.Height;
        if (newWidth == 0 || newHeight == 0) return;

        _GDM.PreferredBackBufferWidth = newWidth;
        _GDM.PreferredBackBufferHeight = newHeight;
        _GDM.ApplyChanges();
    }

    protected override void LoadContent()
    {
        _assetManager.LoadTextures(GraphicsDevice);

        _player1 = new(_assetManager);

        _tankEnemy = new(); // enemy test, delete later
        _tankEnemy.Initialize(_assetManager); // enemy test, delete later

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

        _tankEnemy.Update(_player1.GetPosition(), dt); // enemy test, delete later

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _assetManager.batch.Begin();

        _player1.Draw(_assetManager);

        _tankEnemy.Draw(_assetManager); // enemy test, delete later

        _assetManager.batch.End();
        
        base.Draw(gameTime);
    }
}