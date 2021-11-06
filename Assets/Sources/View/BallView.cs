using System;
using UnityEngine;
using Sources.Model;
using Sources.Abstract;

namespace Sources.View
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BallView : MonoBehaviour, IClickable
    {
        private BallModel _model;
        private BallMovement _movement;
        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer.GetComponent<MeshRenderer>();
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

        public void Click()
        {
            _model.OnClick();
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