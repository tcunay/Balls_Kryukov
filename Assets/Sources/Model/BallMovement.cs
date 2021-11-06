using System;
using Sources.Abstract;
using UnityEngine;

namespace Sources.Model
{
    public class BallMovement : IMoveable
    {
        private readonly Timer _timer;

        public BallMovement(float initableSpeed, Timer timer, Vector2 position)
        {
            Validator.Validate(initableSpeed < 0, timer == null);
            
            _timer = timer;
            Position = position;
            InitableSpeed = initableSpeed;
        }

        public float InitableSpeed { get; }
        public float CurrentSpeed { get; private set; }
        public float SpeedBooster => _timer.ElapsedTime * 1f;
        public Vector2 Position { get; private set; }
        public Vector2 Direction => Vector2.down;

        public void Update(float deltaTime)
        {
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            CurrentSpeed = (InitableSpeed + SpeedBooster) * deltaTime;

            if (CurrentSpeed < 0)
                throw new InvalidOperationException(nameof(CurrentSpeed));

            Position += Direction * CurrentSpeed;
        }
    }
}