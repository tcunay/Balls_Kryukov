using UnityEngine;
using Sources.Abstract;
using Sources.Model;

namespace Sources.View
{
    public class ClickerView : MonoBehaviour, IView
    {
        private ClickerModel _model;
        private Camera _camera;

        public IModel Model { get; private set; }

        public void Init(ClickerModel model, Camera camera)
        {
            _model = model;
            _camera = camera;
        }

        private void Update()
        {
            TryClick();
        }

        private void TryClick()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            if (!Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) return;

            if (!hit.collider.TryGetComponent(out IView view)) return;
            
            if(view.Model is IClickable model)
                _model.Click(model);
        }
    }
}