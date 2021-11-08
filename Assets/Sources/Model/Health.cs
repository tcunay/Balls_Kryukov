using System;
using Sources.Abstract;

namespace Sources.Model
{
    public class Health : Damageable, IHeatlhValue
    {
        public event Action ValueChanged;
        public int Value { get; private set; }

        public override void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new InvalidOperationException(nameof(damage));

            Value -= damage;

            if (Value <= 0)
            {
                Value = 0;
                Die();
            }
            
            ValueChanged?.Invoke();

            if (Value < 0)
                throw new InvalidOperationException(nameof(Value));
        }
    }
}