using System;
using UnityEngine;

namespace Sources.Model
{
    public class BallModel : IDamage, IMooveable, IDestroyable
    {
        public Color Color { get; private set; }
        public float Speed { get; private set; }
        public int Reward { get; private set; }
        public int Damage { get; private set; }

        public event Action Destoyed;

        public void Move()
        {
            throw new System.NotImplementedException();
        }

        public void Destroy()
        {
            Destoyed?.Invoke();
        }
    }

    public interface IDamage
    {
        public int Damage { get; }
    }

    public interface IMooveable
    {
        public float Speed { get; }

        void Move();
    }

    public interface IDestroyable
    {
        event Action Destoyed;

        void Destroy();
    }
}

