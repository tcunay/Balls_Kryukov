using System;
using Sources.Abstract;

namespace Sources.Model
{
    public class ClickerModel: IClicker
    {
        private readonly IScoreable _player;

        private IClickable _currentClickable;
        
        public event Action Killed;

        public ClickerModel(IScoreable player)
        {
            _player = player;
        }
        
        public void Click(IClickable clickable)
        {
            _currentClickable = clickable;
            _currentClickable.Damageable.Died += ReportKill;
            
            _currentClickable.Damageable.TakeDamage();
            
            _currentClickable.Damageable.Died -= ReportKill;
            _currentClickable = null;
        }

        private void ReportKill()
        {
            _player.Add(_currentClickable.Reward);
        }
    }
}