using System;
using System.Collections;
using Sources.Abstract;
using UnityEngine;

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