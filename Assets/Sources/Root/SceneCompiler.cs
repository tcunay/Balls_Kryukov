using System;
using System.Collections.Generic;
using UnityEngine;
using Sources.Model;

namespace Sources.Root
{
    public class SceneCompiler : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private List<CompositeEntity> _order;

        private readonly PlayerModel _player = new PlayerModel(new Health(100));
        private readonly Dictionary<Type, dynamic> _composeObjects = new Dictionary<Type, dynamic>();

        private void Awake()
        {
            InitComposeObjects();
            foreach (var entity in _order)
            {
                entity.Compose(_composeObjects);
                entity.enabled = true;
            }
        }

        private void InitComposeObjects()
        {
            _composeObjects.Add(_camera.GetType(), _camera);
            _composeObjects.Add(_player.GetType(), _player);
        }
    }
}