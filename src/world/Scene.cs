using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

internal class Scene
{
    // entities includes the player, enemies, projectiles, powerups, anything like that on screen
    private List<Entity> _entities = new List<Entity>();
    private readonly List<Entity> _pendingAdd = new List<Entity>(); // add a queue so that it doesn't add a new entity while still going through _entities list

    private AssetManager _assetManager;
    private Rectangle _window;

    private double _powerupTimer = 0; // how much longer until the next powerups are spawned in the scene


    public Scene(AssetManager assetManager)
    {
        _assetManager = assetManager;
    }

    public void Update(double dt)
    {
        foreach (var entity in _entities)
        {
            entity.Update(dt);

            // remove any entities that go off screen (primarily projectiles to stop lag)
            Rectangle cullComparisonRect = new Rectangle(0, 0, _window.Width, _window.Height); // remove X and Y coordinates from _window
            if (!entity.Rect.Intersects(cullComparisonRect))
            {
                entity.Kill();
            }
        }

        CollisionCheck();

        _entities.RemoveAll(entity => entity.IsDead);

        foreach (var e in _pendingAdd)
        {
            FinalizeAdd(e);
        }
        _pendingAdd.Clear();
        // add logic down here to randomly spawn powerups every 15-30 seconds

        if (_powerupTimer - dt < 0) _powerupTimer = 0;
        if (_powerupTimer - dt > 0) _powerupTimer = _powerupTimer - dt;
        if (_powerupTimer > 0) return;

        Speedboost speedboost = new(_assetManager);
        speedboost.SetPosition(new Vector2(500, 500));
        AddEntity(speedboost);

        Rapidfire rapidfire = new(_assetManager);
        rapidfire.SetPosition(new Vector2(600, 100));
        AddEntity(rapidfire);

        _powerupTimer = 10;
    }

    public void Draw(AssetManager assetManager)
    {
        // TO DO: order drawing so that powerups drawn first, then enemies, then player
        foreach (var entity in _entities)
        {
            entity.Draw(assetManager);
        }
    }

    public void AddEntity(Entity entity)
    {
        _pendingAdd.Add(entity);   // never touches _entities directly
    }

    private void FinalizeAdd(Entity entity)
    {
        _entities.Add(entity);

        if (entity is not Enemy enemy) return;
        foreach (var possiblePlayer in _entities)
        {
            if (possiblePlayer is Player player)
            {
                enemy.SetTarget(player);
            }
        }
    }

    // update entities that need window information whenever the window is resized
    public void OnWindowResize(Rectangle window)
    {
        _window = window;
        foreach (var possiblePlayer in _entities)
        {
            if (possiblePlayer is Player player)
            {
                player.OnWindowResize(_window);
            }
        }
    }

    public void CollisionCheck()
    {
        foreach (var firstEntity in _entities)
        {
            if (firstEntity.IsDead) continue; // skip to next loop if dead
            foreach (var secondEntity in _entities)
            {
                if (secondEntity.IsDead) continue; // skip to next loop if dead

                if (!firstEntity.Rect.Intersects(secondEntity.Rect)) continue; // skip if not colliding

                bool powerupPresent = (firstEntity is Powerup) || (secondEntity is Powerup);
                bool playerPresent = (firstEntity is Player) || (secondEntity is Player);
                bool enemyPresent = (firstEntity is Enemy) || (secondEntity is Enemy);
                bool projectilePresent = (firstEntity is Projectile) || (secondEntity is Projectile);

                if (playerPresent && powerupPresent)
                {
                    Powerup powerup = firstEntity as Powerup ?? secondEntity as Powerup;
                    Player player = firstEntity as Player ?? secondEntity as Player;

                    player.AddEffect(powerup.Effect, powerup.Duration);
                    powerup.Kill(); // delete powerup after effect is added to player
                }

                if (enemyPresent && projectilePresent)
                {
                    Projectile projectile = firstEntity as Projectile ?? secondEntity as Projectile;
                    Enemy enemy = firstEntity as Enemy ?? secondEntity as Enemy;

                    enemy.TakeDamage(projectile.Damage);
                    projectile.Kill();
                }
            }
        }
    }
}