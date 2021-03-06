using Sources.ExtensionMethods;
using Sources.Model;
using Sources.Setup;
using UnityEngine;
using Sources.View;

namespace Sources.Root
{
    public class BorderEntity : CompositeEntity
    {
        [SerializeField] private BorderView _template;

        private readonly BorderSetup _borderSetup = new BorderSetup();

        private Camera _camera;
        private PlayerModel _player;

        public override void Compose<T1, T2>(T1 t1, T2 t2)
        {
            _player = t1 as PlayerModel;
            _camera = t2 as Camera;
            
            Validator.Validate(_template == null, _borderSetup == null, _camera == null, _player == null);
        }


        private void OnEnable()
        {
            var borderView = SpawnView();
            _borderSetup.Setup(borderView, _player.Damageable);
        }

        private BorderView SpawnView()
        {
            var borderView = Instantiate(_template, transform.position, Quaternion.identity);

            float dontVisibilityOffset = _camera.GetYAxisVisibility() + borderView.Size / 2;

            var spawnPosition = new Vector2(_camera.transform.position.x,
                _camera.transform.position.y - dontVisibilityOffset);

            borderView.transform.position = spawnPosition;

            borderView.transform.localScale = new Vector3(
                borderView.transform.localScale.x + _camera.GetXAxisVisibility(),
                borderView.transform.localScale.y, borderView.transform.localScale.z);
            return borderView;
        }
    }
}