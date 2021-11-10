using System;
using UnityEngine;
using Sources.Abstract;

namespace Sources.Model
{
    public class Health : Damageable, IHeatlhValue
    {
        public Health(int value)
        {
            Value = value;
        }
        
        public event Action ValueChanged;
        public int Value { get; private set; }

        public override void TakeDamage(int damage = 0)
        {
            Validator.Validate(damage < 0);

            Value -= damage;
            if (Value <= 0)
            {
                Value = 0;
                Die();
            }

            ValueChanged?.Invoke();
            Debug.Log(Value);

            Validator.Validate(Value < 0);
        }
    }
}