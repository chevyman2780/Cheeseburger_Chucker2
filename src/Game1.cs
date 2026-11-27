using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cheeseburger_Chucker2.src;

internal class Game1 : Game
{
    private readonly GraphicsDeviceManager _GDM; // why not _graphicsDeviceManager?
    private AssetManager _assetManager; // why not _AM?
    private Controller _controller;
    private Scene _scene;

    // private Player _player;

    // private TankEnemy _tankEnemy; // enemy test, delete later

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
        _scene = new();

        Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnClientSizeChanged; // subscribe to window resize event

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _assetManager.LoadTextures(GraphicsDevice, "textures");
        Rectangle window = Window.ClientBounds;
        // initial load start

        _scene.AddEntity(new Player(_assetManager, _controller, window));

        TankEnemy tankEnemy1 = new();
        TankEnemy tankEnemy2 = new();
        TankEnemy tankEnemy3 = new();

        tankEnemy1.SetPosition(new Vector2(100, 100));
        tankEnemy2.SetPosition(new Vector2(400, 200));
        tankEnemy3.SetPosition(new Vector2(200, 300));

        _scene.AddEntity(tankEnemy1);
        _scene.AddEntity(tankEnemy2);
        _scene.AddEntity(tankEnemy3);

        Speedboost speedboost = new(_assetManager);

        speedboost.SetPosition(new Vector2(500, 500));

        _scene.AddEntity(speedboost);

        // initial load end
        base.LoadContent();
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        double dt = gameTime.ElapsedGameTime.TotalSeconds;
        // update start

        _scene.Update(dt);

        // update end
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _assetManager.batch.Begin();
        // drawing start

        _scene.Draw(_assetManager);

        // drawing end
        _assetManager.batch.End();
        base.Draw(gameTime);
    }

    private void OnClientSizeChanged(object sender, EventArgs e)
    {
        int newWidth = Window.ClientBounds.Width;
        int newHeight = Window.ClientBounds.Height;
        if (newWidth == 0 || newHeight == 0) return;

        _GDM.PreferredBackBufferWidth = newWidth;
        _GDM.PreferredBackBufferHeight = newHeight;
        _GDM.ApplyChanges();

        Rectangle window = Window.ClientBounds;
        _scene.OnWindowResize(window);
    }
}