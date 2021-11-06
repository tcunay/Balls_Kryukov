using System;
using UnityEngine;
using Sources.Abstract;

namespace Sources.Model
{
    public class BallModel : IDamage, IDestroyable
    {
        public BallModel(Color color, int reward, int damage)
        {
            Validator.Validate(color == default, reward < 0, damage < 0);

            Color = color;
            Reward = reward;
            Damage = damage;
        }

        public Color Color { get; private set; }
        public int Reward { get; private set; }
        public int Damage { get; private set; }

        public event Action Destoyed;

        public void OnClick()
        {
            Destroy();
        }

        private void Destroy()
        {
            Destoyed?.Invoke();
        }
    }
}