using System;
using Sources.Abstract;

namespace Sources.Model
{
    public class PlayerModel : IModel, IScoreable
    {
        public PlayerModel(Damageable damageable)
        {
            Score = 0;
            Damageable = damageable;
        } 
        
        public event Action ScoreChanged;
        
        public Damageable Damageable { get; }
        public int Score { get; private set; }
        
        public void Add(int score)
        {
            Validator.Validate(score < 0);

            Score += score;
            ScoreChanged?.Invoke();
        }
    }
}