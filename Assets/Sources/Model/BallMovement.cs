using System;
using Sources.Abstract;

namespace Sources.Model
{
    public class BallMovement : ISpeed, IUpdateable
    {
        private readonly Timer _timer;

        public BallMovement(float initableSpeed, Timer timer)
        {
            _timer = timer;
            InitableSpeed = initableSpeed;
        }

        public float InitableSpeed { get; }
        public float CurrentSpeed { get; private set; }
        public float SpeedBooster => _timer.ElapsedTime * 0.1f;

        public void Update(float deltaTime)
        {
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            CurrentSpeed = (InitableSpeed + SpeedBooster) * deltaTime;

            if (CurrentSpeed < 0)
                throw new InvalidOperationException(nameof(CurrentSpeed));
        }
    }
}