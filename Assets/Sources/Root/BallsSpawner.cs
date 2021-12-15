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

        public event Action<BallView> Spawned;

        public override void Compose<T1>(T1 t1)
        {
            _camera = t1 as Camera;
            
            Validator.Validate(_camera == null);
        }

        private void OnEnable()
        {
            StartSpawningWithInterval();
        }

        private void Update()
        {
            _timer.Update(Time.deltaTime);
        }

        private void StartSpawningWithInterval()
        {
            StartCoroutine(_timer.SetTickInterval(_spawnInterval));
            _timer.Tick += Spawn;
        }

        private void Spawn()
        {
            var ballView = Instantiate(_template);

            _ballSetup.Setup(ballView, _timer, _colorsLibrary, CalculateSpawnPosition(ballView));
            
            Spawned?.Invoke(ballView);
        }

        private Vector2 CalculateSpawnPosition(BallView view)
        {
            var xOffset = _camera.GetXAxisVisibility() - view.Size / 2;

            return new Vector2(transform.position.x + Random.Range(-xOffset, xOffset), transform.position.y);
        }
    }
}