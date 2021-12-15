using UnityEngine;
using Sources.Abstract;
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
        
        public override void Compose<T1, T2>(T1 t1, T2 t2)
        {
            _camera = t1 as Camera;
            _player = (IScoreable) t2;
            
            Validator.Validate(_camera == null, _player == null);
        }

        private void OnEnable()
        {
            var view = Instantiate(_template);

            _clickerSetup.Setup(view, _camera, _player);
        }
    }
}