using System;
using System.Collections.Generic;
using UnityEngine;
using Sources.Abstract;
using Sources.Model;
using Sources.Setup;
using Sources.View;

namespace Sources.Root
{
    public class ClickerEntity : CompositeEntity
    {
        [SerializeField] private ClickerView _template;
        
        private readonly ClickerSetup _clickerSetup = new ClickerSetup();

        private Camera _camera;
        private IScoreable _player;
        
        public override void Compose(IDictionary<Type, dynamic> dictionary)
        {
            _camera = dictionary[typeof(Camera)];
            _player = dictionary[typeof(PlayerModel)];
            
            Validator.Validate(_camera == null, _player == null);
        }
        
        private void Start()
        {
            var view = Instantiate(_template);

            _clickerSetup.Setup(view, _camera, _player);
        }
    }
}