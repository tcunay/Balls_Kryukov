using UnityEngine;
using Sources.Abstract;
using Sources.Libraries;
using Sources.Model;
using Sources.View;

namespace Sources.Setup
{
    public class BallSetup
    {
        public BallSetup(BallView view, IElapsedTimeCounter timer, ColorsLibrary color, Vector2 position)
        {
            int reward = Random.Range(0, 10);
            int damage = Random.Range(0, 10);
            float speed = Random.Range(0.5f, 2f);
            
            var model = new BallModel(color.GetRandom(), reward, damage);
            var movement = new BallMovement(timer, position, speed);

            view.Init(model, movement);
        }
    }
}