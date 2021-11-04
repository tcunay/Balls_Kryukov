using System;
using UnityEngine;
using Sources.Abstract;

namespace Sources.Model
{
    public class BallModel : IDamage, IDestroyable
    {
        public BallModel(Color color, int reward, int damage)
        {
            Color = color;
            Reward = reward;
            Damage = damage;
        }

        public Color Color { get; private set; }
        public int Reward { get; private set; }
        public int Damage { get; private set; }

        public event Action Destoyed;

        public void Destroy()
        {
            Destoyed?.Invoke();
        }
    }
}

