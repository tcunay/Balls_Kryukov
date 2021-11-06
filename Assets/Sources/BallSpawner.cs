using System;
using System.Collections;
using Sources.Libraries;
using Sources.Model;
using Sources.Setup;
using Sources.View;
using UnityEngine;

namespace Sources
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private BallView _template;

        private ColorLibraries _colorLibraries = new ColorLibraries();
        private Timer _timer = new Timer();

        private void Start()
        {
            StartCoroutine(SpawnTime());
        }

        private void Update()
        {
            _timer.Update(Time.deltaTime);
        }

        private IEnumerator SpawnTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                Spawn();
            }
        }

        private void Spawn()
        {
            var ballSetup = new BallSetup(Instantiate(_template, transform), _timer, _colorLibraries);
        }
    }
}