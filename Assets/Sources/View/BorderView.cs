using System;
using Sources.Abstract;
using Sources.Model;
using UnityEngine;

namespace Sources.View
{
    [RequireComponent(typeof(BoxCollider))]
    public class BorderView : MonoBehaviour, IView
    {
        private BorderModel _model;

        public IModel Model => _model;
        public float Size => GetComponent<BoxCollider>().size.y;

        public void Init(BorderModel model)
        {
            Validator.Validate(model == null);
            
            _model = model;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IView view)) return;
            
            if(view.Model is IDamage damage)
                _model.OnDamageCollision(damage);
        }
    }
}