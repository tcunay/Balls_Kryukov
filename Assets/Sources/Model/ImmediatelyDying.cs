namespace Sources.Model
{
    public class ImmediatelyDying : Damageable
    {
        public override void TakeDamage(int damage)
        {
            Die();
        }
    }
}