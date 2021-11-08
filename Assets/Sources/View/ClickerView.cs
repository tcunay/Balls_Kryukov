using System;
using Sources.Abstract;
using Sources.Model;
using UnityEngine;

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
            TryClickBall();
        }

        private void TryClickBall()
        {
            if (!Input.GetMouseButtonDown(0)) return;

            if (!Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) return;

            if (hit.collider.TryGetComponent(out IClickable clickable))
                _model.Click(clickable);
        }
    }
}