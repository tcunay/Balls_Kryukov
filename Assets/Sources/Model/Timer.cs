using System.Collections;
using Sources.Abstract;

namespace Sources.Model
{
    public class Timer : IUpdateable
    {
        public float ElapsedTime { get; private set; }

        public void Update(float deltaTime)
        {
            ElapsedTime += deltaTime;
        }
    }
}