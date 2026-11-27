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

    public Scene()
    {

    }

    public void Update(double dt)
    {
        foreach (var entity in _entities)
        {
            entity.Update(dt);
        }

        CollisionCheck();

        _entities.RemoveAll(entity => entity.IsDead);
        // add logic down here to randomly spawn powerups every 15-30 seconds
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
        _entities.Add(entity);

        if (entity is not Enemy enemy) return; // creates a usable `enemy` variable if the entity being added *is* an enemy
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
        foreach (var possiblePlayer in _entities)
        {
            if (possiblePlayer is Player player)
            {
                player.OnWindowResize(window);
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
            }
        }
    }
}