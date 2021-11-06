using Sources.Libraries;
using Sources.Model;
using Sources.View;
using UnityEngine;

namespace Sources.Setup
{
    public class BallSetup
    {
        public BallSetup(BallView view, Timer timer, ColorsLibrary color)
        {
            int reward = Random.Range(0, 10);
            int damage = Random.Range(0, 10);
            float speed = Random.Range(0.5f, 2f);
            
            var model = new BallModel(color.GetRandom(), reward, damage);
            var movement = new BallMovement(speed, timer, view.transform.position);

            view.Init(model, movement);
        }
    }
}