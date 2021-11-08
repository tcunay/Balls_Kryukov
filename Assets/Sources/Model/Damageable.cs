using System;

namespace Sources.Model
{
    public abstract class Damageable
    {
        public event Action Died;

        public abstract void TakeDamage(int damage = 0);

        protected void Die()
        {
            Died?.Invoke();
        }
    }
}