using Sources.Abstract;
using UnityEngine.UIElements;

namespace Sources.Model
{
    public class BorderModel : IModel
    {
        private readonly Damageable _player;
        
        public BorderModel(Damageable damageable, Damageable player)
        {
            Validator.Validate(damageable == null, player == null);
            
            Damageable = damageable;
            _player = player;
        }
        
        public Damageable Damageable { get; }

        public void OnDamageCollision(IDamage ball)
        {
            _player.TakeDamage(ball.Damage);
        }
    }
}