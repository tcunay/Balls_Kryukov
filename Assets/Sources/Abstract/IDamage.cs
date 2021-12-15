using Sources.Model;

namespace Sources.Abstract
{
    public interface IDamage
    {
        public int Damage { get; }

        void ApplyDamage(Damageable damageable);
    }
}