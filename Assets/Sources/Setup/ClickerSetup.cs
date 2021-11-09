using UnityEngine;
using Sources.Abstract;
using Sources.Model;
using Sources.View;

namespace Sources.Setup
{
    public class ClickerSetup
    {
        public void Setup(ClickerView view, Camera camera, IScoreable scoreable)
        {
            var model = new ClickerModel(scoreable);

            view.Init(model, camera);
        }
    }
}