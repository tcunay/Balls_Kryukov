using System;
using Sources.Abstract;

namespace Sources.Model
{
    public class ClickerModel: IClicker
    {
        public event Action Killed;
        
        public void Click(IClickable clickable)
        {
            clickable.Damageable.Died += ReportKill;
            clickable.Damageable.TakeDamage();
            clickable.Damageable.Died -= ReportKill;
        }

        private void ReportKill()
        {
            Killed?.Invoke();
        }
    }
}