using System;
using UnityEngine;
using Sources.ExtensionMethods;
using Sources.Libraries;
using Sources.Model;
using Sources.Setup;
using Sources.View;
using Random = UnityEngine.Random;

namespace Sources.Root
{
    public class BallsSpawner : CompositeEntity
    {
        [SerializeField] private BallView _template;

        private readonly BallSetup _ballSetup = new BallSetup();
        private readonly ColorsLibrary _colorsLibrary = new ColorsLibrary();
        private readonly Timer _timer = new Timer();
        private readonly int _spawnInterval = 1;

        private Camera _camera;

        public override void Compose(Camera camera)
        {
            _camera = camera;
        }

        private void Start()
        {
            SetSpawnInterval();
        }

        private void Update()
        {
            _timer.Update(Time.deltaTime);
        }

        private void SetSpawnInterval()
        {
            StartCoroutine(_timer.SetTickInterval(_spawnInterval));
            _timer.Tick += Spawn;
        }

        private void Spawn()
        {
            var view = Instantiate(_template);

            _ballSetup.Setup(view, _timer, _colorsLibrary, CalculateSpawnPosition(view));
        }

        private Vector2 CalculateSpawnPosition(BallView view)
        {
            var xOffset = _camera.GetXAxisVisibility() - view.Size / 2;

            return new Vector2(transform.position.x + Random.Range(-xOffset, xOffset), transform.position.y);
        }
    }
}