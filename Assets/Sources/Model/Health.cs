using System;
using Sources.Abstract;

namespace Sources.Model
{
    public class Health : Damageable, IHeatlhValue
    {
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

            Validator.Validate(Value < 0);
        }
    }
}