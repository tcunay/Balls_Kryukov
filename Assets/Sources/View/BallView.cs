using UnityEngine;
using Sources.Model;
using Sources.Abstract;

namespace Sources.View
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(SphereCollider))]
    public class BallView : MonoBehaviour, IClickable
    {
        private BallModel _model;
        private BallMovement _movement;
        private MeshRenderer _renderer;

        public IModel Model => _model;
        public Damageable Damageable => _model.Damageable;
        
        public float Size => GetComponent<SphereCollider>().radius * 2;
        
        public void Init(BallModel model, BallMovement movement)
        {
            _model = model;
            _movement = movement;
            
            _renderer.material.color = _model.Color;
            Model.Damageable.Died += Die;
        }

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            _movement.Update(Time.deltaTime);
            transform.position = _movement.Position;
        }

        private void Die()
        {
            Model.Damageable.Died -= Die;
            Destroy(gameObject);
        }
    }
}