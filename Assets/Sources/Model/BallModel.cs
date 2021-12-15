using System;
using UnityEngine;
using Sources.Abstract;

namespace Sources.Model
{
    public class BallModel : IClickable, IDamage
    {
        public BallModel(Damageable damageable, Color color, int reward, int damage)
        {
            Validator.Validate(color == default, reward < 0, damage < 0);

            Damageable = damageable;
            Color = color;
            Reward = reward;
            Damage = damage;
        }
        public Damageable Damageable { get; private set; }
        public Color Color { get; private set; }
        public int Reward { get; private set; }
        public int Damage { get; private set; }
        
        public void ApplyDamage(Damageable damageable)
        {
            damageable.TakeDamage(Damage);
            Damageable.TakeDamage(0);
        }
    }
}