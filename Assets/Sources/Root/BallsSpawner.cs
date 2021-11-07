using System;
using Sources.ExtensionMethods;
using UnityEngine;
using Sources.Libraries;
using Sources.Model;
using Sources.Setup;
using Sources.View;
using Random = UnityEngine.Random;

namespace Sources.Root
{
    public class BallsSpawner : RootEntity
    {
        [SerializeField] private BallView _template;

        private readonly ColorsLibrary _colorsLibrary = new ColorsLibrary();
        private readonly Timer _timer = new Timer();

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            _timer.Update(Time.deltaTime);
        }

        public override void Begin()
        {
            StartCoroutine(_timer.SetTickInterval(1));
            _timer.Tick += Spawn;
        }

        private void Spawn()
        {
            var view = Instantiate(_template);

            new BallSetup(view, _timer, _colorsLibrary, CalculateSpawnPosition(view.Size));
        }

        private Vector2 CalculateSpawnPosition(float viewSize)
        {
            var xOffset = _camera.GetXAxisVisibility() + viewSize / 2;
            var position = transform.position;

            return new Vector2(position.x + Random.Range(-xOffset, xOffset), position.y);
        }
    }
}