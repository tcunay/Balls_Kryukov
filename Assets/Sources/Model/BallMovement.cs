using System;
using Sources.Abstract;
using UnityEngine;

namespace Sources.Model
{
    public class BallMovement : IMoveable
    {
        private readonly IElapsedTimeCounter _timer;

        public BallMovement(IElapsedTimeCounter timer, Vector2 position, float initableSpeed)
        {
            Validator.Validate(initableSpeed < 0, timer == null);
            
            _timer = timer;
            Position = position;
            InitableSpeed = initableSpeed;
        }

        public float InitableSpeed { get; }
        public float CurrentSpeed { get; private set; }
        public float SpeedBooster => (float) Math.Sqrt(_timer.ElapsedTime);
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