using System.Runtime.CompilerServices;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Cheeseburger_Chucker2.src;

// i couldn't think of a better name, but Character
// will be the class for the player and enemies
internal abstract class Character : Entity
{
    protected abstract float _movementSpeed { get; } // abstract so that it won't compile if you forget to set _movementSpeed
    public abstract int MaxHealth { get; } // abstract so that it won't compile if you forget to set it
    public int Health { get; protected set; }

    private readonly Dictionary<StatusEffect, double> _effects = new();
    private readonly List<StatusEffect> _expiredEffects = new();

    public void AddEffect(StatusEffect effect, double duration)
    {
        // if already active, refresh to the longer of the two
        if (_effects.TryGetValue(effect, out double remainingDuration))
        {
            _effects[effect] = Math.Max(remainingDuration, duration);
        }
        else
        {
            _effects[effect] = duration;
        }
    }

    public bool HasEffect(StatusEffect effect) => _effects.ContainsKey(effect);
    public void RemoveEffect(StatusEffect effect) => _effects.Remove(effect);

    protected void UpdateEffects(double dt)
    {
        _expiredEffects.Clear();

        // check if duration is over
        foreach (var pair in _effects)
        {
            if (pair.Value - dt <= 0)
            {
                _expiredEffects.Add(pair.Key);
            }
        }

        // if not expired, subtract time from its duration
        foreach (var key in _effects.Keys.ToList())
        {
            if (!_expiredEffects.Contains(key))
            {
                _effects[key] -= dt;
            }
        }

        // if it is expired, remove it from the list
        foreach (var key in _expiredEffects)
        {
            _effects.Remove(key);
        }
    }
}