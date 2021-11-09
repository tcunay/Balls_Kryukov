using System;
using System.Collections;
using UnityEngine;
using Sources.Abstract;

namespace Sources.Model
{
    public class Timer : IUpdateable, IElapsedTimeCounter
    {
        public event Action Tick;
        public float ElapsedTime { get; private set; }

        public void Update(float deltaTime)
        {
            ElapsedTime += deltaTime;
        }

        public IEnumerator SetTickInterval(int interval)
        {
            while (true)
            {
                Tick?.Invoke();
                yield return new WaitForSeconds(interval);
            }
        }
    }
}