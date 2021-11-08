using Sources.Model;
using Sources.View;
using UnityEngine;

namespace Sources.Setup
{
    public class ClickerSetup
    {
        public void Setup(ClickerView view, Camera camera)
        {
            var model = new ClickerModel();

            view.Init(model, camera);
        }
    }
}