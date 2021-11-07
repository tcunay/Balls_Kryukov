using UnityEngine;
using Sources.Model;
using Sources.Abstract;

namespace Sources.View
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(SphereCollider))]
    public class BallView : MonoBehaviour, IView
    {
        private BallModel _model;
        private BallMovement _movement;
        private MeshRenderer _renderer;

        public IModel Model => _model;
        public float Size => GetComponent<SphereCollider>().radius * 2;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            Move();
        }

        public void Init(BallModel model, BallMovement movement)
        {
            _model = model;
            _movement = movement;
            
            _renderer.material.color = _model.Color;
            _model.Destoyed += Destroy;
        }

        private void Move()
        {
            _movement.Update(Time.deltaTime);
            transform.position = _movement.Position;
        }

        private void Destroy()
        {
            _model.Destoyed -= Destroy;
            Destroy(gameObject);
        }
    }
}